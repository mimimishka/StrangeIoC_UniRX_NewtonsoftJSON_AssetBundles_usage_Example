using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using Newtonsoft.Json;

namespace Example
{
    public class InitObjectsCommand : Command
    {
        [Inject]
        public IBundlesAccessService BundlesAccessService { get; private set; }
        [Inject]
        public IBundlesNamesService BundlesNamesService { get; private set; }
        [Inject]
        public PrimitiveGenerator Generator { get; private set; }

        int expectedResponses;
        int receivedResponses;
        List<Primitive> primitives;

        public override void Execute()
        {
            Retain();
            BundlesNamesService.Dispatcher.AddListener(Example.BundlesNamesService.COMPLETE_EVENT, OnLoadBundlesNames);
            BundlesNamesService.Request();
        }
        void OnLoadBundlesNames(IEvent evt)
        {
            this.BundlesNamesService.Dispatcher.RemoveListener(Example.BundlesNamesService.COMPLETE_EVENT, OnLoadBundlesNames);
            PrimitiveMeta[] primitivesMeta = JsonConvert.DeserializeObject<PrimitiveMeta[]>(evt.data as string);
            expectedResponses = primitivesMeta.Length;
            receivedResponses = 0;
            primitives = new List<Primitive>();
            BundlesAccessService.Dispatcher.AddListener(Example.BundlesAccessService.COMPLETE_EVENT, OnResponse);
            foreach (PrimitiveMeta meta in primitivesMeta)
                BundlesAccessService.Request(meta.BundleName, meta.ObjectName);
        }
        void OnResponse(IEvent evt)
        {
            ++receivedResponses;
            primitives.Add(evt.data as Primitive);

            if (receivedResponses == expectedResponses)
            {
                this.BundlesAccessService.Dispatcher.RemoveListener(Example.BundlesAccessService.COMPLETE_EVENT, OnResponse);
                Generator.Init(primitives);
                Release();
            }
        }
    }
}
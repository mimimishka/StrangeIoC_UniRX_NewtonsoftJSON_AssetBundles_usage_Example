using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.command.api;

namespace Example
{
    public class MainContext : MVCSContext
    {
        public MainContext(MonoBehaviour view) : base(view) { }
        public MainContext(MonoBehaviour view, ContextStartupFlags flags):base(view, flags) { }
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>();
        }
        protected override void mapBindings()
        {
            base.mapBindings();
            InjectionBind();
            CommandBind();
            MediationBind();
            ResourcesBind();
        }
        public override void Launch()
        {
            base.Launch();
            injectionBinder.GetInstance<StartAppSignal>().Dispatch();
        }
        void CommandBind()
        {
            commandBinder.Bind<StartAppSignal>()
                .InSequence()
                .To<InitObjectsCommand>()
                .To<CreateClickDetectorCommand>();
            commandBinder.Bind<ClickSignal>().To<CreatePrimitiveCommand>();
            commandBinder.Bind<ViewClickSignal>().To<ViewClickHandleCommand>();
            commandBinder.Bind<OnViewCreatedSignal>().To<ViewCreatedHandleCommand>();
            commandBinder.Bind<TimeElapsedSignal>().To<TimeElapsedHandleCommand>();
        }
        void InjectionBind()
        {
            injectionBinder.Bind<StartAppSignal>().ToSingleton();
            injectionBinder.Bind<ClickSignal>().ToSingleton();
            injectionBinder.Bind<OnViewCreatedSignal>().ToSingleton();
            injectionBinder.Bind<TimeElapsedSignal>().ToSingleton();
            injectionBinder.Bind<ViewClickSignal>().ToSingleton();

            injectionBinder.Bind<PrimitiveGenerator>().ToSingleton();
            injectionBinder.Bind<PrimitiveColorAccessor>().ToSingleton();
            injectionBinder.Bind<IBundlesAccessService>().To<BundlesAccessService>().ToSingleton();
            injectionBinder.Bind<IBundlesNamesService>().To<BundlesNamesService>().ToSingleton();
            injectionBinder.Bind<GeometryObjectModel>().To<GeometryObjectModel>();
            injectionBinder.Bind<string>().ToValue("Files/JSON.json").ToName(FilePath.JSON);
            injectionBinder.Bind<string>().ToValue("AssetBundles").ToName(FilePath.BUNDLES);
        }
        void MediationBind()
        {
            mediationBinder.Bind<ClickDetectorView>().To<ClickDetectorMediator>();
            mediationBinder.Bind<PrimitiveView>().To<PrimitiveMediator>();
        }
        void ResourcesBind()
        {
            injectionBinder.Bind<GeometryObjectData>().ToValue
            (
                Resources.Load("ClicksConfig") as GeometryObjectData
            );
            injectionBinder.Bind<GameData>().ToValue
            (
                Resources.Load("GameData") as GameData
            );
        }
    }
}
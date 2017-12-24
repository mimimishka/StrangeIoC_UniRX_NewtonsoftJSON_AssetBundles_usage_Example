using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;


namespace Example
{
    public class PrimitiveView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        internal GeometryObjectModel Model { get; set; }
        internal Color Color
        {
            get
            {
                return GetComponent<MeshRenderer>().material.color;
            }
            private set
            {
                if(Color != value)
                    GetComponent<MeshRenderer>().material.color = value;
            }
        }
        public string Name { get; set; }
        internal const string CLICK_EVENT = "view click";
        internal void OnViewClick()
        {
            Dispatcher.Dispatch(CLICK_EVENT);
        }
        internal void UpdateColor()
        {
            Color = Model.Color.Value;
        }
    }
}
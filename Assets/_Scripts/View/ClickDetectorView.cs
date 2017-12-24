using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UniRx;

namespace Example
{
    public class Vector3Box { public Vector3 Vector { get; set; } }
    public class ClickDetectorView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        internal const string CLICK_EMPTY = "click empty";


        internal void Init()
        {
            var clickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0)).Select(_ => Input.mousePosition);
            clickStream.Subscribe((pos) => OnClick(pos));
        }
        void OnClick(Vector3 pos)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            PrimitiveView view;
            if (Physics.Raycast(ray, out hit) && (view = hit.collider.GetComponent<PrimitiveView>()))
                view.OnViewClick();
            else
                Dispatcher.Dispatch(CLICK_EMPTY, new Vector3Box { Vector = pos });
        }
    }
}
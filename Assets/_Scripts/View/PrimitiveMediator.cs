using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UniRx;

namespace Example
{
    public class PrimitiveMediator : Mediator
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        [Inject]
        public PrimitiveView View { get; private set; }
        [Inject]
        public GeometryObjectModel Model { get; private set; }
        [Inject]
        public ViewClickSignal ClickSignal { get; private set; }
        [Inject]
        public OnViewCreatedSignal OnCreatedSignal { get; private set; }
        [Inject]
        public GameData GameData { get; private set; }
        [Inject]
        public TimeElapsedSignal ElapsedSignal { get; private set; }

        float lastTimeClicked;

        public override void OnRegister()
        {
            UpdateClickTime();
            View.Model = Model;
            Model.Color.Subscribe(_ => View.UpdateColor());
            Model.ClickCount.Subscribe(_ => UpdateClickTime());

            Observable.EveryUpdate().Where(_ => Time.time >= lastTimeClicked + GameData.ObservableTime).Subscribe(_ =>
            {
                ElapsedSignal.Dispatch(View);
                UpdateClickTime();
            });

            View.Dispatcher.UpdateListener(true, PrimitiveView.CLICK_EVENT, OnViewClick);
            OnCreatedSignal.Dispatch(View);
        }
        void OnViewClick()
        {
            ClickSignal.Dispatch(View);
        }
        void UpdateClickTime()
        {
            lastTimeClicked = Time.time;
        }
    }
}
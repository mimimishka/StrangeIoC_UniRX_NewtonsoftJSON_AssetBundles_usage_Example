using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Example
{
    public class ClickDetectorMediator : Mediator
    {
        [Inject]
        public ClickDetectorView View { get; private set; }
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        [Inject]
        public ClickSignal ClickSignal { get; private set; }

        public override void OnRegister()
        {
            View.Dispatcher.UpdateListener(true, ClickDetectorView.CLICK_EMPTY, OnClick);
            View.Init();
        }
        void OnClick(IEvent evt)
        {
            ClickSignal.Dispatch(evt.data as Vector3Box);
        }
    }
}
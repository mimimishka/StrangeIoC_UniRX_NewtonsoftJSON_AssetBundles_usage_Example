using strange.extensions.dispatcher.eventdispatcher.api;

namespace Example
{
    public interface IBundlesAccessService
    {
        IEventDispatcher Dispatcher { get; set; }
        void Request(string bundleName, string prefabName);
    }
}
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Example
{
    public interface IBundlesNamesService
    {
        IEventDispatcher Dispatcher { get; set; }
        void Request();
    }
}
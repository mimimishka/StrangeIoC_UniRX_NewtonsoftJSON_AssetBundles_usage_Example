using strange.extensions.dispatcher.eventdispatcher.api;
using System.IO;

namespace Example
{
    public class BundlesNamesService : IBundlesNamesService
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; set; }
        [Inject(name = FilePath.JSON)]
        public string JsonFilePath { get; private set; }
        internal const string COMPLETE_EVENT = "on load complete";

        public void Request()
        {
            OnComplete(File.ReadAllText(JsonFilePath));
        }
        void OnComplete(string result)
        {
            Dispatcher.Dispatch(COMPLETE_EVENT, result);
        }
    }
}
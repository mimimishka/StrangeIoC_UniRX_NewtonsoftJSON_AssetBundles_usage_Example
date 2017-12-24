using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

namespace Example
{
    public class BundlesAccessService : IBundlesAccessService
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; set; }
        [Inject(name = FilePath.BUNDLES)]
        public string BundlesName { get; private set; }

        internal const string COMPLETE_EVENT = "on complete";

        public void Request(string bundleName, string prefabName)
        {
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Application.dataPath + "/" + BundlesName + "/" + bundleName);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }
            GameObject prefab = myLoadedAssetBundle.LoadAsset<GameObject>(prefabName);
            Primitive primitive = new Primitive
            {
                Prefab = prefab,
                Name = bundleName
            };
            OnComplete(primitive);
            myLoadedAssetBundle.Unload(false);
        }
        void OnComplete(Primitive primitive)
        {
            Dispatcher.Dispatch(COMPLETE_EVENT, primitive);
        }
    }
}
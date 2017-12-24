using UnityEditor;

public class BuildBundles
{
    [MenuItem("Asset Bundles/Build")]
    static void Build()
    {
        string path = EditorUtility.SaveFolderPanel("Save bundles", "", "objects");
        if (path != "")
        {
            BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
using UnityEngine;
using UnityEditor;
using System.IO;

using RocketsAndGamblers;

public class BuildAssetBundles 
{
	[MenuItem("Assets/Build asset bundles")]
	public static void BuildBundles()
	{
        if (!Directory.Exists(Constants.AssetBundlesPath)) {
            Directory.CreateDirectory(Constants.AssetBundlesPath);
        }

        BuildPipeline.BuildAssetBundles(Constants.AssetBundlesPath, BuildAssetBundleOptions.None, BuildTarget.Android);
	}
}

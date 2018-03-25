using UnityEngine;
using UnityEditor;
using RocketsAndGamblers.Data;
using System;

namespace RocketsAndGamblers.Edior
{
    public class SaveBasePipeline
    {
        [MenuItem("Assets/Build base")]
        public static void BuildBase ()
        {
            var baseDescription = new BaseDescription();
            var baseProperties = Selection.activeObject as BaseProperties;

            baseDescription.goldMiningLimit = baseProperties.goldMiningLimit;
            baseDescription.goldMiningStarted = DateTime.MinValue.ToBinary();

            baseDescription.omoniumVeinsMax = baseProperties.omoniumVeinsMax;
            baseDescription.omoniumVeinsLeft = baseProperties.omoniumVeinsMax;
            baseDescription.omoniumMiningStarted = DateTime.MinValue.ToBinary();

            //TODO populate layout and upgrades

            //TODO populate asset bundle names automatically
            var manifest = BuildPipeline.BuildAssetBundles(Constants.AssetBundlesPath, BuildAssetBundleOptions.None, BuildTarget.Android);
            var bundleName = manifest.GetAllAssetBundles()[0];

            baseDescription.bundleName = bundleName;

            baseProperties.provider.UpdatePlayerBase(Constants.PlayerId, baseDescription);
        }

        [MenuItem("Assets/Build base", validate = true)]
        public static bool BuildBaseValidate ()
        {
            return Selection.activeObject is BaseProperties;
        }
    }
}

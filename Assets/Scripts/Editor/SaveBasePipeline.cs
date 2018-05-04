using UnityEngine;
using UnityEditor;
using RocketsAndGamblers.Data;
using System;
using RocketsAndGamblers.Database;

namespace RocketsAndGamblers.Edior
{
    public class SaveBasePipeline
    {
        [MenuItem("Assets/Build base")]
        public static void BuildBase ()
        {
            var baseDescription = new BaseDescription();
            BaseProperties baseProperties = FromProperties(baseDescription);

            //TODO populate layout and upgrades
            WriteDefensesLayout(baseDescription);

            //TODO automatically assing asset bundle names to corresponding assets

            var manifest = BuildPipeline.BuildAssetBundles(Constants.AssetBundlesPath, BuildAssetBundleOptions.None, BuildTarget.Android);
            var bundleName = manifest.GetAllAssetBundles()[0];

            baseDescription.bundleName = bundleName;

            //baseProperties.provider.UpdatePlayerBase(baseProperties.playerId, baseDescription);
        }

        public static void WriteDefensesLayout (BaseDescription baseDesription)
        {
            var layoutObjects = UnityEngine.Object.FindObjectsOfType<LayoutObject>();
            var objectId = 1;
            foreach (var obj in layoutObjects) {
                var objectIdentity = obj.GetComponent<ObjectIdentity>();
                objectIdentity.RuntimeId = objectId++;

                baseDesription.AddToLayout(objectIdentity);

                var additionalData = obj.GetComponent<AdditionalDataProvider>();
                if (additionalData != null) {
                    baseDesription.AddAdditionalData(additionalData);
                }
            }

            //In case some objects have dependencies on each other, destroy them afterwards
            foreach (var layoutObject in layoutObjects) {
                UnityEngine.Object.DestroyImmediate(layoutObject.gameObject);
            }
        }

        private static BaseProperties FromProperties (BaseDescription baseDescription)
        {
            var baseProperties = Selection.activeObject as BaseProperties;

            baseDescription.goldMiningLimit = baseProperties.goldMiningLimit;
            baseDescription.goldMiningStarted = DateTime.MinValue.ToBinary();

            baseDescription.omoniumVeinsMax = baseProperties.omoniumVeinsMax;
            baseDescription.omoniumVeinsLeft = baseProperties.omoniumVeinsMax;
            baseDescription.omoniumMiningStarted = DateTime.MinValue.ToBinary();

            baseDescription.availableDefenses = baseProperties.availableDefenses.ToArray();
            return baseProperties;
        }

        [MenuItem("Assets/Build base", validate = true)]
        public static bool BuildBaseValidate ()
        {
            return Selection.activeObject is BaseProperties;
        }
    }
}

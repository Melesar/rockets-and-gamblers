using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Framework.Data
{
    public class DisposableBundle : IDisposable
    {
        private readonly AssetBundle bundle;
        private readonly bool unloadAssets;

        public DisposableBundle(AssetBundle bundle, bool unloadAssets = false)
        {
            this.bundle = bundle;
            this.unloadAssets = unloadAssets;
        }
        
        public void Dispose()
        {
            bundle.Unload(unloadAssets);
        }

        public bool Contains(string name)
        {
            return bundle.Contains(name);
        }

        public Object LoadAsset(string name)
        {
            return bundle.LoadAsset(name);
        }

        public T LoadAsset<T>(string name) where T : Object
        {
            return bundle.LoadAsset<T>(name);
        }

        public Object LoadAsset(string name, Type type)
        {
            return bundle.LoadAsset(name, type);
        }

        public AssetBundleRequest LoadAssetAsync(string name)
        {
            return bundle.LoadAssetAsync(name);
        }

        public AssetBundleRequest LoadAssetAsync<T>(string name)
        {
            return bundle.LoadAssetAsync<T>(name);
        }

        public AssetBundleRequest LoadAssetAsync(string name, Type type)
        {
            return bundle.LoadAssetAsync(name, type);
        }

        public Object[] LoadAssetWithSubAssets(string name)
        {
            return bundle.LoadAssetWithSubAssets(name);
        }

        public T[] LoadAssetWithSubAssets<T>(string name) where T : Object
        {
            return bundle.LoadAssetWithSubAssets<T>(name);
        }

        public Object[] LoadAssetWithSubAssets(string name, Type type)
        {
            return bundle.LoadAssetWithSubAssets(name, type);
        }

        public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name)
        {
            return bundle.LoadAssetWithSubAssetsAsync(name);
        }

        public AssetBundleRequest LoadAssetWithSubAssetsAsync<T>(string name)
        {
            return bundle.LoadAssetWithSubAssetsAsync<T>(name);
        }

        public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type)
        {
            return bundle.LoadAssetWithSubAssetsAsync(name, type);
        }

        public Object[] LoadAllAssets()
        {
            return bundle.LoadAllAssets();
        }

        public T[] LoadAllAssets<T>() where T : Object
        {
            return bundle.LoadAllAssets<T>();
        }

        public Object[] LoadAllAssets(Type type)
        {
            return bundle.LoadAllAssets(type);
        }

        public AssetBundleRequest LoadAllAssetsAsync()
        {
            return bundle.LoadAllAssetsAsync();
        }

        public AssetBundleRequest LoadAllAssetsAsync<T>()
        {
            return bundle.LoadAllAssetsAsync<T>();
        }

        public AssetBundleRequest LoadAllAssetsAsync(Type type)
        {
            return bundle.LoadAllAssetsAsync(type);
        }

        public string[] GetAllAssetNames()
        {
            return bundle.GetAllAssetNames();
        }

        public string[] GetAllScenePaths()
        {
            return bundle.GetAllScenePaths();
        }

        public Object mainAsset => bundle.mainAsset;

        public bool isStreamedSceneAssetBundle => bundle.isStreamedSceneAssetBundle;
        
    }
}
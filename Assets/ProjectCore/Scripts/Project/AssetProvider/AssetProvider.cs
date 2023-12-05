using UnityEngine;

namespace ProjectCore.Scripts.Project.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        public T Get<T>(string path) where T : Object => Resources.Load<T>(path);
    }
}
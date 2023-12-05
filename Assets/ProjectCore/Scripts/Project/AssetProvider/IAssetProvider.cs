using UnityEngine;

namespace ProjectCore.Scripts.Project.AssetProvider
{
    public interface IAssetProvider
    {
        public T Get<T>(string path) where T : Object;
    }
}
using ProjectCore.Scripts.Project.AssetProvider;
using UnityEngine;

namespace ProjectCore.Scripts.Profile.Infrastructure.Data
{
    public class ProfileStaticDataProvider
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ProfileConfig _config;

        public ProfileStaticDataProvider(IAssetProvider assetProvider, ProfileConfig config)
        {
            _assetProvider = assetProvider;
            _config = config;
        }

        public ProfileConfig GetConfig() => _config;

        public Sprite GetIcon(string iconName) => _assetProvider.Get<Sprite>(iconName);
    }
}
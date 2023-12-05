using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ProfileOverviewUIFactory : IInitializable
    {
        private readonly ProfileStaticDataProvider _staticDataProvider;
        private readonly IInstantiator _instantiator;
        private ProfileConfig _config;

        public ProfileOverviewUIFactory(ProfileStaticDataProvider staticDataProvider, IInstantiator instantiator)
        {
            _staticDataProvider = staticDataProvider;
            _instantiator = instantiator;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public ProfileOverviewView CreateView(Transform root)
        {
            var prefab = _config.OverviewViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ProfileOverviewView>(prefab);

            item.transform.SetParent(root, false);
            return item;
        }

        public ProfileOverviewShowMatchStatsButton CreateMatchStatsShowButton(MatchData matchData, Transform root,
            ProfileController profileController)
        {
            var prefab = _config.ProfileOverviewShowMatchStatsButtonPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ProfileOverviewShowMatchStatsButton>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(matchData, _staticDataProvider.GetIcon(matchData.Icon), profileController);
            return item;
        }

        public ProfileOverviewMatchParameterBlock CreateMatchParameterBlock(MatchParameter parameter, Transform root)
        {
            var prefab = _config.ProfileOverviewMatchParameterBlockPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ProfileOverviewMatchParameterBlock>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(parameter);
            return item;
        }

        public void DestroyMatchStatsShowButton(ProfileOverviewShowMatchStatsButton button) =>
            Object.Destroy(button.gameObject);

        public void DestroyMatchParameterBlock(ProfileOverviewMatchParameterBlock block) =>
            Object.Destroy(block.gameObject);
    }
}
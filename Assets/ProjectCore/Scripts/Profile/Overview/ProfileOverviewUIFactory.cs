using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ProfileOverviewUIFactory : IInitializable
    {
        private readonly ProfileConfigProvider _configProvider;
        private readonly IInstantiator _instantiator;
        private ProfileConfig _config;

        public ProfileOverviewUIFactory(ProfileConfigProvider configProvider, IInstantiator instantiator)
        {
            _configProvider = configProvider;
            _instantiator = instantiator;
        }

        public void Initialize() => _config = _configProvider.GetConfig();

        public ProfileOverviewView CreateView(Transform root)
        {
            var prefab = _config.OverviewViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ProfileOverviewView>(prefab);

            item.transform.SetParent(root, false);
            return item;
        }

        public ShowMatchStatsButton CreateMatchStatsShowButton(MatchData matchData, Transform root,
            ProfileOverviewView view)
        {
            var prefab = _config.ShowMatchStatsButtonPrefab;
            var args = new object[] { matchData, view };
            var item = _instantiator.InstantiatePrefabForComponent<ShowMatchStatsButton>(prefab, args);

            item.transform.SetParent(root, false);
            item.Initialize();
            return item;
        }

        public MatchParameterBlock CreateMatchParameterBlock(MatchParameter parameter, Transform root)
        {
            var prefab = _config.MatchParameterBlockPrefab;
            var args = new object[] { parameter };
            var item = _instantiator.InstantiatePrefabForComponent<MatchParameterBlock>(prefab, args);

            item.transform.SetParent(root, false);
            item.Initialize();
            return item;
        }

        public void DestroyMatchStatsShowButton(ShowMatchStatsButton button) => Object.Destroy(button.gameObject);

        public void DestroyMatchParameterBlock(MatchParameterBlock block) => Object.Destroy(block.gameObject);
    }
}
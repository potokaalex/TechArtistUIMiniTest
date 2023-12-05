using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Achievements
{
    public class ProfileAchievementsUIFactory : IInitializable
    {
        private readonly ProfileStaticDataProvider _staticDataProvider;
        private readonly IInstantiator _instantiator;
        private ProfileConfig _config;

        public ProfileAchievementsUIFactory(ProfileStaticDataProvider staticDataProvider, IInstantiator instantiator)
        {
            _staticDataProvider = staticDataProvider;
            _instantiator = instantiator;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public ProfileAchievementsView CreateView(Transform root)
        {
            var prefab = _config.AchievementsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ProfileAchievementsView>(prefab);

            item.transform.SetParent(root, false);
            return item;
        }

        public AchievementsGroup CreateAchievementsGroup(Transform root)
        {
            var prefab = _config.AchievementsGroupPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<AchievementsGroup>(prefab);

            item.transform.SetParent(root, false);
            return item;
        }

        public void CreateAchievementsGroupItem(AchievementData achievementData, Transform root)
        {
            var prefab = _config.AchievementsGroupItemPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<AchievementsGroupItem>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(achievementData);
        }
    }
}
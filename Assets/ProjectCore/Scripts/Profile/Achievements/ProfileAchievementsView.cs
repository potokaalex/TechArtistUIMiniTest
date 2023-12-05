using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Utilities.UI;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Achievements
{
    public class ProfileAchievementsView : WindowBase
    {
        [SerializeField] private Transform _achievementsGroupRoot;
        private ProfileAchievementsUIFactory _profileUIFactory;

        [Inject]
        public void Construct(ProfileAchievementsUIFactory profileUIFactory) => _profileUIFactory = profileUIFactory;

        public void Initialize(AchievementData[] achievements)
        {
            Close();
            CreateAchievements(achievements);
        }

        public override void Open()
        {
            base.Open();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            gameObject.SetActive(false);
        }

        private void CreateAchievements(AchievementData[] achievements)
        {
            var currentGroup = _profileUIFactory.CreateAchievementsGroup(_achievementsGroupRoot);

            for (var i = 0; i < achievements.Length; i++)
            {
                if (i != 0 && i % 3 == 0)
                    currentGroup = _profileUIFactory.CreateAchievementsGroup(_achievementsGroupRoot);

                _profileUIFactory.CreateAchievementsGroupItem(achievements[i], currentGroup.transform);
            }
        }
    }
}
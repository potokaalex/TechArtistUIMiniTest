using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Utilities.UI;
using UnityEngine;

namespace ProjectCore.Scripts.Profile.Achievements
{
    public class ProfileAchievementsView : WindowBase
    {
        [SerializeField] private Transform _achievementsGroupRoot;
        private ProfileController _profileController;

        public void Initialize(AchievementData[] achievements, ProfileController profileController)
        {
            _profileController = profileController;

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
            var currentGroup = _profileController.CreateAchievementsGroup(_achievementsGroupRoot);

            for (var i = 0; i < achievements.Length; i++)
            {
                if (i != 0 && i % 3 == 0)
                    currentGroup = _profileController.CreateAchievementsGroup(_achievementsGroupRoot);

                _profileController.CreateAchievementsGroupItem(achievements[i], currentGroup.transform);
            }
        }
    }
}
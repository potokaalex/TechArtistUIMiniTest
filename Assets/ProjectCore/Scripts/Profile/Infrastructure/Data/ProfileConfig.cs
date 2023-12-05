using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using UnityEngine;

namespace ProjectCore.Scripts.Profile.Infrastructure.Data
{
    [CreateAssetMenu(menuName = "Configurations/Profile", fileName = "ProfileConfig", order = 0)]
    public class ProfileConfig : ScriptableObject
    {
        public ProfileMainView MainViewPrefab;
        public ProfileAchievementsView AchievementsViewPrefab;
        public ProfileOverviewView OverviewViewPrefab;

        public ProfileOverviewShowMatchStatsButton ProfileOverviewShowMatchStatsButtonPrefab;
        public ProfileOverviewMatchParameterBlock ProfileOverviewMatchParameterBlockPrefab;
        public ProfileAchievementsGroup ProfileAchievementsGroupPrefab;
        public ProfileAchievementsGroupItem ProfileAchievementsGroupItemPrefab;
    }
}
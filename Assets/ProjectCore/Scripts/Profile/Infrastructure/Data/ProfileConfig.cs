using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using UnityEngine;

namespace ProjectCore.Scripts.Profile.Infrastructure.Data
{
    [CreateAssetMenu(menuName = "Configurations/Profile", fileName = "ProfileConfig", order = 0)]
    public class ProfileConfig : ScriptableObject
    {
        public Material TextSelectMaterial;
        public Material TextHideMaterial;

        public ProfileMainController MainControllerPrefab;

        public ProfileMainView MainViewPrefab;
        public ProfileAchievementsView AchievementsViewPrefab;
        public ProfileOverviewView OverviewViewPrefab;

        public ShowMatchStatsButton ShowMatchStatsButtonPrefab;
        public MatchParameterBlock MatchParameterBlockPrefab;
        public AchievementsGroup AchievementsGroupPrefab;
        public AchievementsGroupItem AchievementsGroupItemPrefab;
    }
}
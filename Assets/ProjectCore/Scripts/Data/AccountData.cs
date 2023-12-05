using ProjectCore.Scripts.Data.Matching;

namespace ProjectCore.Scripts.Data
{
    public class AccountData
    {
        public string Name;
        public string AvatarIcon;
        public int Level;
        public int Experience;
        public int ExperienceMax;
        public AchievementData[] Achievements;
        public MatchData[] Matches;
    }
}
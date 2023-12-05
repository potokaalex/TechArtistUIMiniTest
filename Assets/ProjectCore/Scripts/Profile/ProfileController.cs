using System.Linq;
using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using Zenject;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileController
    {
        private readonly ProfileModel _model;

        private ProfileOverviewView _overviewView;
        private ProfileAchievementsView _achievementsView;
        private ProfileMainView _mainView;
        private AccountData _data;

        [Inject]
        public ProfileController(ProfileModel model) => _model = model;

        public void Initialize(ProfileMainView mainView, ProfileAchievementsView achievementsView,
            ProfileOverviewView overviewView)
        {
            _data = _model.GetAccount();

            _mainView = mainView;
            _achievementsView = achievementsView;
            _overviewView = overviewView;

            _mainView.Initialize(_data);
            _achievementsView.Initialize(_data.Achievements);
            _overviewView.Initialize(_data.Matches.Where(m => m.MatchType == MatchType.Unranked).ToArray());
        }

        public void SetOverviewMatchesFilter(MatchType type) =>
            _overviewView.SetMatches(_data.Matches.Where(m => m.MatchType == type).ToArray());
    }
}
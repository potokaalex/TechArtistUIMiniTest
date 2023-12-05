using System;
using System.Linq;
using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileController
    {
        private readonly ProfileModel _model;
        private readonly ProfileStaticDataProvider _staticDataProvider;
        private readonly ProfileAchievementsUIFactory _achievementsUIFactory;
        private readonly ProfileOverviewUIFactory _overviewUIFactory;

        private ProfileUIWindowManager _windowManager;
        private ProfileMainView _mainView;
        private ProfileOverviewView _overviewView;
        private ProfileAchievementsView _achievementsView;
        private AccountData _data;

        [Inject]
        public ProfileController(ProfileModel model, ProfileStaticDataProvider staticDataProvider,
            ProfileAchievementsUIFactory achievementsUIFactory, ProfileOverviewUIFactory overviewUIFactory)
        {
            _model = model;
            _staticDataProvider = staticDataProvider;
            _achievementsUIFactory = achievementsUIFactory;
            _overviewUIFactory = overviewUIFactory;
        }

        public event Action OnWindowClosedEvent;

        public void Initialize(ProfileMainView mainView, ProfileAchievementsView achievementsView,
            ProfileOverviewView overviewView, ProfileUIWindowManager windowManager)
        {
            _data = _model.GetAccount();
            _mainView = mainView;
            _achievementsView = achievementsView;
            _overviewView = overviewView;
            _windowManager = windowManager;

            _mainView.Initialize(_data, _staticDataProvider.GetIcon(_data.AvatarIcon), this);
            _achievementsView.Initialize(_data.Achievements, this);
            _overviewView.Initialize(_data.Matches.Where(m => m.MatchType == MatchType.Unranked).ToArray(), this);
        }

        public void SetOverviewMatchesFilter(MatchType type) =>
            _overviewView.SetMatches(_data.Matches.Where(m => m.MatchType == type).ToArray());

        public bool IsCurrentWindow(ProfileWindowType type) => _windowManager.IsCurrentWindow(type);

        public void CloseCurrentWindow() => _windowManager.CloseCurrentWindow();

        public void OpenWindow(ProfileWindowType type) => _windowManager.OpenWindow(type);

        public void OnCurrentWindowClosed() => OnWindowClosedEvent?.Invoke();

        public ProfileAchievementsGroup CreateAchievementsGroup(Transform root) =>
            _achievementsUIFactory.CreateAchievementsGroup(root);

        public void CreateAchievementsGroupItem(AchievementData data, Transform root) =>
            _achievementsUIFactory.CreateAchievementsGroupItem(data, root);

        public void SetMatchParameters(MatchParameter[] parameters) => _overviewView.SetMatchParameters(parameters);

        public ProfileOverviewShowMatchStatsButton CreateMatchStatsShowButton(MatchData data, Transform root) =>
            _overviewUIFactory.CreateMatchStatsShowButton(data, root, this);

        public ProfileOverviewMatchParameterBlock CreateMatchParameterBlock(MatchParameter data, Transform root) =>
            _overviewUIFactory.CreateMatchParameterBlock(data, root);

        public void DestroyMatchParameterBlock(ProfileOverviewMatchParameterBlock block) =>
            _overviewUIFactory.DestroyMatchParameterBlock(block);

        public void DestroyMatchStatsShowButton(ProfileOverviewShowMatchStatsButton button) =>
            _overviewUIFactory.DestroyMatchStatsShowButton(button);
    }
}
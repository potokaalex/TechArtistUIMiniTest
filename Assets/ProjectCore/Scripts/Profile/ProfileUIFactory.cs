using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileUIFactory : IInitializable
    {
        private readonly ProfileConfigProvider _configProvider;
        private readonly IInstantiator _instantiator;
        private readonly ProfileUIProvider _profileUIProvider;
        private readonly ProfileAchievementsUIFactory _achievementsUIFactory;
        private readonly ProfileOverviewUIFactory _overviewUIFactory;
        private readonly ProfileUIWindowManager _windowManager;
        private ProfileConfig _config;

        public ProfileUIFactory(ProfileConfigProvider configProvider, IInstantiator instantiator,
            ProfileUIProvider profileUIProvider, ProfileAchievementsUIFactory achievementsUIFactory,
            ProfileOverviewUIFactory overviewUIFactory, ProfileUIWindowManager windowManager)
        {
            _configProvider = configProvider;
            _instantiator = instantiator;
            _profileUIProvider = profileUIProvider;
            _achievementsUIFactory = achievementsUIFactory;
            _overviewUIFactory = overviewUIFactory;
            _windowManager = windowManager;
        }

        public void Initialize() => _config = _configProvider.GetConfig();

        public void Create()
        {
            var mainController = CreateMainController();
            var viewsRoot = mainController.GetViewsParent();
            var mainView = CreateMainView(viewsRoot);
            var achievementsView = _achievementsUIFactory.CreateView(viewsRoot);
            var overviewView = _overviewUIFactory.CreateView(viewsRoot);

            _profileUIProvider.Initialize(mainController);
            mainController.Initialize(mainView, achievementsView, overviewView);
            _windowManager.Initialize(achievementsView, overviewView);
        }

        private ProfileMainController CreateMainController()
        {
            var prefab = _config.MainControllerPrefab;
            var controller = _instantiator.InstantiatePrefabForComponent<ProfileMainController>(prefab);

            return controller;
        }

        private ProfileMainView CreateMainView(Transform viewsRoot)
        {
            var prefab = _config.MainViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ProfileMainView>(prefab);

            item.transform.SetParent(viewsRoot, false);
            return item;
        }
    }
}
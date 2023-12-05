using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using Zenject;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileUIFactory : IInitializable
    {
        private readonly ProfileStaticDataProvider _staticDataProvider;
        private readonly IInstantiator _instantiator;
        private readonly ProfileAchievementsUIFactory _achievementsUIFactory;
        private readonly ProfileOverviewUIFactory _overviewUIFactory;
        private readonly ProfileUIWindowManager _windowManager;
        private readonly ProfileController _profileController;
        private ProfileConfig _config;

        public ProfileUIFactory(ProfileStaticDataProvider staticDataProvider, IInstantiator instantiator,
            ProfileAchievementsUIFactory achievementsUIFactory, ProfileOverviewUIFactory overviewUIFactory,
            ProfileUIWindowManager windowManager, ProfileController profileController)
        {
            _staticDataProvider = staticDataProvider;
            _instantiator = instantiator;
            _achievementsUIFactory = achievementsUIFactory;
            _overviewUIFactory = overviewUIFactory;
            _windowManager = windowManager;
            _profileController = profileController;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public void Create()
        {
            var mainView = CreateMainView();
            var viewsRoot = mainView.transform;
            var achievementsView = _achievementsUIFactory.CreateView(viewsRoot);
            var overviewView = _overviewUIFactory.CreateView(viewsRoot);

            _profileController.Initialize(mainView, achievementsView, overviewView, _windowManager);
            _windowManager.Initialize(achievementsView, overviewView);
        }

        private ProfileMainView CreateMainView()
        {
            var prefab = _config.MainViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<ProfileMainView>(prefab);

            return item;
        }
    }
}
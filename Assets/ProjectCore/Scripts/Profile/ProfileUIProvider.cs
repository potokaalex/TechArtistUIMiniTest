using ProjectCore.Scripts.Profile.Main;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileUIProvider
    {
        private ProfileMainController _mainController;

        public void Initialize(ProfileMainController mainController) => _mainController = mainController;

        public ProfileMainController GetMainController() => _mainController;
    }
}
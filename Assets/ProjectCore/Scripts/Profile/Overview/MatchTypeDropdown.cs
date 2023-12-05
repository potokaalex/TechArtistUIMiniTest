using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Utilities.UI;
using Zenject;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class MatchTypeDropdown : DropdownBase
    {
        private ProfileUIProvider _profileUIProvider;
        private ProfileMainController _mainController;

        [Inject]
        public void Construct(ProfileUIProvider profileUIProvider) => _profileUIProvider = profileUIProvider;

        public void Initialize() => _mainController = _profileUIProvider.GetMainController();

        private protected override void OnValueChanged(int number) =>
            _mainController.SetOverviewMatchesFilter((MatchType)number);
    }
}
using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Utilities.UI;
using Zenject;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class MatchTypeDropdown : DropdownBase
    {
        private ProfileController _profileController;

        [Inject]
        public void Construct(ProfileController controller) => _profileController = controller;

        private protected override void OnValueChanged(int number) =>
            _profileController.SetOverviewMatchesFilter((MatchType)number);
    }
}
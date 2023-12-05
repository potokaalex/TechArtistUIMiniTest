using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Utilities.UI;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ProfileOverviewMatchTypeDropdown : DropdownBase
    {
        private ProfileController _profileController;

        public void Initialize(ProfileController profileController) => _profileController = profileController;

        private protected override void OnValueChanged(int number) =>
            _profileController.SetOverviewMatchesFilter((MatchType)number);
    }
}
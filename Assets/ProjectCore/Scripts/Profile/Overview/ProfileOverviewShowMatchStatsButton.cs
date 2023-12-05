using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Utilities.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ProfileOverviewShowMatchStatsButton : ButtonBase
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _subHeaderText;
        private ProfileController _profileController;
        private MatchData _stats;

        public void Initialize(MatchData stats, Sprite icon, ProfileController profileController)
        {
            _stats = stats;
            _profileController = profileController;

            _iconImage.sprite = icon;
            _headerText.text = _stats.MatchType.ToString();
            _subHeaderText.text = "battle";
        }

        private protected override void OnClick() => _profileController.SetMatchParameters(_stats.Parameters);
    }
}
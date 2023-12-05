using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Project.AssetProvider;
using ProjectCore.Scripts.Utilities.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ShowMatchStatsButton : ButtonBase
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _subHeaderText;
        private IAssetProvider _assetProvider;
        private MatchData _stats;
        private ProfileOverviewView _overviewView;

        [Inject]
        public void Construct(IAssetProvider assetProvider, MatchData stats, ProfileOverviewView overviewView)
        {
            _assetProvider = assetProvider;
            _stats = stats;
            _overviewView = overviewView;
        }

        public void Initialize()
        {
            _iconImage.sprite = _assetProvider.Get<Sprite>(_stats.Icon);
            _headerText.text = _stats.MatchType.ToString();
            _subHeaderText.text = "battle";
        }

        private protected override void OnClick() => _overviewView.SetMatchParameters(_stats.Parameters);
    }
}
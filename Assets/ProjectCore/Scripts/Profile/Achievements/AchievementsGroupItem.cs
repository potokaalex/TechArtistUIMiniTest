using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Project.AssetProvider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectCore.Scripts.Profile.Achievements
{
    public class AchievementsGroupItem : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _subHeaderText;
        private ProfileStaticDataProvider _staticDataProvider;

        [Inject]
        public void Construct(ProfileStaticDataProvider staticDataProvider) => _staticDataProvider = staticDataProvider;

        public void Initialize(AchievementData data)
        {
            _iconImage.sprite = _staticDataProvider.GetIcon(data.Icon);
            _headerText.text = data.Name;
            _subHeaderText.text = "completed on: " + data.CompletedOn.Date.ToString("dd/MM/yyyy");
        }
    }
}
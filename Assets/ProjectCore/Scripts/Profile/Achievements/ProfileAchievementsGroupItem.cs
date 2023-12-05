using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Project.AssetProvider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectCore.Scripts.Profile.Achievements
{
    public class ProfileAchievementsGroupItem : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _subHeaderText;

        public void Initialize(AchievementData data, Sprite icon)
        {
            _iconImage.sprite = icon;
            _headerText.text = data.Name;
            _subHeaderText.text = "completed on: " + data.CompletedOn.Date.ToString("dd/MM/yyyy");
        }
    }
}
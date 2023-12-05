using System.Text.RegularExpressions;
using ProjectCore.Scripts.Data;
using ProjectCore.Scripts.Project.AssetProvider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectCore.Scripts.Profile.Main
{
    public class ProfileMainView : MonoBehaviour
    {
        [SerializeField] private Image _avatarImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _experienceText;
        [SerializeField] private Slider _experienceSlider;
        [SerializeField] private ProfileSwitchWindowButton[] _windowSwitchButtons;

        private IAssetProvider _assetProvider;

        [Inject]
        public void Construct(IAssetProvider assetProvider) => _assetProvider = assetProvider;

        public void Initialize(AccountData data)
        {
            SetAvatarIcon(_assetProvider.Get<Sprite>(data.AvatarIcon));
            SetName(data.Name);
            SetLevel(data.Level);
            SetExperience(data.Experience, data.ExperienceMax);

            foreach (var button in _windowSwitchButtons)
                button.Initialize();
        }

        private void SetAvatarIcon(Sprite avatarIcon) => _avatarImage.sprite = avatarIcon;

        private void SetName(string accountName)
        {
            var pattern = @"\d+$";
            var regex = new Regex(pattern);
            var match = regex.Match(accountName);
            var lastNumbers = match.Value;
            var nameWithoutLastNumbers = accountName.Remove(accountName.Length - lastNumbers.Length);

            _nameText.text = $"#{nameWithoutLastNumbers}-{lastNumbers}";
        }

        private void SetLevel(int levelNumber) => _levelText.text = $"Level {levelNumber}:";

        private void SetExperience(int current, int max)
        {
            _experienceText.text = $"{current}/{max}";
            _experienceSlider.value = (float)current / max;
        }
    }
}
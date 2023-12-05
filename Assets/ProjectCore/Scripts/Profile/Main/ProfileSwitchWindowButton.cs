using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Utilities.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectCore.Scripts.Profile.Main
{
    public class ProfileSwitchWindowButton : ButtonBase
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Image _selectableLines;
        [SerializeField] private ProfileWindowType _type;

        private ProfileConfigProvider _configProvider;
        private ProfileConfig _config;
        private ProfileUIWindowManager _windowManager;

        [Inject]
        public void Construct(ProfileConfigProvider configProvider, ProfileUIWindowManager windowManager)
        {
            _configProvider = configProvider;
            _windowManager = windowManager;
        }

        public void Initialize()
        {
            _config = _configProvider.GetConfig();
            Disable();
        }

        private protected override void OnClick()
        {
            if (_windowManager.IsCurrentWindow(_type))
                _windowManager.CloseCurrentWindow();
            else
            {
                _windowManager.OpenWindow(_type);
                _windowManager.OnWindowClosed += Disable;
                Enable();
            }
        }

        private void Enable()
        {
            _selectableLines.gameObject.SetActive(true);
            _buttonText.fontMaterial = _config.TextSelectMaterial;
        }

        private void Disable()
        {
            _windowManager.OnWindowClosed -= Disable;
            _selectableLines.gameObject.SetActive(false);
            _buttonText.fontMaterial = _config.TextHideMaterial;
        }
    }
}
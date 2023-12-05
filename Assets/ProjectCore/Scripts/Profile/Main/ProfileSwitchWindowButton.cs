using ProjectCore.Scripts.Utilities.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.Scripts.Profile.Main
{
    public class ProfileSwitchWindowButton : ButtonBase
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Image _selectableLines;
        [SerializeField] private ProfileWindowType _type;
        [SerializeField] private Material _textHideMaterial;
        [SerializeField] private Material _textSelectMaterial;
        private ProfileController _profileController;

        public void Initialize(ProfileController profileController)
        {
            _profileController = profileController;
            Disable();
        }

        private protected override void OnClick()
        {
            if (_profileController.IsCurrentWindow(_type))
                _profileController.CloseCurrentWindow();
            else
            {
                _profileController.OpenWindow(_type);
                _profileController.OnWindowClosedEvent += Disable;
                Enable();
            }
        }

        private void Enable()
        {
            _selectableLines.gameObject.SetActive(true);
            _buttonText.fontMaterial = _textSelectMaterial;
        }

        private void Disable()
        {
            _profileController.OnWindowClosedEvent -= Disable;
            _selectableLines.gameObject.SetActive(false);
            _buttonText.fontMaterial = _textHideMaterial;
        }
    }
}
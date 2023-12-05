using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.Scripts.Utilities.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBase : MonoBehaviour
    {
        private Button _selectableButton;

        private protected virtual void OnEnable()
        {
            _selectableButton = GetComponent<Button>();
            _selectableButton.onClick.AddListener(OnClick);
        }

        private protected abstract void OnClick();

        private protected void OnDisable() => _selectableButton.onClick.RemoveListener(OnClick);
    }
}
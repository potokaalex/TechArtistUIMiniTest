using TMPro;
using UnityEngine;

namespace ProjectCore.Scripts.Utilities.UI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public abstract class DropdownBase : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;

        private protected virtual void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnEnable() => _dropdown.onValueChanged.AddListener(OnValueChanged);

        private void OnDisable() => _dropdown.onValueChanged.RemoveListener(OnValueChanged);

        private protected abstract void OnValueChanged(int elementNumber);
    }
}
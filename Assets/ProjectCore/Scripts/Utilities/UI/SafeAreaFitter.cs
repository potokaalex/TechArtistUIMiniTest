using UnityEngine;

namespace ProjectCore.Scripts.Utilities.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake() => _rectTransform = GetComponent<RectTransform>();

        private void Start() => Fit();

#if UNITY_EDITOR
        private void FixedUpdate() => Fit();
#endif

        [ContextMenu("Fit")]
        private void Fit()
        {
            if (!Application.isPlaying)
                return;

            var safeArea = Screen.safeArea;
            var screenSize = new Vector2(Screen.width, Screen.height);
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;

            _rectTransform.anchorMin = anchorMin / screenSize;
            _rectTransform.anchorMax = anchorMax / screenSize;
        }
    }
}
using ProjectCore.Scripts.Data.Matching;
using TMPro;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class MatchParameterBlock : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _subHeaderText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private MatchParameter _parameter;

        [Inject]
        public void Construct(MatchParameter parameter) => _parameter = parameter;

        public void Initialize()
        {
            _headerText.text = _parameter.Header;
            _subHeaderText.text = _parameter.SubHeader;
            _scoreText.text = $"{_parameter.Score} PT.";
        }
    }
}
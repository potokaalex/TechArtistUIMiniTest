using ProjectCore.Scripts.Data.Matching;
using TMPro;
using UnityEngine;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ProfileOverviewMatchParameterBlock : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _subHeaderText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        public void Initialize(MatchParameter parameter)
        {
            _headerText.text = parameter.Header;
            _subHeaderText.text = parameter.SubHeader;
            _scoreText.text = $"{parameter.Score} PT.";
        }
    }
}
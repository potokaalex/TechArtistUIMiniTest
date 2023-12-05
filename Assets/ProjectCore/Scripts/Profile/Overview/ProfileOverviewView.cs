using System;
using System.Collections.Generic;
using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Utilities.UI;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ProfileOverviewView : WindowBase
    {
        [SerializeField] private Transform _showMatchButtonsRoot;
        [SerializeField] private Transform _matchParametersRoot;
        [SerializeField] private MatchTypeDropdown _dropdown;

        private readonly List<MatchParameterBlock> _currentMatchParameterBlocks = new();
        private readonly List<ShowMatchStatsButton> _currentStatsMatchShowButtons = new();

        private ProfileOverviewUIFactory _profileUIFactory;

        [Inject]
        public void Construct(ProfileOverviewUIFactory profileUIFactory) => _profileUIFactory = profileUIFactory;

        public void Initialize(MatchData[] matches)
        {
            SetMatches(matches);
            Close();
            _dropdown.Initialize();
        }

        public override void Open()
        {
            base.Open();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            gameObject.SetActive(false);
        }

        public void SetMatches(MatchData[] matches)
        {
            DestroyCurrentStatsShowButton();

            var showCount = matches.Length < 3 ? matches.Length : 3;

            for (var i = 0; i < showCount; i++)
            {
                var button = _profileUIFactory.CreateMatchStatsShowButton(matches[i], _showMatchButtonsRoot, this);
                _currentStatsMatchShowButtons.Add(button);
            }

            SetMatchParameters(matches.Length > 0 ? matches[0].Parameters : Array.Empty<MatchParameter>());
        }

        public void SetMatchParameters(MatchParameter[] parameters)
        {
            DestroyCurrentMatchParameters();

            foreach (var parameter in parameters)
            {
                var block = _profileUIFactory.CreateMatchParameterBlock(parameter, _matchParametersRoot);
                _currentMatchParameterBlocks.Add(block);
            }
        }

        private void DestroyCurrentMatchParameters()
        {
            foreach (var oldBlock in _currentMatchParameterBlocks)
                _profileUIFactory.DestroyMatchParameterBlock(oldBlock);

            _currentMatchParameterBlocks.Clear();
        }

        private void DestroyCurrentStatsShowButton()
        {
            foreach (var oldButton in _currentStatsMatchShowButtons)
                _profileUIFactory.DestroyMatchStatsShowButton(oldButton);

            _currentStatsMatchShowButtons.Clear();
        }
    }
}
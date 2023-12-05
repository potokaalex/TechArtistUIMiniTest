using System;
using System.Collections.Generic;
using ProjectCore.Scripts.Data.Matching;
using ProjectCore.Scripts.Utilities.UI;
using UnityEngine;

namespace ProjectCore.Scripts.Profile.Overview
{
    public class ProfileOverviewView : WindowBase
    {
        [SerializeField] private ProfileOverviewMatchTypeDropdown _dropdown;
        [SerializeField] private Transform _showMatchButtonsRoot;
        [SerializeField] private Transform _matchParametersRoot;

        private readonly List<ProfileOverviewShowMatchStatsButton> _currentStatsMatchShowButtons = new();
        private readonly List<ProfileOverviewMatchParameterBlock> _currentMatchParameterBlocks = new();
        private ProfileController _profileController;

        public void Initialize(MatchData[] matches, ProfileController profileController)
        {
            _profileController = profileController;

            SetMatches(matches);
            Close();
            _dropdown.Initialize(profileController);
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
                var button = _profileController.CreateMatchStatsShowButton(matches[i], _showMatchButtonsRoot);
                _currentStatsMatchShowButtons.Add(button);
            }

            SetMatchParameters(matches.Length > 0 ? matches[0].Parameters : Array.Empty<MatchParameter>());
        }

        public void SetMatchParameters(MatchParameter[] parameters)
        {
            DestroyCurrentMatchParameters();

            foreach (var parameter in parameters)
            {
                var block = _profileController.CreateMatchParameterBlock(parameter, _matchParametersRoot);
                _currentMatchParameterBlocks.Add(block);
            }
        }

        private void DestroyCurrentMatchParameters()
        {
            foreach (var oldBlock in _currentMatchParameterBlocks)
                _profileController.DestroyMatchParameterBlock(oldBlock);

            _currentMatchParameterBlocks.Clear();
        }

        private void DestroyCurrentStatsShowButton()
        {
            foreach (var oldButton in _currentStatsMatchShowButtons)
                _profileController.DestroyMatchStatsShowButton(oldButton);

            _currentStatsMatchShowButtons.Clear();
        }
    }
}
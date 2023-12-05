using System;
using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using ProjectCore.Scripts.Utilities.UI;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileUIWindowManager
    {
        private readonly ProfileController _controller;
        private WindowBase _achievementsWindow;
        private WindowBase _overviewWindow;
        
        private ProfileWindowType _currentWindowType;
        private WindowBase _currentWindow;

        public ProfileUIWindowManager(ProfileController controller) => _controller = controller;

        public void Initialize(ProfileAchievementsView achievementsView, ProfileOverviewView overviewView)
        {
            _achievementsWindow = achievementsView;
            _overviewWindow = overviewView;
        }

        public bool IsCurrentWindow(ProfileWindowType type) => _currentWindowType == type;

        public void OpenWindow(ProfileWindowType type)
        {
            switch (type)
            {
                case ProfileWindowType.Achievements:
                    SwitchWindowTo(_achievementsWindow);
                    break;
                case ProfileWindowType.Overview:
                    SwitchWindowTo(_overviewWindow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            _currentWindowType = type;
        }

        public void CloseCurrentWindow()
        {
            CloseWindow();
            _currentWindowType = ProfileWindowType.None;
        }

        private void CloseWindow()
        {
            _currentWindow?.Close();
            _controller.OnCurrentWindowClosed();
        }

        private void SwitchWindowTo(WindowBase window)
        {
            CloseWindow();
            _currentWindow = window;
            _currentWindow.Open();
        }
    }
}
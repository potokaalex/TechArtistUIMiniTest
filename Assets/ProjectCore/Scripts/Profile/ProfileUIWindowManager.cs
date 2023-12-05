using System;
using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Main;
using ProjectCore.Scripts.Profile.Overview;
using ProjectCore.Scripts.Utilities.UI;

namespace ProjectCore.Scripts.Profile
{
    public class ProfileUIWindowManager
    {
        private ProfileWindowType _currentWindowType;
        private WindowBase _currentWindow;

        private WindowBase _achievementsWindow;
        private WindowBase _overviewWindow;

        public event Action OnWindowClosed;

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
        }

        public void CloseCurrentWindow()
        {
            CloseWindow();
            _currentWindowType = ProfileWindowType.None;
        }

        private void CloseWindow()
        {
            _currentWindow?.Close();
            OnWindowClosed?.Invoke();
        }

        private void SwitchWindowTo(WindowBase window)
        {
            CloseWindow();
            _currentWindow = window;
            _currentWindow.Open();
        }
    }
}
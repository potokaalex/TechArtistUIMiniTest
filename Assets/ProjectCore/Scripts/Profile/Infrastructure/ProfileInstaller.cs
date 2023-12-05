using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Profile.Overview;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Infrastructure
{
    public class ProfileInstaller : MonoInstaller
    {
        [SerializeField] private ProfileConfigProvider _profileConfigProvider;

        public override void InstallBindings()
        {
            BindFactories();

            Container.Bind<ProfileModel>().AsSingle();
            Container.Bind<ProfileUIWindowManager>().AsSingle();
            Container.Bind<ProfileConfigProvider>().FromInstance(_profileConfigProvider).AsSingle();
            Container.Bind<ProfileUIProvider>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<ProfileUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProfileAchievementsUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProfileOverviewUIFactory>().AsSingle();
        }
    }
}
using ProjectCore.Scripts.Profile.Achievements;
using ProjectCore.Scripts.Profile.Infrastructure.Data;
using ProjectCore.Scripts.Profile.Overview;
using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Infrastructure
{
    public class ProfileInstaller : MonoInstaller
    {
        [SerializeField] private ProfileConfig _config;

        public override void InstallBindings()
        {
            BindFactories();

            Container.Bind<ProfileModel>().AsSingle();
            Container.Bind<ProfileController>().AsSingle();
            Container.Bind<ProfileUIWindowManager>().AsSingle();
            Container.Bind<ProfileStaticDataProvider>().AsSingle().WithArguments(_config);
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<ProfileUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProfileAchievementsUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProfileOverviewUIFactory>().AsSingle();
        }
    }
}
using ProjectCore.Scripts.Project.AssetProvider;
using Zenject;

namespace ProjectCore.Scripts.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container.Bind<IAssetProvider>().To<AssetProvider.AssetProvider>().AsSingle();
    }
}
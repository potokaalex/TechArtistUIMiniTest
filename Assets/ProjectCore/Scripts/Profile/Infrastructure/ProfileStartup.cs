using UnityEngine;
using Zenject;

namespace ProjectCore.Scripts.Profile.Infrastructure
{
    public class ProfileStartup : MonoBehaviour
    {
        private ProfileUIFactory _profileUIFactory;

        [Inject]
        public void Construct(ProfileUIFactory profileUIFactory) => _profileUIFactory = profileUIFactory;

        private void Start() => _profileUIFactory.Create();
    }
}
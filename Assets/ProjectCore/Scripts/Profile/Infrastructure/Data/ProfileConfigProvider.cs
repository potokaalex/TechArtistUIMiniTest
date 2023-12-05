using System;
using UnityEngine;

namespace ProjectCore.Scripts.Profile.Infrastructure.Data
{
    [Serializable]
    public class ProfileConfigProvider
    {
        [SerializeField] private ProfileConfig _config;

        public ProfileConfig GetConfig() => _config;
    }
}
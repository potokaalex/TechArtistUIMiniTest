using UnityEngine;

namespace ProjectCore.Scripts.Utilities.UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        public bool IsOpened { get; private set; }

        public virtual void Open() => IsOpened = true;

        public virtual void Close() => IsOpened = false;
    }
}
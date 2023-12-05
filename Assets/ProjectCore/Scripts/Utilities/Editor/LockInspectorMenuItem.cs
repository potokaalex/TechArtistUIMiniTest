using UnityEditor;

namespace ProjectCore.Scripts.Utilities.Editor
{
    public static class LockInspectorMenuItem
    {
        // taken from: http://answers.unity3d.com/questions/282959/set-inspector-lock-by-code.html
        [MenuItem("Tools/Toggle Inspector Lock #a")] // Shift + a
        private static void ToggleInspectorLock()
        {
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }
    }
}
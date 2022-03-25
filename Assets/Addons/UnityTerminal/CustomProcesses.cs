#if UNITY_EDITOR

using System;
using System.Threading.Tasks;
using UnityEditor;

namespace UnityTerminal
{
    /// <summary>
    /// You can add your custom Command Prompt Processes here with a MenuItem Attribute.<br/>
    ///<br/>
    /// For simple processes use the ProcessUtilities.StartProcess(Filename, (optional) runAsAdmin)<br/>
    /// <br/>
    /// For advanced processes use the ProcessUtilities.StartAdvProcess(Filename, (optional) arguments, (optional) hideWindow, (optional) runAsAdmin)<br/>
    ///<br/>
    /// </summary>
    public static class CustomProcesses
    {
        #region PYTHON

        [MenuItem("Window/Python/Python Shell")]
        public static async Task OpenPythonShell()
        {
            await Task.Run(() => ProcessUtilities.StartProcess("python", true));
        }

        [MenuItem("Window/Python/IDLE")]
        public static async Task OpenPythonIdle()
        {
            await Task.Run(() => ProcessUtilities.StartAdvProcess("python", @"-m idlelib", true));
        }

        #endregion

        #region PERSONAL

        [MenuItem("Window/Personal/Resources %#O")]
        public static async Task OpenResourcesFolder()
        {
            await Task.Run(() =>
            {
                ProcessUtilities.StartAdvProcess("explorer.exe", @"E:\Pictures\Resources");
            });
        }

        #endregion
    }
}

#endif
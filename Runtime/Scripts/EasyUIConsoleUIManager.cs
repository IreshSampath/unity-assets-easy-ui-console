using UnityEngine;

namespace GAG.EasyUIConsole
{
    public class EasyUIConsoleUIManager : MonoBehaviour
    {
        void Start()
        {
            EasyUIConsoleManager.Instance.EasyMessage("Sample Message");
            EasyUIConsoleManager.Instance.EasyInfo("Sample Info Message");
            EasyUIConsoleManager.Instance.EasyWarning("Sample Warning Message");
            EasyUIConsoleManager.Instance.EasyError("Sample Error Message");
        }
    }
}
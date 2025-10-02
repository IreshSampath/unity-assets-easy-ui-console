using UnityEngine;

namespace GAG.EasyUIConsole
{
    public class EasyUIConsoleUIManager : MonoBehaviour
    {
        void Start()
        {
            EasyUIConsoleManager.Instance.EasyLog("Sample Log Message");
            EasyUIConsoleManager.Instance.EasyHiglight("Sample Higlight Message");
            EasyUIConsoleManager.Instance.EasyWarning("Sample Warning Message");
            EasyUIConsoleManager.Instance.EasyError("Sample Error Message");
        }
    }
}
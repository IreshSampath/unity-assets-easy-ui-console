using GAG.EasyUIConsole;
using UnityEngine;

public class EasyUIConsoleDemo: MonoBehaviour
{
    void Start()
    {
        EasyUIC.Log("Sample Log Message");
        EasyUIC.Highlight("Sample Highlight Message");
        EasyUIC.Warning("Sample Warning Message");
        EasyUIC.Error("Sample Error Message");
        
        EasyUIC.Print("Sample Log Print Message", EasyUIConsoleType.Log);
        EasyUIC.Print("Sample Highlight Print Message", EasyUIConsoleType.Highlight);
        EasyUIC.Print("Sample Warning Print Message", EasyUIConsoleType.Warning);
        EasyUIC.Print("Sample Error Print Message", EasyUIConsoleType.Error);
    }
}

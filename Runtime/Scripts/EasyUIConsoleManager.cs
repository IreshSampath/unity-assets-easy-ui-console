using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GAG.EasyUIConsole
{
    public class EasyUIConsoleManager : MonoBehaviour
    {
        enum ConsoleType
        {
            Info,
            Warning,
            Error,
            Other
        }

        [SerializeField] ConsoleType _consoleType = ConsoleType.Info;
        [SerializeField] TMP_Text _consoleText;
        [SerializeField] TMP_InputField _maxLineNumberInputField;
        [SerializeField] TMP_InputField _testLoginputField;
        [SerializeField] TMP_Dropdown _consoleTypeDropdown;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _maxLineNumberInputField.text = "50"; // Default max line number
            _consoleTypeDropdown.AddOptions(new List<string>
        {
            ConsoleType.Info.ToString(),
            ConsoleType.Warning.ToString(),
            ConsoleType.Error.ToString(),
            ConsoleType.Other.ToString()
        });
        }

        public void EasyLog(string consoleType)
        {
            if (string.IsNullOrEmpty(consoleType) || _testLoginputField == null) return;

            // Get the selected console type from the dropdown
            int selectedIndex = _consoleTypeDropdown.value;
            string selectedConsoleType = _consoleTypeDropdown.options[selectedIndex].text;

            // Parse the console type
            if (Enum.TryParse(selectedConsoleType, out ConsoleType parsedConsoleType))
            {
                PrintToConsole(_testLoginputField.text, parsedConsoleType);
            }
            else
            {
                EasyError($"Invalid console type: {selectedConsoleType}");
            }
        }

        public void EasyMessage(string message)
        {
            PrintToConsole(message, ConsoleType.Other);
        }

        public void EasyInfo(string message)
        {
            PrintToConsole(message, ConsoleType.Info);
        }

        public void EasyWarning(string message)
        {
            PrintToConsole(message, ConsoleType.Warning);
        }

        public void EasyError(string message)
        {
            PrintToConsole(message, ConsoleType.Error);
        }

        public void LimitLine(TMP_InputField inputTxt)
        {
            if (inputTxt == null) return;

            int maxLines = 50; // Default max line number
            if (int.TryParse(inputTxt.text, out int parsedMaxLines))
            {
                if (parsedMaxLines > 100)
                {
                    EasyWarning($"Max line number set to {100}. Max Line 50 is better for performance");
                }
                else
                {
                    EasyMessage($"Max line number set to {parsedMaxLines}.");
                }
                maxLines = parsedMaxLines;
            }
            else
            {
                EasyError("Invalid input for max line number.");
                _maxLineNumberInputField.text = "50";
                return;
            }
        }

        public void ClearLogs()
        {
            if (_consoleText != null)
            {
                _consoleText.text = string.Empty;
            }
        }

        void PrintToConsole(string message, ConsoleType consoleType = ConsoleType.Info)
        {
            if (string.IsNullOrEmpty(message) || _consoleText == null) return;

            // Get current timestamp
            string timestamp = DateTime.Now.ToString("[HH:mm:ss]");

            // Choose color based on ConsoleType
            string colorTag = consoleType switch
            {
                ConsoleType.Info => "<color=white>",
                ConsoleType.Warning => "<color=yellow>",
                ConsoleType.Error => "<color=red>",
                ConsoleType.Other => "<color=green>",
                _ => "<color=white>"
            };

            // Format the message
            string coloredMessage = $"{colorTag}{message}</color>";

            // Append the new message at the top
            _consoleText.text = coloredMessage + "\n" + _consoleText.text;

            // Limit the number of lines to avoid performance issues
            var lines = _consoleText.text.Split('\n');
            if (lines.Length > 50) // Keep only the latest 50 lines
            {
                _consoleText.text = string.Join("\n", lines, 0, 50);
            }
        }

    }
}

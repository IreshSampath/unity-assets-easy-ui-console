using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GAG.EasyUIConsole
{
    public class EasyUIConsoleManager : MonoBehaviour
    {
        public static EasyUIConsoleManager Instance;

        enum ConsoleType
        {
            Log,
            Higlight,
            Warning,
            Error
        }

        [SerializeField] ConsoleType _consoleType = ConsoleType.Log;
        [SerializeField] TMP_Text _consoleText;
        [SerializeField] TMP_InputField _maxLineNumberInputField;
        [SerializeField] TMP_InputField _testLoginputField;
        [SerializeField] TMP_Dropdown _consoleTypeDropdown;

        [SerializeField] int _maxLines = 50; // Default max line number
        int _currentLineCount = 1;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            _consoleTypeDropdown.AddOptions(new List<string>
            {
                ConsoleType.Log.ToString(),
                ConsoleType.Higlight.ToString(),
                ConsoleType.Warning.ToString(),
                ConsoleType.Error.ToString()
            });

            _maxLineNumberInputField.text = _maxLines.ToString(); // Default max line number
        }

        public void DevLog(string consoleType)
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

        public void EasyLog(string message)
        {
            PrintToConsole(message, ConsoleType.Log);
        }

        public void EasyHiglight(string message)
        {
            PrintToConsole(message, ConsoleType.Higlight);
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

            if (int.TryParse(inputTxt.text, out int parsedMaxLines))
            {
                EasyHiglight(parsedMaxLines.ToString());
                if (parsedMaxLines > 100)
                {
                    EasyWarning($"Max line number set to {100}. Max Line 50 is better for performance");
                }
                else
                {
                    EasyHiglight($"Max line number set to {parsedMaxLines}.");
                }
                _maxLines = parsedMaxLines;
            }
            else
            {
                EasyError("Invalid input for max line number.");
                _maxLineNumberInputField.text = _maxLines.ToString();
            }
        }

        public void ClearLogs()
        {
            if (_consoleText != null)
            {
                _consoleText.text = string.Empty;
            }
        }

        void PrintToConsole(string message, ConsoleType consoleType = ConsoleType.Log)
        {
            if (string.IsNullOrEmpty(message) || _consoleText == null) return;

            // Choose color based on ConsoleType
            string colorTag = consoleType switch
            {
                ConsoleType.Log => "<color=white>",
                ConsoleType.Higlight => "<color=green>",
                ConsoleType.Warning => "<color=yellow>",
                ConsoleType.Error => "<color=red>",
                _ => "<color=white>"
            };

            // Get current timestamp
            string timestamp = DateTime.Now.ToString("[mm:ss]");

            // Format the message
            string coloredMessage = $"{_currentLineCount:D2} {colorTag}{timestamp}  {message}</color>";

            // Append the new message at the top
            _consoleText.text = coloredMessage + "\n" + _consoleText.text;

            // Limit the number of lines to avoid performance issues
            var lines = _consoleText.text.Split('\n');

            _currentLineCount++;
            if(_currentLineCount > _maxLines)
            {
                _currentLineCount = 1;
            }

            if (lines.Length > _maxLines) // Keep only the latest _maxLines
            {
                _consoleText.text = string.Join("\n", lines, 0, _maxLines);
            }
        }
    }
}

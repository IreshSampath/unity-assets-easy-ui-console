using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace GAG.EasyUIConsole
{
    public class EasyUIConsoleHandler : MonoBehaviour
    {
        [SerializeField] GameObject _panelConsole;
        [FormerlySerializedAs("_consoleType")] [SerializeField] EasyUIConsoleType easyUIConsoleType = EasyUIConsoleType.Log;
        [SerializeField] TMP_Text _consoleText;
        [SerializeField] TMP_InputField _maxLineNumberInputField;
        [SerializeField] TMP_InputField _testLoginputField;
        [SerializeField] TMP_Dropdown _consoleTypeDropdown;
        
        [SerializeField] int _maxLines = 50; // Default max line number
        int _currentLineCount = 1;
        
        List<string> _lines = new();
        
        void OnEnable()
        {
            EasyUIConsoleEvents.ConsoleOpened += OpenConsole;
            EasyUIConsoleEvents.LogPrintRequested += EasyLog;
            EasyUIConsoleEvents.HighlightPrintRequested += EasyHighlight;
            EasyUIConsoleEvents.WarningPrintRequested += EasyWarning;
            EasyUIConsoleEvents.ErrorPrintRequested += EasyError;
        }
        
        void OnDisable()
        {
            EasyUIConsoleEvents.ConsoleOpened -= OpenConsole;
            EasyUIConsoleEvents.LogPrintRequested -= EasyLog;
            EasyUIConsoleEvents.HighlightPrintRequested -= EasyHighlight;
            EasyUIConsoleEvents.WarningPrintRequested -= EasyWarning;
            EasyUIConsoleEvents.ErrorPrintRequested -= EasyError;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _consoleTypeDropdown.AddOptions(new List<string>
            {
                EasyUIConsoleType.Log.ToString(),
                EasyUIConsoleType.Highlight.ToString(),
                EasyUIConsoleType.Warning.ToString(),
                EasyUIConsoleType.Error.ToString()
            });

            _maxLineNumberInputField.text = _maxLines.ToString(); // Default max line number
        }

        public void OpenConsole()
        {
            if (_panelConsole == null)
            {
                Debug.LogWarning("Panel Console reference missing");
                return;
            }

            _panelConsole.SetActive(true);
        }
        
        public void DevLog(string consoleType)
        {
            if (string.IsNullOrEmpty(consoleType) || _testLoginputField == null) return;

            // Get the selected console type from the dropdown
            int selectedIndex = _consoleTypeDropdown.value;
            string selectedConsoleType = _consoleTypeDropdown.options[selectedIndex].text;

            // Parse the console type
            if (Enum.TryParse(selectedConsoleType, out EasyUIConsoleType parsedConsoleType))
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
            PrintToConsole(message, EasyUIConsoleType.Log);
        }

        public void EasyHighlight(string message)
        {
            PrintToConsole(message, EasyUIConsoleType.Highlight);
        }

        public void EasyWarning(string message)
        {
            PrintToConsole(message, EasyUIConsoleType.Warning);
        }

        public void EasyError(string message)
        {
            PrintToConsole(message, EasyUIConsoleType.Error);
        }

        public void LimitLine(TMP_InputField inputTxt)
        {
            if (inputTxt == null) return;

            if (int.TryParse(inputTxt.text, out int parsedMaxLines))
            {
                EasyHighlight(parsedMaxLines.ToString());
                if (parsedMaxLines > 100)
                {
                    EasyWarning($"Max line number set to {100}. Max Line 50 is better for performance");
                }
                else
                {
                    EasyHighlight($"Max line number set to {parsedMaxLines}.");
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
                _lines.Clear();
            }
        }

        void PrintToConsole(string message, EasyUIConsoleType easyUIConsoleType = EasyUIConsoleType.Log)
        {
            if (string.IsNullOrEmpty(message) || _consoleText == null) return;

            // Choose color based on EasyUIConsoleType
            string colorTag = easyUIConsoleType switch
            {
                EasyUIConsoleType.Log => "<color=white>",
                EasyUIConsoleType.Highlight => "<color=green>",
                EasyUIConsoleType.Warning => "<color=yellow>",
                EasyUIConsoleType.Error => "<color=red>",
                _ => "<color=white>"
            };

            // Get current timestamp
            // string timestamp = DateTime.Now.ToString("[mm:ss.fff]");
            string timestamp = $"[{Time.realtimeSinceStartup:F2}]";
            
            // Format the message
            string coloredMessage = $"{_currentLineCount:D2} {colorTag}{timestamp}  {message}</color>";

            // Append the new message at the top
            //_consoleText.text = coloredMessage + "\n" + _consoleText.text;
            _lines.Insert(0, coloredMessage);

            if (_lines.Count > _maxLines)
                _lines.RemoveAt(_lines.Count - 1);

            _consoleText.text = string.Join("\n", _lines);

            // // Limit the number of lines to avoid performance issues
            // var lines = _consoleText.text.Split('\n');

            _currentLineCount++;
            if(_currentLineCount > _maxLines)
            {
                _currentLineCount = 1;
            }

            // if (lines.Length > _maxLines) // Keep only the latest _maxLines
            // {
            //     _consoleText.text = string.Join("\n", lines, 0, _maxLines);
            // }
        }
    }
}

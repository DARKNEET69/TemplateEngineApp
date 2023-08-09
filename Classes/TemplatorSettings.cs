using System.ComponentModel;

namespace TemplateEngineApp
{
    internal class TemplatorSettings
    {
        public delegate void SettingsEventHandler(string propertyName, object newValue, object oldValue);
        public static event SettingsEventHandler? OnSettingChanging;
        public static readonly string SettingsFileName = "settings.json";

        private List<string> _extensionsOfEditableFiles = new List<string>() { ".html" };
        private bool _needToRemoveWhiteSpaces = false;
        private string _appFolderName = "app";
        private string _workspaceFolderName = "workspace";
        private string _templatesFolderName = "templates";
        private string _inlineTemplateStart = "[[";
        private string _inlineTemplateEnd = "]]";
        private string _inlineParameterStart = "{{";
        private string _inlineParameterEnd = "}}";
        //private string _inlineLoopStart = "[{";
        //private string _inlineLoopEnd = "}]";

        [Category("Main"), Description("The name of the folder where the working project will be saved")]
        public string AppFolderName
        {
            get
            {
                return _appFolderName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == _appFolderName) return;

                OnSettingChanging?.Invoke("AppFolderName", value, _appFolderName);
                _appFolderName = value;
            }
        }

        [Category("Main"), Description("The name of the folder where the working files containing templates will be stored")]
        public string WorkspaceFolderName
        {
            get
            {
                return _workspaceFolderName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == _workspaceFolderName) return;

                OnSettingChanging?.Invoke("WorkspaceFolderName", value, _workspaceFolderName);
                _workspaceFolderName = value;
            }
        }

        [Category("Main"), Description("The name of the folder where the templates will be stored")]
        public string TemplatesFolderName
        {
            get
            {
                return _templatesFolderName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == _templatesFolderName) return;

                OnSettingChanging?.Invoke("TemplatesFolderName", value, _templatesFolderName);
                _templatesFolderName = value;
            }
        }

        [Category("Main"), Description("List of file extensions that the template engine will work with")]
        public List<string> ExtensionsOfEditableFiles
        {
            get
            {
                return _extensionsOfEditableFiles;
            }
            set
            {
                if (value.Count == 0 || value == _extensionsOfEditableFiles) return;

                _extensionsOfEditableFiles = value;
            }
        }

        [Category("Main"), Description("If True, removes all spaces and line breaks in editable files")]
        public bool NeedToRemoveWhiteSpaces
        {
            get
            {
                return _needToRemoveWhiteSpaces;
            }
            set
            {
                if (value == _needToRemoveWhiteSpaces) return;

                _needToRemoveWhiteSpaces = value;
            }
        }

        [Category("Editable"), Description("Initial operand of the template inlining (min 2 symbols)")]
        public string InlineTemplateStart
        {
            get
            {
                return _inlineTemplateStart;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value == _inlineTemplateStart) return;

                _inlineTemplateStart = value;
            }
        }

        [Category("Editable"), Description("Final operand of the template inlining (min 2 symbols)")]
        public string InlineTemplateEnd
        {
            get
            {
                return _inlineTemplateEnd;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value == _inlineTemplateEnd) return;

                _inlineTemplateEnd = value;
            }
        }

        [Category("Editable"), Description("Initial operand of the parametr inlining (min 2 symbols)")]
        public string InlineParameterStart
        {
            get
            {
                return _inlineParameterStart;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value == _inlineParameterStart) return;

                _inlineParameterStart = value;
            }
        }

        [Category("Editable"), Description("Final operand of the parametr inlining (min 2 symbols)")]
        public string InlineParameterEnd
        {
            get
            {
                return _inlineParameterEnd;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value == _inlineParameterEnd) return;

                _inlineParameterEnd = value;
            }
        }

        [Category("Not editable"), Description("Separation operand for inline parameters")]
        public string InlineParameterSeparator { get; } = ",";

        [Category("Not editable"), Description("Assignment operand for inline parameters")]
        public string InlineParameterAssignment { get; } = "=";

        //[Category("Paid version"), Description("Initial operand of the loop inlining (min 2 symbols)")]
        //public string InlineLoopStart { get => _inlineLoopStart; }

        //[Category("Paid version"), Description("Final operand of the loop inlining (min 2 symbols)")]
        //public string InlineLoopEnd { get => _inlineLoopEnd; }

        //[Category("Not editable"), Description("Non-template value operand for inline parameters")]
        //public string InlineParameterValue { get; } = "\"";
    }
}

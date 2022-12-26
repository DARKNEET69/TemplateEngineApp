using System.ComponentModel;

namespace TemplateEngineApp
{
    internal class TemplateSettings
    {
        public static readonly string SettingsFileName = "TemplateSettings.json";
        public static readonly string WebsiteFolderName = "Website";
        public static readonly string WorkspaceFolderName = "Workspace";
        public static readonly string TemplatesFolderName = "Templates";

        private string _inlineTemplateStart = "[[";
        private string _inlineTemplateEnd = "]]";
        private string _inlineParameterStart = "{{";
        private string _inlineParameterEnd = "}}";
        private string _inlineLoopStart = "[{";
        private string _inlineLoopEnd = "}]";

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

        [Category("Paid version"), Description("Initial operand of the loop inlining (min 2 symbols)")]
        public string InlineLoopStart { get => _inlineLoopStart; }

        [Category("Paid version"), Description("Final operand of the loop inlining (min 2 symbols)")]
        public string InlineLoopEnd { get => _inlineLoopEnd; }

        [Category("Not editable"), Description("Separation operand for inline parameters")]
        public string InlineParameterSeparator { get; } = ",";

        [Category("Not editable"), Description("Assignment operand for inline parameters")]
        public string InlineParameterAssignment { get; } = "=";

        [Category("Not editable"), Description("Non-template value operand for inline parameters")]
        public string InlineParameterValue { get; } = "\"";
    }
}

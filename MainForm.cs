using System.Text.Json;

namespace TemplateEngineApp
{
    public partial class MainForm : Form
    {
        TemplatorSettings templatorSettings = new TemplatorSettings();
        private string projectFolderPath = string.Empty;
        private string oldAppFolderName = string.Empty;
        private string oldWorkspaceFolderName = string.Empty;
        private string oldTemplatesFolderName = string.Empty;
        private bool isProjectFoldersChanged = false;

        public MainForm()
        {
            InitializeComponent();
            Logger.OnLogged += DisplayLog;
            TemplatorSettings.OnSettingChanging += CheckChengedSettings;

            propertyGrid.Enabled = generateButton.Enabled = saveButton.Enabled = false;
            Logger.Info("TEA launched");
        }

        private void LoadProject(string projectFolderPath)
        {
            if (!Directory.Exists(projectFolderPath)) return;

            try
            {
                this.projectFolderPath = projectFolderPath;
                string settingsPath = $"{projectFolderPath}/{TemplatorSettings.SettingsFileName}";

                using (FileStream fileStream = new FileStream(settingsPath, FileMode.OpenOrCreate))
                {
                    TemplatorSettings? newTemplatorSettings = JsonSerializer.Deserialize<TemplatorSettings>(fileStream);
                    templatorSettings = newTemplatorSettings == null ? templatorSettings : newTemplatorSettings;
                    propertyGrid.SelectedObject = templatorSettings;
                    oldAppFolderName = templatorSettings.AppFolderName;
                    oldWorkspaceFolderName = templatorSettings.WorkspaceFolderName;
                    oldTemplatesFolderName = templatorSettings.TemplatesFolderName;
                }

                projectNameLabel.Text = Path.GetFileName(Path.GetDirectoryName(projectFolderPath + "/"));
                propertyGrid.Enabled = generateButton.Enabled = saveButton.Enabled = true;
                Logger.Info("Project settings loaded");
                CheckProjectFiles(projectFolderPath);
            }
            catch (Exception e)
            {
                Logger.Error($"Project settings not loaded: {e.Message}");
            }
        }

        private void CreateProject(string projectFolderPath)
        {
            if (!Directory.Exists(projectFolderPath)) return;

            try
            {
                templatorSettings = new TemplatorSettings();
                string settingsPath = $"{projectFolderPath}/{TemplatorSettings.SettingsFileName}";
                Directory.CreateDirectory($"{projectFolderPath}/{templatorSettings.AppFolderName}");
                Directory.CreateDirectory($"{projectFolderPath}/{templatorSettings.WorkspaceFolderName}");
                Directory.CreateDirectory($"{projectFolderPath}/{templatorSettings.TemplatesFolderName}");
                SaveSettings(projectFolderPath);
                Logger.Info("Project files have been created");
                LoadProject(projectFolderPath);
            }
            catch (Exception e)
            {
                Logger.Error($"Project files were not created: {e.Message}");
            }
        }

        private bool CheckProjectFiles(string projectFolderPath)
        {
            if (!Directory.Exists(projectFolderPath)) return false;

            Logger.Info("Checking project folder");

            if (Directory.Exists($"{projectFolderPath}/{templatorSettings.AppFolderName}") && 
                Directory.Exists($"{projectFolderPath}/{templatorSettings.WorkspaceFolderName}") &&
                Directory.Exists($"{projectFolderPath}/{templatorSettings.TemplatesFolderName}"))
            {
                Logger.Info("Folder contains project files");
                return true;
            }
            else
            {
                Logger.Warning("Folder does not contain project files");
                return false;
            }
        }

        private void SaveSettings(string path)
        {
            if (!Directory.Exists(path))
            {
                Logger.Warning($"Uncorrect path '{path}'");
                return;
            }

            try
            {
                if (isProjectFoldersChanged)
                {
                    RenameFolder(templatorSettings.AppFolderName, oldAppFolderName);
                    RenameFolder(templatorSettings.WorkspaceFolderName, oldWorkspaceFolderName);
                    RenameFolder(templatorSettings.TemplatesFolderName, oldTemplatesFolderName);
                }

                void RenameFolder(string newName, string oldName)
                {
                    var directory = new DirectoryInfo($"{projectFolderPath}/{oldName}");
                    directory.MoveTo($"{projectFolderPath}/_{oldName}_");
                    directory.MoveTo($"{projectFolderPath}/{newName}");
                }

                using (FileStream fileStream = new FileStream($"{path}/{TemplatorSettings.SettingsFileName}", FileMode.Create))
                {
                    JsonSerializer.Serialize<TemplatorSettings>(fileStream, templatorSettings, new JsonSerializerOptions() { WriteIndented = true });
                }

                Logger.Info("Settings save complete");
            }
            catch(Exception e)
            {
                Logger.Error("Settings save error: " + e.Message);
            }
        }

        private void CheckChengedSettings(string propertyName, object newValue, object oldValue)
        {
            string[] checkedProperties = { "AppFolderName", "WorkspaceFolderName", "TemplatesFolderName" };

            if (checkedProperties.Contains(propertyName)) isProjectFoldersChanged = true;
        }

        private void DisplayLog(string text, Logger.Type logType)
        {
            switch (logType)
            {
                case Logger.Type.Info:
                    consoleTextBox.SelectionColor = Color.Green;
                    break;
                case Logger.Type.Warning:
                    consoleTextBox.SelectionColor = Color.Yellow;
                    break;
                case Logger.Type.Error:
                    consoleTextBox.SelectionColor = Color.OrangeRed;
                    break;
                case Logger.Type.Fatal:
                    consoleTextBox.SelectionColor = Color.Red;
                    break;
            }

            consoleTextBox.AppendText(text);
            consoleTextBox.ScrollToCaret();
        }

        #region UI events

        private void openButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    LoadProject(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    if (!CheckProjectFiles(folderBrowserDialog.SelectedPath)) CreateProject(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Generate start");
            Templator.Template(projectFolderPath, templatorSettings);
            Logger.Info("Generate complete!");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSettings(projectFolderPath);
        }

        #endregion
    }
}
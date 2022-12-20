using System.Text.Json;

namespace TemplateEngineApp
{
    public partial class MainForm : Form
    {
        private string projectFolderPath = string.Empty;
        TemplateSettings _projectSettings = new TemplateSettings();

        private TemplateSettings projectSettings
        {
            get
            {
                if (propertyGrid.SelectedObject != null)
                {
                    _projectSettings.InlineTemplateStart = ((TemplateSettings)propertyGrid.SelectedObject).InlineTemplateStart;
                    _projectSettings.InlineTemplateEnd = ((TemplateSettings)propertyGrid.SelectedObject).InlineTemplateEnd;
                }

                return _projectSettings;
            }
            set
            {
                propertyGrid.SelectedObject = _projectSettings = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Logger.OnLogged += DisplayLog;
            Logger.Info("Program start");
            propertyGrid.Enabled = generateButton.Enabled = saveButton.Enabled = false;            
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    if (CheckProject(folderBrowserDialog.SelectedPath)) LoadProject(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    if (!CheckProject(folderBrowserDialog.SelectedPath)) CreateProject(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Generate start");
            Templator.Template(projectFolderPath, projectSettings);
            Logger.Info("Generate complete!");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSettings(projectFolderPath);
        }

        private void LoadProject(string projectFolderPath)
        {
            if (!Directory.Exists(projectFolderPath)) return;

            try
            {
                string settingsPath = projectFolderPath + "/" + TemplateSettings.SettingsFileName;

                using (FileStream fs = new FileStream(settingsPath, FileMode.OpenOrCreate))
                {
                    TemplateSettings? settings = JsonSerializer.Deserialize<TemplateSettings>(fs);
                    projectSettings = settings == null ? new TemplateSettings() : settings;
                }

                projectNameLabel.Text = Path.GetFileName(Path.GetDirectoryName(projectFolderPath + "/"));
                propertyGrid.Enabled = generateButton.Enabled = saveButton.Enabled = true;
                Logger.Info("Project settings loaded");
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
                string settingsPath = projectFolderPath + "/" + TemplateSettings.SettingsFileName;

                Directory.CreateDirectory(projectFolderPath + "/" + TemplateSettings.WebsiteFolderName);
                Directory.CreateDirectory(projectFolderPath + "/" + TemplateSettings.WorkspaceFolderName);
                Directory.CreateDirectory(projectFolderPath + "/" + TemplateSettings.TemplatesFolderName);
                SaveSettings(projectFolderPath);
                projectNameLabel.Text = Path.GetFileName(Path.GetDirectoryName(projectFolderPath + "/"));
                propertyGrid.Enabled = generateButton.Enabled = saveButton.Enabled = true;
                Logger.Info("Project files have been created");
            }
            catch (Exception e)
            {
                Logger.Error($"Project files were not created: {e.Message}");
            }
        }

        private bool CheckProject(string projectFolderPath)
        {
            Logger.Info("Checking project folder");

            if (Directory.Exists(projectFolderPath) && File.Exists(projectFolderPath + "/" + TemplateSettings.SettingsFileName) &&
                Directory.Exists(projectFolderPath + "/" + TemplateSettings.WebsiteFolderName) && 
                Directory.Exists(projectFolderPath + "/" + TemplateSettings.WorkspaceFolderName) &&
                Directory.Exists(projectFolderPath + "/" + TemplateSettings.TemplatesFolderName))
            {
                this.projectFolderPath = projectFolderPath;
                Logger.Warning("Folder contains project files");
                return true;
            }
            else
            {
                projectNameLabel.Text = "Project not found";
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
                using (FileStream fs = new FileStream(path + "/" + TemplateSettings.SettingsFileName, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize<TemplateSettings>(fs, projectSettings, new JsonSerializerOptions() { WriteIndented = true });
                    Logger.Info("Settings save complete");
                }
            }
            catch(Exception e)
            {
                Logger.Error("Settings save error: " + e.Message);
            }
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
    }
}
using System.Text;
using System.Text.RegularExpressions;

namespace TemplateEngineApp
{
    internal class Templator
    {
        public static void Template(string projectPath, TemplateSettings settings)
        {
            var filesPaths = Directory.GetFiles(projectPath + "/" + TemplateSettings.WorkspaceFolderName, "*.*", SearchOption.AllDirectories);
            DirectoryInfo di = new DirectoryInfo(projectPath + "/" + TemplateSettings.WebsiteFolderName);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            for (int i = 0; i < filesPaths.Length; i++)
            {
                Logger.Info($"Load '{filesPaths[i]}'");

                if (!File.Exists(filesPaths[i]))
                {
                    Logger.Error($"File not found '{filesPaths[i]}'");
                    continue;
                }
                string newContent = string.Empty;

                if (Path.GetExtension(filesPaths[i]) == ".html")
                {
                    Logger.Info($"Templated file");
                    newContent = FindAndInline(File.ReadAllText(filesPaths[i]), projectPath);
                }
                else
                {
                    Logger.Info($"Not templated file");
                    newContent = File.ReadAllText(filesPaths[i]);
                }

                string newFilePath = filesPaths[i].Replace(TemplateSettings.WorkspaceFolderName, TemplateSettings.WebsiteFolderName);

                try
                {
                    if (!File.Exists(newFilePath)) Directory.CreateDirectory(newFilePath.Replace(Path.GetFileName(newFilePath), ""));

                    using (FileStream fs = File.Create(newFilePath))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(newContent);
                        fs.Write(info, 0, info.Length);
                    }

                    Logger.Info($"Create file '{newFilePath}'");
                }
                catch (Exception e)
                {
                    Logger.Error($"Create file error: {e.Message}");
                }
            }
        }

        private static string FindAndInline(string content, string projectPath)
        {
            Regex regex = new Regex(@$"\[\[.*?\]\]");

            while (CheckTemplates(content))
            {
                foreach (Match match in regex.Matches(content))
                {
                    string template = match.Value.Substring(2, match.Value.Length - 4);
                    string templatePath = projectPath + "/" + template;

                    Logger.Info($"Find template '{template}'");

                    if (File.Exists(templatePath)) content = content.Replace(match.Value, File.ReadAllText(templatePath));
                    else Logger.Error($"Template not found '{templatePath}'");
                }
            }

            bool CheckTemplates(string content)
            {
                MatchCollection matches = regex.Matches(content);
                return matches.Count > 0;
            }

            return content;
        }
    }
}

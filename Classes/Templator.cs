using System.Text;
using System.Text.RegularExpressions;

namespace TemplateEngineApp
{
    internal class Templator
    {
        public static void Template(string projectPath, TemplateSettings settings)
        {
            var templateDictionary = new Dictionary<string, string>();
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

            foreach (var templatePath in Directory.GetFiles(projectPath + "/" + TemplateSettings.TemplatesFolderName, "*.*", SearchOption.AllDirectories))
            {
                string content = File.ReadAllText(templatePath);
                string path = templatePath.Replace(projectPath + "/", "").Replace("\\", "/");

                templateDictionary.Add(path, content);
            }

            for (int i = 0; i < filesPaths.Length; i++)
            {
                Logger.Info($"Load '{filesPaths[i]}'");
                string newFilePath = filesPaths[i].Replace(TemplateSettings.WorkspaceFolderName, TemplateSettings.WebsiteFolderName);

                if (Path.GetExtension(filesPaths[i]) == ".html")
                {
                    Logger.Info($"Templated file");

                    try
                    {
                        if (!File.Exists(newFilePath)) Directory.CreateDirectory(newFilePath.Replace(Path.GetFileName(newFilePath), ""));

                        using (FileStream fs = File.Create(newFilePath))
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes(InlineTemplates(File.ReadAllText(filesPaths[i]), templateDictionary, settings));
                            fs.Write(info, 0, info.Length);
                        }

                        Logger.Info($"Create file '{newFilePath}'");
                    }
                    catch (Exception e)
                    {
                        Logger.Error($"Create file error: {e.Message}");
                    }
                }
                else
                {
                    Logger.Info($"Not templated file");

                    try
                    {
                        if (!File.Exists(newFilePath)) Directory.CreateDirectory(newFilePath.Replace(Path.GetFileName(newFilePath), ""));

                        File.Copy(filesPaths[i], newFilePath);

                        Logger.Info($"Copy file to '{newFilePath}'");
                    }
                    catch (Exception e)
                    {
                        Logger.Error($"Copy file error: {e.Message}");
                    }
                }
            }
        }

        private static string InlineTemplates(string content, Dictionary<string, string> parameters, TemplateSettings settings, InlineType inlineType = InlineType.Block)
        {
            if (string.IsNullOrWhiteSpace(content)) return string.Empty;

            content = string.Join(" ", Regex.Split(content, @"(?:\r\n|\n|\r)"));
            content = Regex.Replace(content, @"\s+", " ");
            string templateStart = string.Empty;
            string templateEnd = string.Empty;

            switch (inlineType)
            {
                case InlineType.Block:
                    templateStart = GetStringExpression(settings.InlineTemplateStart);
                    templateEnd = GetStringExpression(settings.InlineTemplateEnd);
                    break;
                case InlineType.Parameters:
                    templateStart = GetStringExpression(settings.InlineParameterStart);
                    templateEnd = GetStringExpression(settings.InlineParameterEnd);
                    break;
            }

            Regex regex = new Regex(@$"{templateStart}.*?{templateEnd}");

            while (CheckTemplates(content))
            {
                foreach (Match match in regex.Matches(content))
                {
                    string inline = match.Value.Substring(2, match.Value.Length - 4);

                    Logger.Info($"Find template block '{inline}'");

                    if (inlineType == InlineType.Parameters)
                    {
                        content = content.Replace(match.Value, InlineParameter(inline));
                    }
                    else if (inlineType == InlineType.Block)
                    {
                        content = content.Replace(match.Value, InlineBlock(inline));
                    }
                }
            }

            bool CheckTemplates(string content)
            {
                MatchCollection matches = regex.Matches(content);
                return matches.Count > 0;
            }

            string InlineBlock(string inline)
            {
                var allParameters = inline.Split(settings.InlineParameterSeparator).Select(x => x.Trim()).ToArray();

                if (parameters.ContainsKey(allParameters[0]) && !string.IsNullOrWhiteSpace(parameters.GetValueOrDefault(allParameters[0])))
                {
                    if (allParameters.Length > 1)
                    {
                        var subParameterDictionary = new Dictionary<string, string>();

                        for (int i = 1; i < allParameters.Length; i++)
                        {
                            var subParameters = allParameters[i].Split(settings.InlineParameterAssignment).Select(x => x.Trim()).ToArray();
                            subParameterDictionary.Add(subParameters[0], subParameters[1]);
                        }

                        return InlineTemplates(parameters.GetValueOrDefault(allParameters[0]), subParameterDictionary, settings, InlineType.Parameters);
                    }
                    else
                    {
                        return parameters.GetValueOrDefault(allParameters[0]);
                    }
                }
                else
                {
                    Logger.Error($"Empty template: {inline}");
                    return string.Empty;
                }
            }

            string InlineParameter(string inline)
            {
                var allParameters = inline.Split(settings.InlineParameterAssignment).Select(x => x.Trim()).ToArray();

                if (parameters.ContainsKey(allParameters[0]) && !string.IsNullOrWhiteSpace(parameters.GetValueOrDefault(allParameters[0])))
                {
                    return parameters.GetValueOrDefault(allParameters[0]);
                }
                else if (allParameters.Length > 1)
                {
                    return allParameters[1];
                }
                else
                {
                    Logger.Error($"Empty parameter: {inline}");
                    return string.Empty;
                }
            }

            return content;
        }

        private static string GetStringExpression(string text)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++) sb.Append(@"\" + text[i]);

            return sb.ToString();

        }

        private enum InlineType
        {
            Block,
            Parameters
        }
    }
}

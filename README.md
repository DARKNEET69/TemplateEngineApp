# ![tea](https://user-images.githubusercontent.com/63448832/208745193-99ccde9b-afb1-424b-832f-b8f1f69f0921.png) Template Engine App
TEA is a GUI template engine

Instructions:

Click the "Create project" button to create a project folder or the "Open project" button if this folder already exists.

Please note that the project must contain folders: "Templates", "Website", "Workspace" and the file "TemplateSettings.json".

In the "Templates" folder you should store your templates. Templates can contain any html text or an insertion block of another template.

In the "Workspace" folder you should store your files using templates. To make the program understand that you want to use a template, use the template insertion block (by default "[[...]]", where instead of "..." you need to insert a link to a template inside the project, for example "Templates/head.html") in the right place of your text. 

Click the "Generate" button to generate the website files in the "Website" folder.

The file "TemplateSettings.json" stores the personal settings of the application. If you have changed the settings in the application and want to save them, click the "Save settings" button.

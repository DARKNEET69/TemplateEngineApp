<p align="center">
    <a href="https://github.com/DARKNEET69/TemplateEngineApp/releases/tag/0.2.0"><img src="https://user-images.githubusercontent.com/63448832/209059349-e2667f40-7a14-4183-a0e7-344d7be6df35.png" width="500"/></a>
</p>

## What is TEA?

`TEA` is a `template engine` with `GUI`. TEA is focused on the separation of working files and files that will get to the host. In particular, TEA is great for generating `static websites`.

## Quick start

* [Download](https://github.com/DARKNEET69/TemplateEngineApp/releases/tag/0.2.0) the latest version of the app.
* Launch the app.
* Click `Create project` button to create a project folder or `Open project` button if this folder already exists.

  > Please note that the project folder must contain `settings.json`.
  > In the "templates/" folder you should store your `templates`. Templates can contain `any text` or an inline block of another template.
  > In the "workspace/" folder you should store your working files using `templates`.
  > The generated project files will be stored in the "app/" folder.
  
* If you have changed the settings in the application and want to save them, click `Save settings` button. All personal settings of the application will be saved in `settings.json`.
* Click `Generate` button to generate the app files in the "app/" folder.

## Syntax

Since users can change the pointers of inline blocks, we will analyze only the default pointers.

If you just want to insert a template, use the construction [[_template_link_]] in the working file and any text in the template file:

```html
// workspace/index.html
<html>
    <head>
        [[head.html]]
        <meta name="description" content="TEA releases">  
        <meta property="og:title" content="TEA releases">  
        <meta property="og:url" content="https://github.com/DARKNEET69/TemplateEngineApp/releases">
    </head>
</html>
```
```html
// templates/head.html
<meta charset="utf-8">
<title> TEA WEBSITE </title>
<meta name="theme-color" content="#b4c290">
<meta property="og:type" content="website">
<meta property="og:site_name" content="TEA WEBSITE">
```
```html
// After generation index.html will appear in the "app/"
<html>
    <head>
        <meta charset="utf-8">
        <title> TEA WEBSITE </title>
        <meta name="theme-color" content="#b4c290">
        <meta property="og:type" content="website">
        <meta property="og:site_name" content="TEA WEBSITE">
        <meta name="description" content="TEA releases">  
        <meta property="og:title" content="TEA releases">  
        <meta property="og:url" content="https://github.com/DARKNEET69/TemplateEngineApp/releases">
    </head>
</html>
```

If you need to insert parameters, use the construction [[_template_link_, _parameter_name_ = _value_]] in the working file and {{_parameter_name_}} in the template file:

```html
// workspace/index.html
<html>
    <head>
        [[folder1/head.html, description = TEA releases, url = https://github.com/DARKNEET69/TemplateEngineApp/releases]]
    </head>
</html>
```
```html
// templates/folder1/head.html
<meta charset="utf-8">
<title> TEA WEBSITE </title>
<meta name="theme-color" content="#b4c290">
<meta property="og:type" content="website">
<meta property="og:site_name" content="TEA WEBSITE">
<meta name="description" content="{{description}}">  
<meta property="og:title" content="{{description}}">  
<meta property="og:url" content="{{url}}">
```
```html
// After generation index.html will appear in the "app/"
<html>
    <head>
        <meta charset="utf-8">
        <title> TEA WEBSITE </title>
        <meta name="theme-color" content="#b4c290">
        <meta property="og:type" content="website">
        <meta property="og:site_name" content="TEA WEBSITE">
        <meta name="description" content="TEA releases">  
        <meta property="og:title" content="TEA releases">  
        <meta property="og:url" content="https://github.com/DARKNEET69/TemplateEngineApp/releases">
    </head>
</html>
```

You can also declare the default value of a parameter in the template using the construction {{_parameter_name_ = _value_}}. The default value will be used when inlining the template, if the parameter is not specified:

```html
// workspace/index.html
<html>
    <head>
        [[head.html]] 
    </head>
</html>
```
```html
// templates/head.html
<meta charset="utf-8">
<title> TEA WEBSITE </title>
<meta name="theme-color" content="#b4c290">
<meta property="og:type" content="website">
<meta property="og:site_name" content="TEA WEBSITE">
<meta name="description" content="{{description = TEA}}">
<meta property="og:title" content="{{description = TEA}}">
<meta property="og:url" content="{{url = https://github.com/DARKNEET69/TemplateEngineApp}}">
```
```html
// After generation index.html will appear in the "app/"
<html>
    <head>
        <meta charset="utf-8">
        <title> TEA WEBSITE </title>
        <meta name="theme-color" content="#b4c290">
        <meta property="og:type" content="website">
        <meta property="og:site_name" content="TEA WEBSITE">
        <meta name="description" content="TEA">  
        <meta property="og:title" content="TEA">  
        <meta property="og:url" content="https://github.com/DARKNEET69/TemplateEngineApp">
    </head>
</html>
```

## GitHub Pages deployment

To set up the `GitHub Pages deployment` directly from the "app/" folder: 
- Go to the `Pages` tab on the repository settings
- In the `Build and deployment` field, select `GitHub Actions`
- Use a suggested workflow `Static HTML`
- Find the line `path: '.'` with the comment `# Upload entire repository` and change to `path: './app'`
***

<p align="center">
    <a href="https://github.com/DARKNEET69/TemplateEngineApp/releases/tag/0.2.0">
      <img src="https://user-images.githubusercontent.com/63448832/208745193-99ccde9b-afb1-424b-832f-b8f1f69f0921.png"/>      
    </a>    
</p>
<p align="center"> *sip TEA* </p>

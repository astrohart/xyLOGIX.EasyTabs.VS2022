<a name='assembly'></a>
# DemoApp

## Contents

- [MainWindow](#T-DemoApp-MainWindow 'DemoApp.MainWindow')
  - [#ctor()](#M-DemoApp-MainWindow-#ctor 'DemoApp.MainWindow.#ctor')
  - [CreateTab()](#M-DemoApp-MainWindow-CreateTab 'DemoApp.MainWindow.CreateTab')
  - [Dispose(disposing)](#M-DemoApp-MainWindow-Dispose-System-Boolean- 'DemoApp.MainWindow.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-DemoApp-MainWindow-InitializeComponent 'DemoApp.MainWindow.InitializeComponent')
- [MyTabContent](#T-DemoApp-MyTabContent 'DemoApp.MyTabContent')
  - [#ctor()](#M-DemoApp-MyTabContent-#ctor 'DemoApp.MyTabContent.#ctor')
  - [components](#F-DemoApp-MyTabContent-components 'DemoApp.MyTabContent.components')
  - [Dispose(disposing)](#M-DemoApp-MyTabContent-Dispose-System-Boolean- 'DemoApp.MyTabContent.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-DemoApp-MyTabContent-InitializeComponent 'DemoApp.MyTabContent.InitializeComponent')
- [Program](#T-DemoApp-Program 'DemoApp.Program')
  - [Main()](#M-DemoApp-Program-Main 'DemoApp.Program.Main')
- [Resources](#T-DemoApp-Properties-Resources 'DemoApp.Properties.Resources')
  - [Culture](#P-DemoApp-Properties-Resources-Culture 'DemoApp.Properties.Resources.Culture')
  - [ResourceManager](#P-DemoApp-Properties-Resources-ResourceManager 'DemoApp.Properties.Resources.ResourceManager')

<a name='T-DemoApp-MainWindow'></a>
## MainWindow `type`

##### Namespace

DemoApp

##### Summary

The main window of the application.

<a name='M-DemoApp-MainWindow-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [MainWindow](#T-DemoApp-MainWindow 'DemoApp.MainWindow') and returns a
reference to it.

##### Parameters

This constructor has no parameters.

<a name='M-DemoApp-MainWindow-CreateTab'></a>
### CreateTab() `method`

##### Summary

Callback that should be implemented by the inheriting class that will create a
new [TitleBarTab](#T-xyLOGIX-EasyTabs-TitleBarTab 'xyLOGIX.EasyTabs.TitleBarTab') object when the add button is
clicked.

##### Returns

A newly created tab.

##### Parameters

This method has no parameters.

<a name='M-DemoApp-MainWindow-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-DemoApp-MainWindow-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-DemoApp-MyTabContent'></a>
## MyTabContent `type`

##### Namespace

DemoApp

##### Summary

Describes the content of one of the tabs.

<a name='M-DemoApp-MyTabContent-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [MyTabContent](#T-DemoApp-MyTabContent 'DemoApp.MyTabContent') and returns
a reference to it.

##### Parameters

This constructor has no parameters.

<a name='F-DemoApp-MyTabContent-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='M-DemoApp-MyTabContent-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-DemoApp-MyTabContent-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='T-DemoApp-Program'></a>
## Program `type`

##### Namespace

DemoApp

<a name='M-DemoApp-Program-Main'></a>
### Main() `method`

##### Summary

The main entry point for the application.

##### Parameters

This method has no parameters.

<a name='T-DemoApp-Properties-Resources'></a>
## Resources `type`

##### Namespace

DemoApp.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-DemoApp-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-DemoApp-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='assembly'></a>
# DemoApp

## Contents

- [Get](#T-DemoApp-Program-Get 'DemoApp.Program.Get')
  - [LOG_FILE_PATH_TERMINATOR](#F-DemoApp-Program-Get-LOG_FILE_PATH_TERMINATOR 'DemoApp.Program.Get.LOG_FILE_PATH_TERMINATOR')
  - [AssemblyCompany](#P-DemoApp-Program-Get-AssemblyCompany 'DemoApp.Program.Get.AssemblyCompany')
  - [AssemblyProduct](#P-DemoApp-Program-Get-AssemblyProduct 'DemoApp.Program.Get.AssemblyProduct')
  - [AssemblyTitle](#P-DemoApp-Program-Get-AssemblyTitle 'DemoApp.Program.Get.AssemblyTitle')
  - [ApplicationProductName()](#M-DemoApp-Program-Get-ApplicationProductName 'DemoApp.Program.Get.ApplicationProductName')
  - [LogFilePath()](#M-DemoApp-Program-Get-LogFilePath 'DemoApp.Program.Get.LogFilePath')
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
  - [OnApplicationThreadException(sender,e)](#M-DemoApp-Program-OnApplicationThreadException-System-Object,System-Threading-ThreadExceptionEventArgs- 'DemoApp.Program.OnApplicationThreadException(System.Object,System.Threading.ThreadExceptionEventArgs)')
- [Resources](#T-DemoApp-Properties-Resources 'DemoApp.Properties.Resources')
  - [Culture](#P-DemoApp-Properties-Resources-Culture 'DemoApp.Properties.Resources.Culture')
  - [ResourceManager](#P-DemoApp-Properties-Resources-ResourceManager 'DemoApp.Properties.Resources.ResourceManager')

<a name='T-DemoApp-Program-Get'></a>
## Get `type`

##### Namespace

DemoApp.Program

##### Summary

Exposes static methods to obtain data from various data sources.

<a name='F-DemoApp-Program-Get-LOG_FILE_PATH_TERMINATOR'></a>
### LOG_FILE_PATH_TERMINATOR `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the final piece of the path of the
log file.

<a name='P-DemoApp-Program-Get-AssemblyCompany'></a>
### AssemblyCompany `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the product name defined
for this application.

##### Remarks

This property is really an alias for the
[AssemblyCompany](#P-AssemblyMetadata-AssemblyCompany 'AssemblyMetadata.AssemblyCompany') property.

<a name='P-DemoApp-Program-Get-AssemblyProduct'></a>
### AssemblyProduct `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the product name defined
for this application.

##### Remarks

This property is really an alias for the
[AssemblyProduct](#P-AssemblyMetadata-AssemblyProduct 'AssemblyMetadata.AssemblyProduct') property.

<a name='P-DemoApp-Program-Get-AssemblyTitle'></a>
### AssemblyTitle `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the assembly title defined
for this application.

##### Remarks

This property is really an alias for the
[AssemblyTitle](#P-AssemblyMetadata-AssemblyTitle 'AssemblyMetadata.AssemblyTitle') property.

<a name='M-DemoApp-Program-Get-ApplicationProductName'></a>
### ApplicationProductName() `method`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains a user-friendly name for
the software product of which this application or class library is a part.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains a user-friendly name
for the software product of which this application or class library is a part.

##### Parameters

This method has no parameters.

<a name='M-DemoApp-Program-Get-LogFilePath'></a>
### LogFilePath() `method`

##### Summary

Obtains a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified
pathname of the file that should be used for logging messages.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified
pathname of the file that should be used for logging messages.

##### Parameters

This method has no parameters.

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

##### Summary

Defines the behavior of the application.

<a name='M-DemoApp-Program-Main'></a>
### Main() `method`

##### Summary

The main entry point for the application.

##### Parameters

This method has no parameters.

<a name='M-DemoApp-Program-OnApplicationThreadException-System-Object,System-Threading-ThreadExceptionEventArgs-'></a>
### OnApplicationThreadException(sender,e) `method`

##### Summary

Handles the [](#E-System-Windows-Forms-Application-ThreadException 'System.Windows.Forms.Application.ThreadException')
event raised by the `Application` object when an unhandled exception is
thrown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Reference to an instance of the object that raised the
event. |
| e | [System.Threading.ThreadExceptionEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.ThreadExceptionEventArgs 'System.Threading.ThreadExceptionEventArgs') | A [ThreadExceptionEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.ThreadExceptionEventArgs 'System.Threading.ThreadExceptionEventArgs')
that contains the event data. |

##### Remarks

This method responds by displaying an error message box with the
exception message's text.

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


_files to look at:_

* [Form1.cs](./CS/DesignerSample/Form1.cs) (VB: [Form1.vb](./VB/DesignerSample/Form1.vb))
* [PieTotalExtension.cs](./CS/PieTotalExtension/PieTotalExtension.cs) (VB: [PieTotalExtension.vb](./VB/PieTotalExtension/PieTotalExtension.vb)

# How to Show Totals in Pie Dashboard Items
 
This example demonstrates how to create a WinForms Dashboard extension module that allows users to add and configure totals for a Pie dashboard item.

![](images/pie-totals.png)

## Pie Total Extension

This extension adds two new options to the Dashboard Designer's Ribbon toolbar: 
 - The **Show Total** option enables/disables totals in Pie Items;
 - The **Total Settings** option invokes the "Edit Total Settings" dialog that allows users to customize data displayed in totals.
 
These custom settings are stored in the dashboard definition and can be saved and restored as a part of a dashboard file. You can use Dashboard exporting capabilities to print/export Pie Totals.

## How to Integrate the Pie Total Extension Module

Follow the steps below to reuse the module in other Dashboard Designer/Viewer applications:

* Add the PieTotalExtension project to your solution
* Add a reference to this project to References in your project with dashboard controls
*	Call the following code to create the extension and attach it to the Viewer or Designer control:

**C# code**:
```csharp
PieTotalModule extension = new PieTotalModule();
extension.Attach(*Dashboard Control instance*);
```

**VB code**: 
```vb
Dim extension As New PieTotalModule()
extension.Attach(*Dashboard Control instance*)
```
   
## Example Structure    

The **PieTotalModule** class contains the main logic of the extension and includes the following logical sections: 

* Assigning Logic

   The **Attach** and **Detach** methods in this section subscribe and unsubscribe events used for customization in this extension.

* Common Logic

    This section contains event handlers and methods for the Designer and Viewer controls.

* Designer Logic

    This section contains the logic for the Dashboard Designer UI. It includes the Ribbon toolbar items' creation methods, their click handlers, and the method that updates their states based on the currently selected dashboard item.

The **PieTotalSettings** class describes the model of custom settings used in this extension. The extension stores this model in a Custom Property of each Pie Item and reads this data when required. The class has the **FromJson** and **ToJson** public static methods which saves and reads data in JSON format because custom properties allow you to store data only in the string format. 

The **PieTotalSettingsDialog** dialog allows users to customize data displayed in totals. Users can select a measure which values are displayed in the total and specify leading and trailing texts.  

## Documentation

* [Custom Properties](https://docs.devexpress.com/Dashboard/401595/winforms-designer/custom-properties)
* [Access to Underlying Controls](https://docs.devexpress.com/Dashboard/401095/winforms-designer/access-to-underlying-controls)
* [Obtaining Underlying and Displayed Data](https://docs.devexpress.com/Dashboard/17269/winforms-viewer/obtaining-underlying-and-displayed-data)

## See Also

* [How to Export Customized Pie Dashboard Item]https://github.com/DevExpress-Examples/WinForms-Dashboard-How-to-export-customized-Pie-Dashboard-Item 

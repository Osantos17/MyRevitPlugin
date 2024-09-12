using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using System.Reflection;


namespace MyRevitPlugin
{
    public class Class1 : IExternalApplication
    {
       
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("MyRibbonPanel");

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("cmdMyTest", "My Test", thisAssemblyPath, "MyRevitPlugin.MyTest");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;


            pushButton.ToolTip = "Hello, this is my first PlugIn";

            return Result.Succeeded;

        } 
        
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
           
        }

        [Transaction(TransactionMode.Manual)]
        public class MyTest : IExternalCommand
        {
            public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
            {
                var uiapp = commandData.Application;
                var app = uiapp.Application;
                var uidoc = uiapp.ActiveUIDocument;
                var dov = uidoc.Document;

                TaskDialog.Show("Revit", "BDE_PlugIn");

                return Result.Succeeded;
            }
        }
    }
}

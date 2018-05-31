using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace HelloRevit
{
    [Transaction(TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class LaShen : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            //添加一个新的Ribbon面板
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("NewRibbonPanel");

            //在新的Ribbon面板上添加一个按钮
            //点击这个按钮，前一个例子“HelloRevit”这个插件将被运行。
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("HelloRevit",
                "HelloRevit", @"E:\pratises\VS\HelloRevit\HelloRevit\obj\Debug\HelloRevit.dll", "HelloRevit.LaShen")) as PushButton;

            // 给按钮添加一个图片
            Uri uriImage = new Uri(@"F:\Downloads\logo.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}



using System;
using EventApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage),
typeof(CustomTabbedPageRenderer))]
namespace EventApp.iOS
{
    class CustomTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            App.TabHeight = (int)TabBar.Frame.Height;
        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using EventApp.Custom;
using CoreGraphics;

[assembly: ExportRenderer(typeof(ExtendedScrollView), typeof(EventApp.iOS.Renderers.ExtendedScrollViewRenderer))]
namespace EventApp.iOS.Renderers
{
    public class ExtendedScrollViewRenderer: ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            UIScrollView v = (UIScrollView)NativeView;
            v.PagingEnabled = true;
        }

        
    }
}

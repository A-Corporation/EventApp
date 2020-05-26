using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using EventApp.Controls;
using EventApp.iOS;

[assembly: ExportRenderer(typeof(NonSelectableListView), typeof(NonSelectableListViewRenderer))]
namespace EventApp.iOS
{
    public class NonSelectableListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
            }

            if (e.NewElement != null)
            {
                // Configure the native control and subscribe to event handlers
                Control.AllowsSelection = false;
            }
        }
    }

}
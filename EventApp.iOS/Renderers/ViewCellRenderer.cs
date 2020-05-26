using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using EventApp.iOS.Renderers;


[assembly: ExportRenderer(typeof(ViewCell), typeof(MyViewCellRenderer))]
namespace EventApp.iOS.Renderers
{
    public class MyViewCellRenderer: ViewCellRenderer
    {
        private UIView bgView;

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            cell.BackgroundColor = UIColor.White;

            if (bgView == null)
            {
                bgView = new UIView(cell.SelectedBackgroundView.Bounds);
                bgView.Layer.BackgroundColor = UIColor.Gray.CGColor;
                bgView.Layer.BorderColor = UIColor.Clear.CGColor;
                //bgView.Layer.BorderWidth = 5f;
            }

            cell.SelectedBackgroundView = bgView;
            return cell;
        }
    }
}

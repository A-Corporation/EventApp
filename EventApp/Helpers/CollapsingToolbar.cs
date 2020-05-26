using System;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace EventApp.Helpers
{
    public class CollapsingToolbar
    {

        public int HeaderHeight { get; set; }
        public int MinHeaderTranslation { get; set; }

        public View HeaderView { get; set; }
        public Label HeaderTittle { get; set; }
        public Label HeaderSubtittle { get; set; }
        public NavigationPage navigationPage { get; set; }

        public CollapsingToolbar()
        {
            HeaderHeight = 0;
            
            MinHeaderTranslation = (int)Math.Round(56 * (DeviceDisplay.MainDisplayInfo.Density) / 160f); //(int)(DeviceDisplay.MainDisplayInfo.Density * 160f);
        }


        public void OnScroll()
        {
            double scrollY = GetScrollY(HeaderView);

            HeaderView.TranslationY = Math.Max(0, scrollY + MinHeaderTranslation);

            float offset = 1 - Math.Max((float)(-MinHeaderTranslation - scrollY) / -MinHeaderTranslation, 0f);

            UpdateBarAlpha(offset);

        }


        public void UpdateBarAlpha(float offset)
        {
            navigationPage.BarBackgroundColor.MultiplyAlpha(offset);
           
        }



        public double GetScrollY(View headerView)
        {
            double firstVisiblePosition = headerView.Y;
            double top = headerView.Bounds.Top;
            double headerHeight = 0;
            if (firstVisiblePosition >= 1)
                HeaderHeight = this.HeaderHeight;
            return -top + firstVisiblePosition * headerView.Height + headerHeight;
        }
    }
}

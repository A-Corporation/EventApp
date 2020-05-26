using System;
using System.Linq;
using Xamarin.Forms;

namespace EventApp.Controls
{
    public class ExtendedEditor: Editor
    {
        public static BindableProperty PlaceholderProperty
          = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ExtendedEditor));

        public static BindableProperty PlaceholderColorProperty
           = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(ExtendedEditor), Color.LightGray);

        public static BindableProperty HasRoundedCornerProperty
        = BindableProperty.Create(nameof(HasRoundedCorner), typeof(bool), typeof(ExtendedEditor), false);

        public static BindableProperty IsExpandableProperty
        = BindableProperty.Create(nameof(IsExpandable), typeof(bool), typeof(ExtendedEditor), false);

        public bool IsExpandable
        {
            get { return (bool)GetValue(IsExpandableProperty); }
            set { SetValue(IsExpandableProperty, value); }
        }
        public bool HasRoundedCorner
        {
            get { return (bool)GetValue(HasRoundedCornerProperty); }
            set { SetValue(HasRoundedCornerProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public ExtendedEditor()
        {
            TextChanged += OnTextChanged;
        }

        ~ExtendedEditor()
        {
            TextChanged -= OnTextChanged;
        }



        /*
        bool sized = false;
        public double lineHeight = 0;
        string text = "";

        protected override void OnSizeAllocated(double width, double height)
        {
            if (!sized)
            {
                int count = text.Split('\n').Length;
                lineHeight = (height / (count + 1));
                sized = true;
            }
            base.OnSizeAllocated(width, height);
        }
        */



        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //text = e.NewTextValue;
            if (IsExpandable) InvalidateMeasure();
        }

    }
}

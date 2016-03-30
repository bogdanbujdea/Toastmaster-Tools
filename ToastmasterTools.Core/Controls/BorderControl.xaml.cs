using System;
using Windows.UI.Xaml;

namespace ToastmasterTools.Core.Controls
{
    public sealed partial class BorderControl
    {
        public BorderControl()
        {
            InitializeComponent();
        }

        public Uri ImageSource
        {
            get { return (Uri)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(Uri), typeof(BorderControl), new PropertyMetadata(string.Empty));



        public string ItemText
        {
            get { return (string)GetValue(ItemTextProperty); }
            set { SetValue(ItemTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTextProperty =
            DependencyProperty.Register("ItemText", typeof(string), typeof(BorderControl), new PropertyMetadata(string.Empty));


    }
}

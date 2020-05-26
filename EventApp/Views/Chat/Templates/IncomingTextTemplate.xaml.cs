using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EventApp.Views.Chat
{
    /// <summary>
    /// Which is used for incoming text template
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomingTextTemplate
    {
        public IncomingTextTemplate()
        {
            this.InitializeComponent();
        }

    }
}

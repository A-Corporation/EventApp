using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EventApp.Views.Templates
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCard
    {
        public UserCard()
        {
            InitializeComponent();
        }
    }
}

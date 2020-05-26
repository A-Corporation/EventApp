using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using EventApp.Models.Chat;

namespace EventApp.Views.Chat
{
    /// <summary>
    /// Implements the message data template selector class.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MessageDataTemplateSelector : DataTemplateSelector
    {
        #region Constructor
        public MessageDataTemplateSelector()
        {
            this.IncomingTextTemplate = new DataTemplate(typeof(IncomingTextTemplate));
            this.OutgoingTextTemplate = new DataTemplate(typeof(OutgoingTextTemplate));
        }
        #endregion

        #region Properties

        public DataTemplate IncomingTextTemplate { get; set; }
        public DataTemplate OutgoingTextTemplate { get; set; }

        #endregion

        #region Methods

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((ChatMessage)item).IsReceived)
            {
                return this.IncomingTextTemplate;
            }
            else
            {
                return this.OutgoingTextTemplate;
            }
        }

        #endregion
    }
}

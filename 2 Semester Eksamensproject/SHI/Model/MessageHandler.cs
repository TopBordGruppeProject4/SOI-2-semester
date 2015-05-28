using Windows.UI.Popups;

namespace SHI.Model
{
    class MessageHandler
    {
        public static void CreateMessage(string message, string title)
        {
            var dialog = new MessageDialog(message, title);
            dialog.ShowAsync();
        }
    }
}

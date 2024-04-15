using Microsoft.Win32;
using System.IO;

namespace Checkers.Services
{
    public interface IDialogService
    {
        string ShowSaveFileDialog(string defaultFileName, string defaultExtension);
        string ShowOpenFileDialog(string defaultFileName, string defaultExtension);
    }

    public class DialogService : IDialogService
    {
        private string _defaultDirectory = Path.GetFullPath("./Saved Games");

        public DialogService()
        {
            string substringToRemove = "\\bin\\Debug";
            _defaultDirectory = _defaultDirectory.Replace(substringToRemove, "");
        }

        public string ShowOpenFileDialog(string defaultFileName, string defaultExtension)
        {
            var dialog = new OpenFileDialog();
            dialog.FileName = defaultFileName;
            dialog.DefaultExt = defaultExtension;
            dialog.Filter = $"{defaultExtension.ToUpper()} Files|*.{defaultExtension}";
            dialog.InitialDirectory = _defaultDirectory;

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }

            return null;
        }

        public string ShowSaveFileDialog(string defaultFileName, string defaultExtension)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = defaultFileName;
            dialog.DefaultExt = defaultExtension;
            dialog.Filter = $"{defaultExtension.ToUpper()} Files|*.{defaultExtension}";
            dialog.InitialDirectory = _defaultDirectory;

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }

            return null;
        }
    }
}

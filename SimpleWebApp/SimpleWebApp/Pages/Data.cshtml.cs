using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleWebApp.Pages
{
    public class DataModel : PageModel
    {
        public string? CheckResult { get; set; }
        private const string _folderPath = "/var/webappdata";
        private const string _fileName = "somefile.txt";

        public void OnGet()
        {
        }

        public void OnPostCheckFolder()
        {

            if (Directory.Exists(_folderPath))
            {
                CheckResult = $"✅ Folder '{_folderPath}' exists.";
            }
            else
            {
                CheckResult = $"❌ Folder '{_folderPath}' does not exist.";
            }
        }

        public void OnPostCreateTextFile()
        {
            string absPath = $"{_folderPath}/{_fileName}";

            if (Directory.Exists(_folderPath))
            {
                System.IO.File.Create(absPath);
            } else
            {
                CheckResult = $"❌ Failed to create File '{absPath}'";
                return;
            }

            if (System.IO.File.Exists(absPath))
            {
                CheckResult = $"✅ File '{absPath}' created.";
            }
            else
            {
                CheckResult = $"❌ File '{absPath}' does not exist.";
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleWebApp.Pages
{
    public class DataModel : PageModel
    {
        public string? FolderCheckResult { get; set; }

        public void OnGet()
        {
        }

        public void OnPostCheckFolder()
        {
            string path = "/var/webappdata";

            if (Directory.Exists(path))
            {
                FolderCheckResult = $"✅ Folder '{path}' exists.";
            }
            else
            {
                FolderCheckResult = $"❌ Folder '{path}' does not exist.";
            }
        }
    }
}

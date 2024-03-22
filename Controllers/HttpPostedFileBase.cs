
namespace TN_Treasury_Web_Portal.Controllers
{
    public class HttpPostedFileBase
    {
        internal readonly int ContentLength;
        internal string? FileName;

        internal void SaveAs(string path)
        {
            throw new NotImplementedException();
        }

        internal void SaveAs(object path)
        {
            throw new NotImplementedException();
        }
    }
}
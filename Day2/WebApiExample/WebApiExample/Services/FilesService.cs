using WebApiExample.Contracts;

namespace WebApiExample.Services
{
    public class FilesService : IFiles
    {
        public  string[] GetFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                return null; 
            }

            var files =Directory.GetFiles(path);

            return files;
        }
    }
}

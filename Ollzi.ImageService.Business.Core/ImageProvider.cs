using System.Linq;
using System.IO;

namespace Ollzi.ImageService.Business.Core
{
    public interface IImageProvider
    {
        string[] GetImageFiles(string basePath);
    }

    public class ImageProvider : IImageProvider
    {
        public string[] GetImageFiles(string basePath)
        {
            var searchPattern = new[] { "*.png", "*.jpg" };

            return searchPattern.SelectMany(x => Directory.GetFiles(basePath, x, SearchOption.AllDirectories)).ToArray();
        }
    }
}

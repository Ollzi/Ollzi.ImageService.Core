using Ollzi.ImageService.Contracts.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Ollzi.ImageService.Business.Core.Action
{
    public class ImageAction
    {
        private readonly IImageProvider _imageProvider;
        private readonly string _basePath;

        public ImageAction(string basePath)
            : this(new ImageProvider(), basePath)
        {

        }

        public ImageAction(IImageProvider imageProvider, string basePath)
        {
            _imageProvider = imageProvider;
            _basePath = basePath;
        }

        public IEnumerable<ImageMetaData> GetImages()
        {
            var imageFiles = _imageProvider.GetImageFiles(_basePath);
            var random = new Random();
            var numberOfFilesToRandomize = imageFiles.Length >= 100 ? 100 : imageFiles.Length;

            var randomizedFiles = new List<ImageMetaData>();

            while (randomizedFiles.Count < numberOfFilesToRandomize)
            {
                var index = random.Next(0, imageFiles.Length);

                if (randomizedFiles.All(m => m.FileName != imageFiles[index]))
                {
                    string fileDate = "";

                    using (FileStream fs = new FileStream(imageFiles[index], FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        var fileInfo = new FileInfo(imageFiles[index]);
                        fileDate = fileInfo.CreationTime.ToString("yyyy-MM-dd");
                    }

                    randomizedFiles.Add(new ImageMetaData
                    {
                        FileName = imageFiles[index],
                        FileDate = fileDate
                    });
                }
            }

            return randomizedFiles;
        }
    }
}

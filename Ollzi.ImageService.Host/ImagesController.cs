using Microsoft.AspNetCore.Mvc;
using Ollzi.ImageService.Business.Core.Action;
using Ollzi.ImageService.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ollzi.ImageService.Host
{
    [Route("Images")]
    public class ImagesController : Controller
    {
        private ImageAction _imageAction;

        public ImagesController()
        {
            _imageAction = new ImageAction("/home/pi/Photos");
        }

        [HttpGet]
        public IEnumerable<ImageMetaData> GetImages()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.StatusCode = (int)HttpStatusCode.OK;
            var imageData = _imageAction.GetImages();
            return imageData;
        }
    }
}

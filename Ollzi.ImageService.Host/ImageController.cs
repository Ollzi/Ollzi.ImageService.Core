using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ollzi.ImageService.Business.Core.Action;
using Ollzi.ImageService.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Ollzi.ImageService.Host
{
    [Route("Image")]
    public class ImageController : Controller
    {
        private ImageAction _imageAction;

        public ImageController()
        {
            _imageAction = new ImageAction("/home/pi/Photos");
        }

        public void GetImage(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            Console.WriteLine(id);

            Response.Headers.Add("ContentType", "image/png");
            Response.StatusCode = (int)HttpStatusCode.OK;
            var fileBytes = System.IO.File.ReadAllBytes(@id);
            Response.Body.Write(fileBytes, 0, fileBytes.Length);
        }
    }
}

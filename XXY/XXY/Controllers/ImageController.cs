using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XXY.Models;

namespace XXY.Controllers
{
    /// <summary>
    /// 图片相关
    /// </summary>
    [Route("Image/{Action}")]
    public class ImageController : ApiController
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ModelResult UploadImage(ImageRequest request)
        {
            var result = new ModelResult();
            if (string.IsNullOrWhiteSpace(request.Image))
            {
                result.Msg = "没有图片信息";
                result.Code = "1000";
            }
            else
            {
                try
                {
                    byte[] bt = Convert.FromBase64String(request.Image);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream);
                    string fileName = Guid.NewGuid().ToString();
                    string filePath = System.Web.Hosting.HostingEnvironment.MapPath($"/Resources/{fileName}.jpg");
                    bitmap.Save(filePath);
                    result.Data = new ImageResult { FileName = fileName };
                }
                catch (Exception ex)
                {
                    result.Code = "1000";
                    result.Msg = ex.Message;
                }
            }
            return result;
        }
    }
}

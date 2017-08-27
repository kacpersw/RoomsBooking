using ImageMagick;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace QRProject.Implementations
{
    public class QRCodeService
    {
        public string DecodeCode(HttpPostedFileBase file)
        {
            try
            {
                var image = new MagickImage(System.Drawing.Image.FromStream(file.InputStream) 
                    as Bitmap);
                var size = new MagickGeometry(640, 480);

                size.IgnoreAspectRatio = true;
                image.Resize(size);

                MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.
                    Codec.QRCodeDecoder();

                return decoder.Decode(new QRCodeBitmapImage(image.ToBitmap()));
            }
            catch
            {
                return string.Empty;
            }
        }


    }
}
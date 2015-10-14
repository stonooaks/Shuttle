using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Hermes.Message.Image_Methods
{
    public class ImageToMessage
    {
        public MemoryStream InsertImage()
        {
            Bitmap b = new Bitmap(Properties.Resources.KICALogo__low_res_);
            ImageConverter ic = new ImageConverter();
            Byte[] ba = (Byte[])ic.ConvertTo(b, typeof(Byte[]));            
            MemoryStream logo = new MemoryStream(ba);

            return logo;
        }
    }
}

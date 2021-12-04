using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Repositories
{
    public class ImageRepository
    {
        public ImageRepository()
        {
            if (!Directory.Exists(ImageDir))
                Directory.CreateDirectory(ImageDir);
        }
        const string ImageDir = "images/users/";
        public byte[] GetUserImage(int userId)
        {
            var path = $"{ImageDir}{userId}.jpg";
            if (File.Exists(path))
                return File.ReadAllBytes($"{ImageDir}{userId}.jpg");
            else
                return null;
        }
        public void ChangeUserImage(int userId, byte[] imgBytes)
        {
            Image img = null;
            using(Stream stream = new MemoryStream())
            {
                stream.Write(imgBytes, 0, imgBytes.Length);
                img = new Bitmap(Image.FromStream(stream), new Size(512, 512));
            }
            img.Save($"{ImageDir}{userId}.jpg");
        }
    }
}

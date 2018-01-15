using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Http;
namespace API
{
    public class ImageRequest : IRequest<string,Bitmap>
    {
        //string _image_url;

        //public ImageRequest(string image_url)
        //{
        //    _image_url = image_url; 
        //}

        public async Task<Bitmap> MakeRequest(string _image_url)
        {
            Bitmap album_art;
            using (HttpClient httpClient = new HttpClient())
            {
                System.IO.Stream bitmapSource = await httpClient.GetStreamAsync(_image_url);
                album_art = new Bitmap(bitmapSource);
            }

            return album_art;
        }
    }
}

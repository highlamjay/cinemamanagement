﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace cinema_management.Utils
{

    public class CloudinaryService
    {
        private static CloudinaryService _ins;
        public static CloudinaryService Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CloudinaryService();
                }
                return _ins;
            }
            private set => _ins = value;
        }
        private Account account;
        private Cloudinary cloudinary;
        private CloudinaryService()
        {
            account = new Account("dqnnjoooh", "563547112355979", "frcO22YIAzU9yDiLcoNh7bqxVag");
            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }



        public async Task<string> UploadImage(string filePath)
        {
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath),
                    Folder = "Image"
                };
                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                return uploadResult.SecureUrl.AbsoluteUri;
            }
            catch (System.Exception e)
            {
                return null;
            }
        }
        public async Task DeleteImage(string imageURL)
        {
            try
            {
                string publicId = GetPublicIdFromURL(imageURL);
                var deletionParams = new DeletionParams(publicId)
                {
                    ResourceType = ResourceType.Image,
                };

                var deletionResult = await cloudinary.DestroyAsync(deletionParams);
            }
            catch (System.Exception)
            {
                return;
            }
        }

        public async Task<BitmapImage> LoadImageFromURL(string imageURL)
        {
            if (string.IsNullOrEmpty(imageURL))
            {
                return null;
            }
            System.Net.WebRequest request =
                        System.Net.WebRequest.Create(imageURL);
            System.Net.HttpWebResponse response;
            try
            {
                response = (await request.GetResponseAsync()) as System.Net.HttpWebResponse;
            }
            catch (System.Net.WebException)
            {
                return null;
            }

            System.IO.Stream responseStream =
                response.GetResponseStream();

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = responseStream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            return bitmap;
        }
        private string GetPublicIdFromURL(string url)
        {
            string strStart = "Image";
            string strEnd = ".";
            if (url.Contains("Image") && url.Contains("."))
            {
                int Start, End;
                Start = url.IndexOf(strStart, 0);
                End = url.IndexOf(strEnd, Start);
                return url.Substring(Start, End - Start);
            }
            return null;
        }
    }
}

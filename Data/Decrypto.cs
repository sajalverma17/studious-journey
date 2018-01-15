using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
namespace Data
{
    public static class Decrypto
    {
        public static string GetDESDecryptedUrl(string enc_value) 
        {

            enc_value = enc_value.Replace("\\/", "/");
            Debug.Write("Decrypting enc_media_url: " + enc_value);
            byte[] inputByteArray = Convert.FromBase64String(enc_value);
            
            DES desObj = DESCryptoServiceProvider.Create();
            desObj.Mode = CipherMode.ECB;
            desObj.Padding = PaddingMode.PKCS7;
            desObj.Key = Encoding.ASCII.GetBytes("38346591");
            desObj.IV = Encoding.ASCII.GetBytes("\0\0\0\0\0\0\0\0");
            var desCipher = desObj.CreateDecryptor();
            
            byte[] outputByteArray = desCipher.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
            string dec_value = Encoding.UTF8.GetString(outputByteArray);
            Debug.WriteLine("Decrypted value : " + dec_value);
            if (!dec_value.Contains("/")) {
                Debug.WriteLine("Decrypted URL:" + dec_value + "No resource URL for this song");
                return null;
            }
            string media_url = FormMediaUrl(dec_value);

            Debug.WriteLine("Decrypted Media URL : " + media_url);
            return media_url;
        }

        private static string FormMediaUrl(string dec_value)
        {
            //Sample URL where song is streamed from: http://h.saavncdn.com/386/3ae8b5e0aabd669336c933becda8a7a9.mp3

            string cdnHost = "http://h.saavncdn.com";
            string extension = "mp3";
            if (dec_value.Contains("mp3"))
            {
                extension = "mp3";
            }
            else
            {
                extension = "mp4";
            }
            //Get the string after the first forward slash---
            string path = dec_value.Substring(dec_value.IndexOf('/'));
            
            return cdnHost+path+"."+extension;
        }

  


    }
}

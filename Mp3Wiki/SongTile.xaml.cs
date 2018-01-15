﻿using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using API;
using Data;
using System.Drawing;
using System.IO;
using System.Windows.Threading;
namespace Mp3Wiki
{
    /// <summary>
    /// Interaction logic for SongTile.xaml
    /// </summary>
    public partial class SongTile : UserControl
    {
        static MediaPlayer songPlayer;
        //Each song tile will have its personal string instance to download its own album art         
        string _imageUrl;
        DispatcherTimer timer;
        public SongTile(SongContentTemplate dto)
        {
            InitializeComponent();
            tile.DataContext = dto;
            txtSongTitle.Text = dto.Title;
            txtSongAlbum.Text = dto.Album;
            _imageUrl = dto.ImageUrl;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);            
            timer.Tick += timer_Tick;
            
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //PlayerSlider.Value = songPlayer.Position.Seconds;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            btnPlay.Visibility = Visibility.Hidden;
            PlayProgressRing.Visibility = Visibility.Visible;
            //PlayerSlider.Visibility = Visibility.Visible;
            SongContentTemplate tileData = tile.DataContext as SongContentTemplate;

            PlayAsync(tileData.WebURL,tileData.Pid);
        }

        
        

        public async void PlayAsync(string web_url, string pid)
        {           
            
            SaavnPageRequest pageRequest = new SaavnPageRequest();
            System.Diagnostics.Debug.Write("Fetching HTML : " + web_url);
            string html = await pageRequest.MakeRequest(web_url);
            string enc_value = HTMLParser.Deserialize(html, pid);
            string mediaUrl = Decrypto.GetDESDecryptedUrl(enc_value);

            if (mediaUrl == null) {
                btnPlay.Visibility = Visibility.Visible;
                PlayProgressRing.Visibility = Visibility.Hidden;
                btnPlay.Content = "Unavailable";
                btnPlay.IsEnabled = false;
                return;
            }
            

            if (songPlayer == null)
            {
                songPlayer = new MediaPlayer();
                timer.Start();
            }
                
                   
                Uri uri = new Uri(mediaUrl);
                
               
                songPlayer.Open(uri);
                songPlayer.Play();
                songPlayer.Volume = 1;

            btnPlay.Visibility = Visibility.Visible;
            PlayProgressRing.Visibility = Visibility.Hidden;
            
        }

        public async void DownloadAlbumArtAsync()
        {
            _imageUrl = _imageUrl.Replace("50x50", "150x150");
            MemoryStream buffer = new MemoryStream();
            Bitmap albumArtBmp;
            try
            {
                albumArtBmp = await new ImageRequest().MakeRequest(_imageUrl);  
                albumArtBmp.Save(buffer, System.Drawing.Imaging.ImageFormat.Bmp);
                
            }
            catch (Exception e)
            {                               
                System.Diagnostics.Debug.WriteLine("Better quality image not found. So downloading 50x50.");
                return;
            }

            setAlbumArt(buffer);
            
        }

        public async void DownloadLowQualityArtAsync(string url)
        {
            url = _imageUrl.Replace("150x150", "50x50");
            Bitmap albumArtBmp = await new ImageRequest().MakeRequest(_imageUrl);
            MemoryStream buffer = new MemoryStream();
            albumArtBmp.Save(buffer, System.Drawing.Imaging.ImageFormat.Bmp);
            setAlbumArt(buffer);
        }

        public void setAlbumArt(MemoryStream buffer)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            buffer.Seek(0, SeekOrigin.Begin);
            img.StreamSource = buffer;
            img.EndInit();

            if (img != null)
            {
                imgAlbumArt.Source = img;
            }
        }

        //public async Task<ImageSource> ConvertBitmapAsync(Bitmap src)
        //{
        //    ImageSource imgSrc;
        //    imgSrc = await Task.Run<ImageSource>(() => new ImageSourceConverter().ConvertFrom(src) as ImageSource);
        //    return imgSrc;

        //    //Task<ImageSource> t = new Task<ImageSource>(() => function(src));               
        //    //imgSrc = await t;
        //}

        //private ImageSource function(Bitmap src)
        //{
        //    return new ImageSourceConverter().ConvertFrom(src) as ImageSource;
        //}

        

    }
}
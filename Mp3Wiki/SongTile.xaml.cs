using MahApps.Metro.Controls;
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

        //HashCode of the tile on which btn was clicked shared across tiles  
        static int lastClickedBtnHashCode = 0;   

        //Each song tile will have its personal string instance to download its own album art         
        string _imageUrl;

        DispatcherTimer ticker;

        public SongTile(SongContentTemplate dto)
        {
            InitializeComponent();

            tile.DataContext = dto;
            txtSongTitle.Text = dto.Title;
            txtSongAlbum.Text = dto.Album;
            _imageUrl = dto.ImageUrl;           
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
                        
            if (lastClickedBtnHashCode == sender.GetHashCode())
            {
                if (btnPlay.Content.Equals("Pause"))
                {
                    songPlayer.Pause();
                    //PlayerSlider.Value = songPlayer;
                    btnPlay.Content = "Play";
                }
                else
                {
                    songPlayer.Play();
                    btnPlay.Content = "Pause";
                }
            }

            //btnPlay clicked on a different song Tile
            else
            {                
                if (songPlayer != null)
                {
                    songPlayer.MediaOpened -= songPlayer_MediaOpened;
                    songPlayer.Stop();
                }       
                SongContentTemplate tileData = tile.DataContext as SongContentTemplate;

                resetAllTilesControls();                

                PlayAsync(tileData.WebURL, tileData.Pid);
                                  
                lastClickedBtnHashCode = sender.GetHashCode();
            }
        }
        public async void PlayAsync(string web_url, string pid)
        {
            btnPlay.Content = "Pause";    
            btnPlay.Visibility = Visibility.Hidden;
            PlayProgressRing.Visibility = Visibility.Visible;
            PlayerSlider.Visibility = Visibility.Visible;            
            
            SaavnPageRequest pageRequest = new SaavnPageRequest();
            System.Diagnostics.Debug.Write("Fetching HTML : " + web_url);
            string html = await pageRequest.MakeRequest(web_url);
            string enc_media_url = HTMLParser.GetEncryptedURL(html,pid);
            string mediaUrl = Decrypto.GetDESDecryptedUrl(enc_media_url);

            if (mediaUrl == null)
            {
                btnPlay.Visibility = Visibility.Visible;
                PlayProgressRing.Visibility = Visibility.Hidden;
                btnPlay.Content = "Unavailable";
                btnPlay.IsEnabled = false;
                return;
            }

            if (songPlayer == null)
            {                
                songPlayer = new MediaPlayer();                
                songPlayer.MediaEnded += songPlayer_MediaEnded;                
            }
           
            songPlayer.MediaOpened += songPlayer_MediaOpened;

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

        void songPlayer_MediaOpened(object sender, EventArgs e)
        {
            PlayerSlider.Maximum = songPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;            
            ticker = new DispatcherTimer(new TimeSpan(0,0,1), DispatcherPriority.Normal, (s, ev) => { PlayerSlider.Value = songPlayer.Position.TotalMilliseconds; }, songPlayer.Dispatcher);
        }       

        void songPlayer_MediaEnded(object sender, EventArgs e)
        {
            resetAllTilesControls();
        }

        private void resetAllTilesControls()
        {
            var listView = (Application.Current.MainWindow as MainWindow).listDetails;
            var children = listView.GetChildObjects();

            foreach (SongTile tile in children)
            {
                tile.btnPlay.Content = "Play";                
                tile.PlayerSlider.Visibility = Visibility.Hidden;
                tile.PlayerSlider.Value = 0;
            }
            lastClickedBtnHashCode = 0;
        }        

        private void setAlbumArt(MemoryStream buffer)
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
    }
}

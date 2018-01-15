using API;
using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MahApps.Metro.Controls;


namespace Mp3Wiki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        SearchRequest searchRequest;
        SaavnPageRequest pageRequest;
        MediaPlayer songPlayer;
        public MainWindow()
        {
            this.ShowMaxRestoreButton = false;
            InitializeComponent()       ;
            searchRequest = new SearchRequest();
            pageRequest = new SaavnPageRequest();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            progressBar.IsIndeterminate = true;
            DownloadAsync();           
        }
        private void txtQuery_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            progressBar.IsIndeterminate = true;
            DownloadAsync();           
        }
        public async void DownloadAsync()   
        {
            Debug.WriteLine("Starting download");
            
            SearchRequest s = new SearchRequest();           
            string result = await s.MakeRequest(txtQuery.Text);

            List<Song> songList = new List<Song>();
            songList = JSONParser.Deserialize(result);

            ResetList();
            SetList(songList);

            progressBar.IsIndeterminate = false;

            Debug.WriteLine(result);
        }

        //Utility UI methods----
        private void SetList(List<Song> songList)
        {        
            foreach (var s in songList)
            {
                Song song = (Song)s;

                SongContentTemplate dto = new SongContentTemplate();
                dto.Pid = song.ID;
                dto.Title = song.Title;
                dto.WebURL = song.WebPageURL;
                dto.Album = song.Album;
                dto.ImageUrl = song.ImageURL;
                
                SongTile tile = new SongTile(dto);
                tile.DownloadAlbumArtAsync();

                listDetails.Items.Add(tile);
            }
        } 
       
        private void ResetList()
        {
            if(listDetails.Items.Count >0)
                listDetails.Items.Clear();
        }

        

        


        
    }
}

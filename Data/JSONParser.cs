using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using Data;
using Microsoft.CSharp.RuntimeBinder;
namespace Data
{
    public class JSONParser
    {
        //Only deserialize Songs result from search result
        public static List<Song> Deserialize(string resultJSON)
        {

            List<Song> songList = new List<Song>();
            
            dynamic searchResult = JsonConvert.DeserializeObject(resultJSON);
            dynamic songSearchResult = null;
            try
            {
                songSearchResult = searchResult.songs;               
            }
            catch (RuntimeBinderException rbe)
            {
                System.Diagnostics.Debug.WriteLine("Error parsing. Invalid JSON string format :\n"+rbe.Message);   
            }

            if (songSearchResult != null)
            {
                dynamic songData = songSearchResult.data;

                foreach (var song in songData)
                {
                    Song s = new Song();
                    s.ID = song.id;
                    s.Title = song.title;
                    s.Album = song.album;
                    s.ImageURL = song.image;
                    s.WebPageURL = song.url;
                    songList.Add(s);
                }
            }
            
            return songList;            
            
        }
    }
}

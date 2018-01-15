using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;

namespace Mp3Wiki
{
    public class SongContentTemplate : DataTemplate
    {
        public string Title{ get; set; }
        public string Album { get; set; }
        public string Pid { get; set; }
        public string WebURL { get; set; }
        public string ImageUrl { get; set; }
    }
}

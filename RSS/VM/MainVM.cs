
using Microsoft.AppCenter.Crashes;
using RSS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;


namespace RSS.VM
{
    public class MainVM : INotifyPropertyChanged
    {
        public Posts Blog
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            ReadRss();
        }

        public void ReadRss()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Posts));

            using (WebClient client = new WebClient())
            {
               /* try
                {*/
                    string xml = Encoding.Default.GetString(client.DownloadData("https://www.finzen.mx/blog-feed.xml"));
                    using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                    {
                        Blog = (Posts)serializer.Deserialize(reader);
                    }


                /*}
                catch (Exception exception)
                {
                    var properties = new Dictionary<string, string> {
                        { "Category", "Music" },
                        { "Wifi", "On" }
                    };
                    Crashes.TrackError(exception, properties);
                }*/

            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartDownloader.Models
{
    public class GalleryFolder
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string DisplayName { get { 
                if(Name!="All")
                    return $"{Name} ({Size})";
                return Name ;
            } }
        public GalleryFolder(string id,string name,int size) {
            Id = id;
            Name = name;
            Size = size;
        }
    }
}

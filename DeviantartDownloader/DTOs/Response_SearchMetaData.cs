using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartDownloader.DTOs {
    public class Response_SearchMetaData {
        public ICollection<Content_MetaDataAPI> metadata {
            get; set;
        }
    }
}

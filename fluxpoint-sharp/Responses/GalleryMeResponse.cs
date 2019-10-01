using System;
using System.Collections.Generic;
using System.Text;

namespace fluxpoint_sharp
{
    public class GalleryMeResponse : IResponse
    {
        public int id;
        public string username;
        public AlbumInfo album = null;
        public class AlbumInfo
        {
            public int id;
            public int totalImages;
            public bool isPrivate;
            public string url;
        }
    }
}

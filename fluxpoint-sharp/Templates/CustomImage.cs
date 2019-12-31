using System.Collections.Generic;

namespace fluxpoint_sharp
{
    public class CustomImage : ITemplate
    {
        public string output = "jpg";
        public CanvasImage Base = new CanvasImage();
        public IList<CanvasImage> Images = new List<CanvasImage>();
        public IList<CanvasText> Texts = new List<CanvasText>();

        public class CanvasImage
        {
            public string url;
            public string type;
            public int width = 0;
            public int height = 0;
            public int x = 0;
            public int y = 0;
            public int round = 0;
            public int radius = 0;
            public string color = "";
            public string cut = "";
        }
        public class CanvasText
        {
            public string text;
            public int size = 16;
            public string font = "Sans Serif";
            public string color = "#FFFFFF";
            public int x = 0;
            public int y = 0;
            public string outlinecolor = "#FFFFFF";
            public int outline = 0;
            public string blend = "";
            public bool bold = false;
            public bool unicode = false;
        }
    }
}

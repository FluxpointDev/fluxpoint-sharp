using System.Collections.Generic;

namespace fluxpoint_sharp
{
    public class CustomImage : ITemplate
    {
        public string output = "jpg";
        public CanvasImage Base = new CanvasImage();
        public IList<CanvasImage> Images = new List<CanvasImage>();
        public IList<CanvasText> Texts = new List<CanvasText>();
    }

    public class CanvasImage
    {
        public string url;
        public string type;
        public int width = 0;
        public int height = 0;
        public int maxwidth = 0;
        public int maxheight = 0;
        public bool cache = false;
        public int x = 0;
        public int y = 0;
        public int round = 0;
        public int radius = 0;
        public string color = "";
        public string cut = "";
        public string filter = "";
        public int opacity = 10;
    }

    public class CanvasText
    {
        public string text;
        public string[] texts = null;
        public int size = 16;
        public string font = "Sans Serif";
        public string color = "white";
        public string back = "";
        public int x = 0;
        public int y = 0;
        public string align = "";
        public string outlinecolor = "black";
        public bool outline = false;
        public int outlinewidth = 5;
        public int outlineblur = 0;
        public string blend = "";
        public bool bold = false;
        public bool italics = false;
        public bool underline = false;
        public double line = 1;
        public int weight = 500;
        /// <summary>
        /// Max width of the text untill it splits to a new line
        /// </summary>
        public int width = 0;
    }
}

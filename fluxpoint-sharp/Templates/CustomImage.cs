using System.Collections.Generic;

namespace fluxpoint_sharp;

public class CustomImage : ITemplate
{
    public string output { get; set; } = "jpg";
    public CanvasImage Base { get; set; } = new CanvasImage();
    public IList<CanvasImage> Images { get; set; } = new List<CanvasImage>();
    public IList<CanvasText> Texts { get; set; } = new List<CanvasText>();
}

public class CanvasImage
{
    public string url { get; set; }
    public string type { get; set; }
    public int width { get; set; } = 0;
    public int height { get; set; } = 0;
    public int size { get; set; } = 0;
    public int maxwidth { get; set; } = 0;
    public int maxheight { get; set; } = 0;
    public bool cache { get; set; } = false;
    public int x { get; set; } = 0;
    public int y { get; set; } = 0;
    public int round { get; set; } = 0;
    public int radius { get; set; } = 0;
    public int rotate { get; set; } = 0;
    public string path { get; set; }
    public string icon { get; set; }
    public string color { get; set; }
    public string cut { get; set; }
    public string filter { get; set; }
    public int opacity { get; set; } = 10;
    public bool skip { get; set; } = false;
}

public class CanvasText
{
    public string text { get; set; }
    public string[] texts { get; set; } = null;
    public int size { get; set; } = 16;
    public string font { get; set; } = "Sans Serif";
    public string color { get; set; } = "white";
    public string back { get; set; }
    public int x { get; set; } = 0;
    public int y { get; set; } = 0;
    public string align { get; set; }
    public string outlinecolor { get; set; } = "black";
    public int outlinewidth { get; set; } = 5;
    public int outlineblur { get; set; } = 0;
    public string blend { get; set; }
    public bool bold { get; set; } = false;
    public bool italics { get; set; } = false;
    public bool underline { get; set; } = false;
    public double line { get; set; } = 1;
    public int weight { get; set; } = 500;
    /// <summary>
    /// Max width of the text untill it splits to a new line
    /// </summary>
    public int width { get; set; } = 0;
    public bool skip { get; set; } = false;
    public long unix { get; set; } = 0;
    public long snowflake { get; set; } = 0;
    public string format { get; set; }
}

public class CanvasGlobal
{
    public int textSize { get; set; } = 16;
    public string textColor { get; set; } = "white";
    public string textFont { get; set; } = "Sans Serif";
    public int textOutineWidth { get; set; } = 0;
    public string TextOutlineColor { get; set; } = "black";
    public int textOutlineBlur { get; set; }
    public string textAlign { get; set; }
    public int textX { get; set; } = 0;
}

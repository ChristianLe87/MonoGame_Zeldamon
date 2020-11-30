using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Dialog : IEntity
    {
        public string[] text;
        public string actualText;
        public Texture2D texture { get; set; }
        //Button button;
        public SpriteFont font;
        public Rectangle rectangle { get; set; }
        public string tag { get; private set; }
        public Layer layer { get; }

        public bool isKeyRelease;


        public Dialog(Inpc npc, Rectangle rectangle, Layer layer, string tag)
        {
            this.tag = tag;
            this.text = npc.text;
            this.actualText = npc.text[0];
            this.texture = Tools.CreateColorTexture(Color.LightBlue);
            //this.button = new Button(this);// new Rectangle(rectangle.Center.X - (WK.Default.Pixels_X / 2), rectangle.Y + (rectangle.Height - WK.Default.Pixels_Y), WK.Default.Pixels_X, WK.Default.Pixels_Y));
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Font.Arial_20);
            this.rectangle = rectangle;
            this.isKeyRelease = true;
            this.layer = layer;
        }
    }
}

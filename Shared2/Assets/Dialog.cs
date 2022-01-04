using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Dialog : IEntity
    {
        public string[] text;
        public string actualText;
        public Texture2D texture { get; set; }
        public SpriteFont font;
        public Rectangle rectangle { get; set; }

        public Layer layer { get; }

        public bool isKeyRelease;

        public Dialog(Inpc npc, Rectangle rectangle)
        {
            this.text = npc.text;
            this.actualText = npc.text[0];
            this.texture = Tools.CreateColorTexture(Color.LightBlue);
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Font.Arial_20);
            this.rectangle = rectangle;
            this.isKeyRelease = true;
            this.layer = layer;
        }
    }
}

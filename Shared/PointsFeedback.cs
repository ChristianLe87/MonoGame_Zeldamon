using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public abstract class PointsFeedback : IEntity, IAutoDestroy, IPointsFeedback
    {
        public abstract string tag{ get; set; }
        public abstract Layer layer { get; set; }
        public abstract int timeToDestroy { get; set; }
        public abstract bool isAlive { get; set; }
        public abstract Text text { get; set; }
        public abstract Rectangle rectangle { get; set; }
        public abstract Texture2D texture { get; set; }
    }

    public class My_PointFeedback : PointsFeedback
    {
        public override string tag { get; set; }
        public override Text text { get; set; }
        public override Rectangle rectangle { get; set; }
        public override Layer layer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int timeToDestroy { get; set; }
        public int actualTime { get; set; }
        public override bool isAlive { get; set; }
        public override Texture2D texture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public My_PointFeedback(Point position, string text, string tag)
        {
            this.text = new Text(text, new Vector2(position.X, position.Y), "text", Layer.Front);
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.tag = tag;
            this.timeToDestroy = 60;
            this.isAlive = true;
        }
    }

    public class PointsFeedbackHelper
    {
        public static void Update(My_PointFeedback pointsFeedback)
        {
            if(pointsFeedback.isAlive == true)
            {
                pointsFeedback.text.position.Y = pointsFeedback.text.position.Y - 0.5f;
                pointsFeedback.actualTime++;
                if (pointsFeedback.actualTime > pointsFeedback.timeToDestroy) pointsFeedback.isAlive = false;
            }
            
        }

        public static void Draw(SpriteBatch spriteBatch, PointsFeedback pointsFeedback)
        {
            if (pointsFeedback.isAlive == true)
            {
                TextHelper.Draw(spriteBatch, pointsFeedback.text);
            }
        }
    }

}

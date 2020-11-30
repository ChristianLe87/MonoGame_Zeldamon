﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class PointsFeedback : IEntity, IAutoDestroy, IPointsFeedback
    {
        public Text text { get; set; }
        public Rectangle rectangle { get; set; }
        public int timeToDestroy { get; set; }
        public int actualTime { get; set; }
        public bool isAlive { get; set; }
        public Texture2D texture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PointsFeedback(Point position, string text)
        {
            this.text = new Text(text, new Vector2(position.X, position.Y));
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.timeToDestroy = 60;
            this.isAlive = true;
        }
    }
}
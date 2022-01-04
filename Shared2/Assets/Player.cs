﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Player : IEntity
    {
        public Dictionary<string, Texture2D> textures;
        public PlayerState playerState;
        public Rectangle rectangle { get; set; }
        public Rectangle frontIntesection { get => GetFrontIntesection(); }
        public CharacterDirecction characterDirecction = CharacterDirecction._null;
        public int money { get; set; }

        public Layer layer { get; }

        public Flash flash;

        public Player(Point startPosition, Layer layer)
        {
            this.flash = new Flash();
            this.playerState = PlayerState.IdleDown;

            this.textures = new Dictionary<string, Texture2D>()
            {
                { "texture_IdleUp",  Tools.GetSubtextureFromAtlasTexture(new Point(1, 4)) },
                { "texture_IdleDown" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 1)) },
                { "texture_IdleRight" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 3)) },
                { "texture_IdleLeft" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 2)) },
                { "texture_WalkUp" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 4)) },
                { "texture_WalkDown" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 1)) },
                { "texture_WalkRight" , Tools.GetSubtextureFromAtlasTexture(new Point()) },
                { "texture_WalkLeft" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 2))}
            };

            rectangle = new Rectangle(startPosition.X * WK.Default.Pixels_X, startPosition.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);

            this.layer = layer;

            this.money = 0;
        }

        private Rectangle GetFrontIntesection()
        {
            return playerState switch
            {
                PlayerState.IdleUp => new Rectangle(rectangle.X, rectangle.Y - 1, rectangle.Width, rectangle.Height),
                PlayerState.IdleDown => new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height),
                PlayerState.IdleRight => new Rectangle(rectangle.X + 1, rectangle.Y, rectangle.Width, rectangle.Height),
                PlayerState.IdleLeft => new Rectangle(rectangle.X - 1, rectangle.Y, rectangle.Width, rectangle.Height),
                PlayerState.WalkUp => new Rectangle(rectangle.X, rectangle.Y - 1, rectangle.Width, rectangle.Height),
                PlayerState.WalkDown => new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height),
                PlayerState.WalkRight => new Rectangle(rectangle.X + 1, rectangle.Y, rectangle.Width, rectangle.Height),
                PlayerState.WalkLeft => new Rectangle(rectangle.X - 1, rectangle.Y, rectangle.Width, rectangle.Height),
            };
        }
    }
}
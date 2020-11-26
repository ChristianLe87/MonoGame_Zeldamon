﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Player : IEntity
    {
        public Dictionary<string, Texture2D> textures;
        public PlayerState playerState;
        public Rectangle rectangle;
        public CharacterDirecction characterDirecction = CharacterDirecction._null;
        public string tag { get; private set; }
        public int money { get; set; }
        public Layer layer { get; }

        public Player(Point startPosition, Layer layer, string tag)
        {
            this.tag = tag;
            this.playerState = PlayerState.IdleDown;
            this.layer = layer;

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

            this.money = 0;
        }
    }
}

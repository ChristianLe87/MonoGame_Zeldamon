using System.Collections.Generic;
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

        public Player(Point startPosition, string tag)
        {
            this.tag = tag;
            this.playerState = PlayerState.IdleDown;

            this.textures = new Dictionary<string, Texture2D>()
            {
                { "texture_IdleUp",  Tools.GetTexture(WK.Content.Texture.Player.Idle_Up, WK.Content.Folder.Player) },
                { "texture_IdleDown" , Tools.GetTexture(WK.Content.Texture.Player.Idle_Down, WK.Content.Folder.Player) },
                { "texture_IdleRight" , Tools.GetTexture(WK.Content.Texture.Player.Idle_Right, WK.Content.Folder.Player) },
                { "texture_IdleLeft" , Tools.GetTexture(WK.Content.Texture.Player.Idle_Left, WK.Content.Folder.Player) },
                { "texture_WalkUp" , Tools.GetTexture(WK.Content.Texture.Player.Walk_Up, WK.Content.Folder.Player) },
                { "texture_WalkDown" , Tools.GetTexture(WK.Content.Texture.Player.Walk_Down, WK.Content.Folder.Player) },
                { "texture_WalkRight" , Tools.GetTexture(WK.Content.Texture.Player.Walk_Right, WK.Content.Folder.Player) },
                { "texture_WalkLeft" , Tools.GetTexture(WK.Content.Texture.Player.Walk_Left, WK.Content.Folder.Player)}
            };

            rectangle = new Rectangle(startPosition.X, startPosition.Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);

            this.money = 0;
        }
    }
}

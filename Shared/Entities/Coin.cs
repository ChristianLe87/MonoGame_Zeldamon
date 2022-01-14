using System;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Coin : IEntity
    {
        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public int health { get; }

        public Animation animation { get; }
        public CharacterState characterState { get; set; }

        public DxEntityUpdateSystem dxEntityUpdateSystem { get; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; }

        public Coin(Texture2D texture, Vector2 centerPosition)
        {
            this.rigidbody = new Rigidbody(centerPosition, this);
            this.isActive = true;
            this.animation = new Animation(texture);

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
        }

        private void UpdateSystem()
        {
            if (isActive)
            {
                Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

                if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
                {
                    isActive = false;
                    ChristianGame.gameData.coins++;
                }
            }
        }
    }
}
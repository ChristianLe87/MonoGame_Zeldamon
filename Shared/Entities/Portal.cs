using System;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Portal : IEntity
    {
        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public int health { get; }

        public Animation animation { get; }
        public CharacterState characterState { get; set; }

        public DxEntityUpdateSystem dxEntityUpdateSystem { get; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; }

        private string targetScene;
        private Vector2 targetPlayerPosition;

        public Portal(Vector2 centerPosition, Texture2D texture2D, string targetScene, Vector2 targetPlayerPosition)

        {
            this.targetPlayerPosition = targetPlayerPosition;
            this.targetScene = targetScene;

            this.rigidbody = new Rigidbody(centerPosition, this);
            this.isActive = true;
            this.animation = new Animation(texture2D);

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
        }

        private void UpdateSystem()
        {
            Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

            if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
            {
                ChristianGame.ChangeToScene(targetScene, targetPlayerPosition);
            }
        }
    }
}
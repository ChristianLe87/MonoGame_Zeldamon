using System;
using System.Linq;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Portal : Entity
    {
        private string targetScene;
        private Vector2 targetPlayerPosition;

        public Portal(Vector2 position, Texture2D texture2D, string targetScene, Vector2 targetPlayerPosition) : base(texture2D, position)
        {
            this.targetPlayerPosition = targetPlayerPosition;
            this.targetScene = targetScene;

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Update();
        }

        private void Update()
        {
            Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

            if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
            {
                ChristianGame.ChangeToScene(targetScene, targetPlayerPosition);
            }
        }
    }
}
using System;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Key : Entity
    {
        public Key(Texture2D texture, Vector2 centerPosition) : base(texture, centerPosition)
        {
            base.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Update();
        }

        private void Update()
        {
            if (isActive)
            {
                Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

                if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
                {
                    isActive = false;

                    ChristianGame.gameData.pickable_key1 = false;
                    ChristianGame.gameData.ui_key1 = true;

                    ChristianGame.GetScene.UIs.Add(new Image(texture: WK.Textures.Other.key, new Vector2(40, 20), ChristianGame.GetScene.camera, "key1"));
                }
            }
        }
    }
}
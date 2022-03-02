using System;
using ChristianTools.Components;
using ChristianTools.Entities;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Key : IEntity
    {
        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public int health { get; }

        public Animation animation { get; }
        public CharacterState characterState { get; set; }

        public DxUpdateSystem dxUpdateSystem { get; private set; }
        public DxDrawSystem dxDrawSystem { get; }

        public Key(Texture2D texture, Vector2 centerPosition)
        {
            this.rigidbody = new Rigidbody(centerPosition, this);
            this.isActive = true;
            this.animation = new Animation(texture);

            this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
        }

        private void UpdateSystem()
        {
            if (isActive)
            {
                Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

                if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
                {
                    isActive = false;

                    ChristianGame.gameData.key1_entity_isVisible = false;
                    ChristianGame.gameData.key1_ui_isVisible = true;

                    ChristianGame.GetScene.UIs.Add(new Image(texture: WK.Textures.Other.key, new Vector2(40, 20), "key1"));
                }
            }
        }
    }
}
﻿using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Player : IEntity
    {
        public Animation animation { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public CharacterState characterState { get; set; }
        public bool isActive { get; set; }
        public string tag { get; private set; }
        public int health { get; private set; }
        public ExtraComponents extraComponents { get; set; }

        public DxEntityInitializeSystem dxEntityInitializeSystem { get; private set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }

        public Player(Vector2 centerPosition, CharacterState initialState)
        {
            this.animation = new Animation(WK.Textures.Player.animations);
            this.rigidbody = new Rigidbody(centerPosition, this);
            this.isActive = true;

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Update(inputState);

            this.characterState = initialState;
            this.isActive = true;
            this.tag = "player";
        }

        int frameCount = 0;
        private void Update(InputState inputState)
        {
            if (frameCount < 30)
            {
                frameCount++;
            }
            else
            {
                Systems.Update.Player.Zeldamon_Movement(inputState, this, WK.Default.ScaleFactor, WK.Default.AssetSize);
            }
        }
    }
}
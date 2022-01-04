﻿using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Systems;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class Player : IEntity
    {
        public Animation animation { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public CharacterState characterState { get; set; }
        public bool isActive { get; private set; }
        public string tag { get; private set; }
        public int health { get; private set; }
        public ExtraComponents extraComponents { get; set; }

        public DxEntityInitializeSystem dxEntityInitializeSystem { get; private set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }

        public Player(Vector2 centerPosition)
        {
            this.animation = new Animation(WK.Textures.Pink);
            this.rigidbody = new Rigidbody(centerPosition, this);
            //this.characterState = CharacterState.IdleDown;
            this.isActive = true;

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Update(inputState);
        }


        private void Update(InputState inputState)
        {
            Systems.Update.Player.Basic_XY_Movement(inputState, this, WK.Default.ScaleFactor);
        }
    }
}
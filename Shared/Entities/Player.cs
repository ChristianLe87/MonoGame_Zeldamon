using System;
using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



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

            this.characterState = CharacterState.IdleDown;
        }


        private void Update(InputState inputState)
        {
            // Implementation
            {
                Move();
            }
            

            // Helpers
            void Move()
            {
                if (inputState.Up || characterState == CharacterState.MoveUp)
                {
                    rigidbody.Move_Y(-WK.Default.ScaleFactor);

                    // move until player until alligne with tile
                    if (rigidbody.rectangle.Y % WK.Default.AssetSize * WK.Default.ScaleFactor != 0)
                        characterState = CharacterState.MoveUp;
                    else
                        characterState = CharacterState.IdleUp;
                }
                else if (inputState.Down || characterState == CharacterState.MoveDown)
                {
                    rigidbody.Move_Y(WK.Default.ScaleFactor);

                    // move until player until alligne with tile
                    if (rigidbody.rectangle.Y % WK.Default.AssetSize * WK.Default.ScaleFactor != 0)
                        characterState = CharacterState.MoveDown;
                    else
                        characterState = CharacterState.IdleDown;
                }
                else if (inputState.Right || characterState == CharacterState.MoveRight)
                {
                    rigidbody.Move_X(WK.Default.ScaleFactor);

                    // move until player until alligne with tile
                    if (rigidbody.rectangle.X % WK.Default.AssetSize * WK.Default.ScaleFactor != 0)
                        characterState = CharacterState.MoveRight;
                    else
                        characterState = CharacterState.IdleRight;
                }
                else if (inputState.Left || characterState == CharacterState.MoveLeft)
                {
                    rigidbody.Move_X(-WK.Default.ScaleFactor);

                    // move until player until alligne with tile
                    if (rigidbody.rectangle.X % WK.Default.AssetSize * WK.Default.ScaleFactor != 0)
                        characterState = CharacterState.MoveLeft;
                    else
                        characterState = CharacterState.IdleLeft;
                }
            }
        }
    }
}
using ChristianTools.Components;
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
        public bool isActive { get; private set; }
        public string tag { get; private set; }
        public int health { get; private set; }
        public ExtraComponents extraComponents { get; set; }

        public DxEntityInitializeSystem dxEntityInitializeSystem { get; private set; }
        public DxEntityUpdateSystem dxEntityUpdateSystem { get; private set; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; private set; }


        public Player(Vector2 centerPosition)
        {
            this.animation = new Animation(WK.Textures.Player.animations);
            this.rigidbody = new Rigidbody(
                new Rectangle(
                    (int)(centerPosition.X),
                    (int)(centerPosition.Y),
                    WK.Default.AssetSize * WK.Default.ScaleFactor,
                    WK.Default.AssetSize * WK.Default.ScaleFactor
                )
            );
            this.isActive = true;

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Update(inputState);

            this.characterState = CharacterState.IdleDown;
        }

        private void Update(InputState inputState)
        {
            Systems.Update.Player.Zeldamon_Movement(inputState, this, WK.Default.ScaleFactor, WK.Default.AssetSize);
        }
    }
}
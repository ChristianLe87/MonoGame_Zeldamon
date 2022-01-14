using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Player : IEntity
    {
        public Rigidbody rigidbody { get; }
        public bool isActive { get; set; }
        public string tag { get; }
        public int health { get; }

        public Animation animation { get; }
        public CharacterState characterState { get; set; }

        public DxEntityUpdateSystem dxEntityUpdateSystem { get; }
        public DxEntityDrawSystem dxEntityDrawSystem { get; }

        public Player(Vector2 centerPosition, CharacterState initialState)
        {
            this.animation = new Animation(WK.Textures.Player.animations);
            this.rigidbody = new Rigidbody(centerPosition, this);
            this.isActive = true;

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState) => Update(inputState);

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
using System;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Portal1: IEntity
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


        private string targetScene;

        public Portal1(Vector2 position, Texture2D texture2D, string targetScene)
        {
            this.rigidbody = new Rigidbody(
                new Rectangle(
                    (int)(position.X * WK.Default.AssetSize * WK.Default.ScaleFactor),
                    (int)(position.Y * WK.Default.AssetSize * WK.Default.ScaleFactor),
                    WK.Default.AssetSize * WK.Default.ScaleFactor,
                    WK.Default.AssetSize * WK.Default.ScaleFactor
                )
            );
            this.animation = new Animation(texture2D);

            this.targetScene = targetScene;
            this.isActive = true;

            this.dxEntityUpdateSystem = (InputState lastInputState, InputState inputState, IEntity entity) => Update();
        }

        private void Update()
        {
            Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

            if (player.rigidbody.rectangle.Intersects(rigidbody.rectangle))
            {
                ChristianGame.ChangeToScene(targetScene);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Shared
{
    public class SceneMap2 : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxSceneInitializeSystem dxSceneInitializeSystem { get; private set; }
        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        public void Initialize(Vector2? playerPosition = null)
        {
            int assetSize_x_scaleFactor = WK.Default.AssetSize * WK.Default.ScaleFactor;

            this.camera = new Camera();
            this.entities = new List<IEntity>()
            {
                new Player(playerPosition.Value),
                new Portal(
                    position: new Vector2(
                        4 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        15 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    ),
                    texture2D: WK.Textures.Red,
                    targetScene: WK.Scene.GameScene,
                    targetPlayerPosition: new Vector2(
                        7 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        14 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                )
            };

            this.map = new Map(WK.Textures.Map.Map1.textures, WK.Map.Map2);
            this.dxSceneUpdateSystem = (InputState lastInputState, InputState inputState) => Update();
        }

        private void Update()
        {
            Player player = entities.OfType<Player>().First();
            camera.Update(player.rigidbody.centerPosition);
        }
    }
}
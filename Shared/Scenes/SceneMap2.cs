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

        public void Initialize()
        {
            this.camera = new Camera();
            this.entities = new List<IEntity>()
            {
                new Player(new Vector2(4 * WK.Default.ScaleFactor * WK.Default.AssetSize, 12 * WK.Default.ScaleFactor * WK.Default.AssetSize)),
                new Portal1(new Vector2(4, 13), WK.Textures.Red, WK.Scene.GameScene)
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
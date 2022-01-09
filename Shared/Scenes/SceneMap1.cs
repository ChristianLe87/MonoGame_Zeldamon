using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Shared
{
    public class SceneMap1 : IScene
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
            this.camera = new Camera();
            this.entities = new List<IEntity>()
            {
                new Player(new Vector2(10, 15)),
                new Portal1(new Vector2(7,13), WK.Textures.Red, WK.Scene.House_1, new Vector2(4,14))
            };

            this.map = new Map(WK.Textures.Map.Map1.textures, WK.Map.Map1);
            this.dxSceneUpdateSystem = (InputState lastInputState, InputState inputState) => Update();
        }

        private void Update()
        {
            Player player = entities.OfType<Player>().First();
            camera.Update(player.rigidbody.centerPosition);
        }
    }
}
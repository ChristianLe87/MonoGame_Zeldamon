using System.Collections.Generic;
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

        public void Initialize()
        {
            this.entities = new List<IEntity>()
            {
                new Player(new Vector2(10*WK.Default.ScaleFactor*WK.Default.AssetSize, 15*WK.Default.ScaleFactor*WK.Default.AssetSize))
            };

            this.map = new Map(WK.Textures.Map.Map1.textures, WK.Map.Map1);
        }
    }
}
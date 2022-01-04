using System.Collections.Generic;
using ChristianTools.Components;
using ChristianTools.Helpers;
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
        }
    }
}
using System.Collections.Generic;
using ChristianTools;
using ChristianTools.Helpers;

namespace Shared
{
    public class Game1 : ChristianGame
    {
        public Game1() : base(WK.Default.GameDataFileName)
        {
            Dictionary<string, IScene> scenes = new Dictionary<string, IScene>()
            {
                { WK.Scene.Menu, new Factory.SceneMenu(WK.Font.MyFont, WK.Scene.GameScene) },
                { WK.Scene.GameScene, new SceneMap1() },
                { WK.Scene.House_1,  new SceneMap2() },
                { WK.Scene.Cave, new SeneCave() }
            };
            
            base.SetupScenes(scenes, WK.Scene.GameScene);
        }
    }
}
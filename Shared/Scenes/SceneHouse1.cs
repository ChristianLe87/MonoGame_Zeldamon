using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Shared
{
    public class SceneHouse1 : IScene
    {
        public GameState gameState { get; private set; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        public List<SoundEffect> soundEffects { get; private set; }
        public Camera camera { get; private set; }
        public Map map { get; private set; }

        public DxUpdateSystem dxUpdateSystem { get; private set; }
        public DxDrawSystem dxDrawSystem { get; }

        public List<Light> lights { get; set; }
        int frameCount = 0;

        public void Initialize(Vector2? playerPosition = null)
        {
            int assetSize_x_scaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;


            this.camera = new Camera();

            this.UIs = Helpers.GetGameUI();
            //this.UIs.Add(new Transition.FadeIn());

            this.entities = new List<IEntity>()
            {
                new Player(playerPosition.Value, CharacterState.IdleUp),
                new Portal(
                    centerPosition: new Vector2(
                        2 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        5 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    ),
                    texture2D: WK.Textures.Red,
                    targetScene: WK.Scene.GameScene,
                    targetPlayerPosition: new Vector2(
                        5 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        18 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),

            };

            if (ChristianGame.gameData.hammer_entity_isVisible == true)
                entities.Add(
                    new Hammer(
                        texture: WK.Textures.Other.hammer,
                        centerPosition: new Vector2(
                            1 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                            13 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                        )
                    )
                );

            this.map = new Map(textures: WK.Map.House1.textures, tiled: WK.Map.House1.tiled);

            //this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => Update();
        }

        /*private void Update()
        {
            Label coin = UIs.OfType<Label>().Where(x => x.tag == "coin").First();
            coin.UpdateText($"Coins: {ChristianGame.gameData.coins}");
        }*/
    }
}
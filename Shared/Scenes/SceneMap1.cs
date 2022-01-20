using System.Collections.Generic;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.UI;
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

        public DxSceneUpdateSystem dxSceneUpdateSystem { get; private set; }
        public DxSceneDrawSystem dxSceneDrawSystem { get; private set; }

        int frameCount = 0;

        public void Initialize(Vector2? playerPosition = null)
        {
            int assetSize_x_scaleFactor = ChristianGame.Setup.AssetSize * ChristianGame.Setup.ScaleFactor;

            if (playerPosition == null)
            {
                playerPosition = new Vector2(
                    10 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                    15 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                );
            }

            this.camera = new Camera();

            this.UIs = Helpers.GetGameUI();
            UIs.Add(new Transition.FadeIn());

            UIs.Add(
                new Minimimap(
                    WK.Textures.Map.Map0.minimapColors,
                    WK.Map.Map1,
                    new Vector2(
                        24 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        1 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    ),
                    ChristianGame.Setup.ScaleFactor
                )
            );

            this.entities = new List<IEntity>()
            {
                new Player(playerPosition.Value, CharacterState.IdleDown),
                new Portal(
                    centerPosition: new Vector2(
                        7 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        13 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    ),
                    texture2D: WK.Textures.Transparent,
                    targetScene: WK.Scene.House_1,
                    targetPlayerPosition: new Vector2(
                        4 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        14 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),


                new Coin(
                    WK.Textures.Other.coin,
                    new Vector2(
                        8 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        15 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),

                new Coin(
                    WK.Textures.Other.coin,
                    new Vector2(
                        8 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        16 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),
                new Coin(
                    WK.Textures.Other.coin,
                    new Vector2(
                        8 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        17 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),

                new Coin(
                    WK.Textures.Other.coin,
                    new Vector2(
                        9 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        15 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),

                new Coin(
                    WK.Textures.Other.coin,
                    new Vector2(
                        9 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        16 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),
                new Coin(
                    WK.Textures.Other.coin,
                    new Vector2(
                        9 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        17 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),
            };

            if (ChristianGame.gameData.key1_entity_isVisible == true)
                entities.Add(new Key(WK.Textures.Other.key, new Vector2(100, 100)));


            this.map = new Map(WK.Textures.Map.Map1.textures, WK.Map.Map1);

            this.map.tiles.Add(
                new KeyDoor(
                    WK.Textures.Other.keyDoor,
                    new Rectangle(
                        7 * assetSize_x_scaleFactor,
                        13 * assetSize_x_scaleFactor,
                        WK.Textures.Other.keyDoor.Width,
                        WK.Textures.Other.keyDoor.Height
                    ),
                    "keyDoor"
                )
            );

            this.dxSceneUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
        }

        private void UpdateSystem()
        {
            Label coin = UIs.OfType<Label>().Where(x => x.tag == "coin").First();
            coin.UpdateText($"Coins: {ChristianGame.gameData.coins}");
        }
    }
}
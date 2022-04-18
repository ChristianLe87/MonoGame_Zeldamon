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

        public DxUpdateSystem dxUpdateSystem { get; private set; }
        public DxDrawSystem dxDrawSystem { get; }
        public List<Light> lights { get; set; }

        int frameCount = 0;

        public void Initialize(Vector2? playerPosition = null)
        {
            int assetSize_x_scaleFactor = ChristianGame.Default.AssetSize * ChristianGame.Default.ScaleFactor;

            if (playerPosition == null)
            {
                playerPosition = new Vector2(
                    5 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                    20 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                );
            }

            this.camera = new Camera();

            Player player = new Player(playerPosition.Value, CharacterState.IdleDown);

            this.UIs = Helpers.GetGameUI();
            UIs.Add(new Transition.FadeIn());

            /*UIs.Add(
                new Minimimap(
                    WK.Textures.Map.Map0.minimapColors,
                    WK.Map.Map1,
                    new Vector2(
                        24 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        1 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    ),
                    ChristianGame.Default.ScaleFactor,
                    player
                )
            );*/

            this.entities = new List<IEntity>()
            {
                player,
                new Portal(
                    centerPosition: new Vector2(
                        5 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        17 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    ),
                    texture2D: WK.Textures.Transparent,
                    targetScene: WK.Scene.House1,
                    targetPlayerPosition: new Vector2(
                        2 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2),
                        4 * assetSize_x_scaleFactor + (assetSize_x_scaleFactor / 2)
                    )
                ),


                /*new Coin(
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
                ),*/
            };

            if (ChristianGame.gameData.key1_entity_isVisible == true)
                entities.Add(new Key(WK.Textures.Other.key, new Vector2(100, 100)));

            this.map = new Map(textures: WK.Map.Map1.textures, tiled: WK.Map.Map1.tiled);

            /*this.map.tiles.Add(
                new KeyDoor(
                    WK.Textures.Other.keyDoor,
                    new Rectangle(
                        7 * assetSize_x_scaleFactor,
                        13 * assetSize_x_scaleFactor,
                        WK.Textures.Other.keyDoor.Width,
                        WK.Textures.Other.keyDoor.Height
                    )
                )
            );*/

            //this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
        }

        private void UpdateSystem()
        {
            /*Label coin = UIs.OfType<Label>().Where(x => x.tag == "coin").First();
            coin.UpdateText($"Coins: {ChristianGame.gameData.coins}");*/
        }
    }
}
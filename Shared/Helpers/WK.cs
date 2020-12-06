namespace Shared
{
    public class WK
    {
        public class Default
        {
            public static readonly double FPS = 60;
            public static readonly int CanvasWidth = 500;
            public static readonly int CanvasHeight = 500;

            public static readonly int Pixels_X = 16;
            public static readonly int Pixels_Y = 16;
        }

        public class Content
        {
            public class Folder
            {
                public static readonly string Player = "Player";
                public static readonly string Flash = "Flash";
                public static readonly string Cartas = "Cartas";
            }

            public class Font
            {
                public static readonly string Arial_20 = "Arial_20";
            }

            public class Texture
            {
                public class GeneralCollection
                {
                    public static readonly string TileCollection = "TileCollection_PNG_352x288";
                }

                public class Player
                {
                    public static readonly string Idle_Up = "Player_Idle_Up";
                    public static readonly string Idle_Down = "Player_Idle_Down";
                    public static readonly string Idle_Right = "Player_Idle_Right";
                    public static readonly string Idle_Left = "Player_Idle_Left";
                    public static readonly string Walk_Up = "Player_Walk_Up";
                    public static readonly string Walk_Down = "Player_Walk_Down";
                    public static readonly string Walk_Right = "Player_Walk_Right";
                    public static readonly string Walk_Left = "Player_Walk_Left";
                }

                public class UI
                {
                    public static readonly string X_Button = "X_Button_PNG_16x16";
                }

                public class Other
                {
                    public static readonly string Coin = "Coin_PNG_10x10";
                }

                public class Card
                {
                    public static readonly string Carta_0 = "Carta_0_48x64_PNG";
                    public static readonly string Carta_1 = "Carta_1_48x64_PNG";
                    public static readonly string Carta_2 = "Carta_2_48x64_PNG";
                    public static readonly string Carta_3 = "Carta_3_48x64_PNG";
                    public static readonly string Carta_4 = "Carta_4_48x64_PNG";
                    public static readonly string Carta_5 = "Carta_5_48x64_PNG";
                    public static readonly string Carta_6 = "Carta_6_48x64_PNG";
                    public static readonly string Carta_7 = "Carta_7_48x64_PNG";
                    public static readonly string Carta_8 = "Carta_8_48x64_PNG";
                    public static readonly string Carta_9 = "Carta_9_48x64_PNG";
                }

                public class Flash
                {
                    public static readonly string FlashDayOn_Down_720x720_PNG = "FlashDayOn_Down_720x720_PNG";
                    public static readonly string FlashDayOn_Left_720x720_PNG = "FlashDayOn_Left_720x720_PNG";
                    public static readonly string FlashDayOn_Right_720x720_PNG = "FlashDayOn_Right_720x720_PNG";
                    public static readonly string FlashDayOn_Up_720x720_PNG = "FlashDayOn_Up_720x720_PNG";
                    public static readonly string FlashNightOff_720x720_PNG = "FlashNightOff_720x720_PNG";
                    public static readonly string FlashNightOn_Down_720x720_PNG = "FlashNightOn_Down_720x720_PNG";
                    public static readonly string FlashNightOn_Left_720x720_PNG = "FlashNightOn_Left_720x720_PNG";
                    public static readonly string FlashNightOn_Up_720x720_PNG = "FlashNightOn_Up_720x720_PNG";
                    public static readonly string FlashNightOn_Right_720x720_PNG = "FlashNightOn_Right_720x720_PNG";
                }
            }
        }

        public class Scene
        {
            public static readonly string About = "About";
            public static readonly string GameScene = "GameScene";
            public static readonly string House_1 = "House_1";
            public static readonly string Cave = "Cave";
            public static readonly string Menu = "Menu";
        }

        public class Map
        {
            public static char[,] Map1 = new char[,]
            {
                { 'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','x','x','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','x','x','x','x','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','x','x','x','.','.','.','.','.','.','.','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','x','-','x','.','.','.','.','.','.','.','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','x','x','x','.','.','.','.','.','.','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','x','-','x','.','.','.','.','.','.','x','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','x','x','x','x','x','x','x','x','x','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','x' },
                { 'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' }
            };

            public static char[,] Map2 = new char[,]
            {
                { 'x','x','x','x','x','x','x','x','x','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','x','x','x','x','.','.','x' },
                { 'x','.','.','.','.','.','x','.','.','x' },
                { 'x','.','.','.','.','.','x','.','.','x' },
                { 'x','.','.','x','x','x','x','.','.','x' },
                { 'x','.','.','x','.','.','.','.','.','x' },
                { 'x','.','.','x','.','.','.','.','.','x' },
                { 'x','.','.','x','.','.','.','.','.','x' },
                { 'x','.','.','x','x','x','x','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','x','x','x','-','x','x','x','x','x' }
            };

            public static char[,] Cave = new char[,]
            {
                { 'x','x','x','x','x','x','x','x','x','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','x','x','x','x','.','.','x' },
                { 'x','.','.','.','.','.','x','.','.','x' },
                { 'x','.','.','.','.','.','x','.','.','x' },
                { 'x','.','.','.','x','x','x','.','.','x' },
                { 'x','.','.','.','.','.','x','.','.','x' },
                { 'x','.','.','.','.','.','x','.','.','x' },
                { 'x','.','.','.','.','.','x','.','.','x' },
                { 'x','.','.','x','x','x','x','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','.','.','.','.','.','.','.','.','x' },
                { 'x','x','x','x','-','x','x','x','x','x' }
            };
        }
    }
}
using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
	public class KeyDoor : ITile
	{
        public Texture2D texture { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        public bool isActive { get; set; }

		public DxUpdateSystem dxUpdateSystem { get; }
		public DxDrawSystem dxDrawSystem { get; }

		public KeyDoor(Texture2D texture2D, Rectangle rectangle, string tag)
		{
			this.rigidbody = new Rigidbody(rectangle);
			this.texture = texture2D;
			this.isActive = true;

			this.dxUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSyste(lastInputState, inputState);
		}

		private void UpdateSyste(InputState lastInputState, InputState inputState)
		{
			if (isActive == false)
				return;

			Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

			if (rigidbody.rectangle.Intersects(player.rigidbody.rectangleUp(ChristianGame.Default.ScaleFactor)))
			{
				if (lastInputState.Action == false && inputState.Action == true)
				{
					if (ChristianGame.gameData.key1_ui_isVisible == true)
					{
						isActive = false;
					}
				}
			}
		}

        public Color GetShadow(List<Light> lights)
        {
			//throw new NotImplementedException();
			return Shadow.Shadow_0;
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IPickable : IEntity
    {
        public bool isActive { get; set; }
        public Rectangle rectangle { get; set; }
        public Texture2D texture { get; set; }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IEntity
    {
        public string tag { get; }
        Layer layer { get; }
        Rectangle rectangle { get; }
        public Texture2D texture { get; }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IEntity
    {
        Rectangle rectangle { get; }
        Texture2D texture { get; }
    }
}

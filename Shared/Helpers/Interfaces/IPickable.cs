using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IPickable
    {
        bool isActive { get; }
        Rectangle rectangle { get; }
        Texture2D texture { get; }
    }
}

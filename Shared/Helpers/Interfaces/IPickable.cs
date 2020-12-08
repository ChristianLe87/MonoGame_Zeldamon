using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IPickable: IEntity
    {
        bool isActive { get; set; }
        Texture2D texture { get; }
    }
}

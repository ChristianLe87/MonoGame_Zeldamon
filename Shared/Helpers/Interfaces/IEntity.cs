using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IEntity
    {
        Layer layer { get; }
        Rectangle rectangle { get; }
    }
}

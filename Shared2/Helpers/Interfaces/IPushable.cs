using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IPushable : IEntity
    {
        Texture2D texture2D { get; }
        Rectangle areaOfIntersection { get; }
        Pushable_MoveDirection pushable_State { get; set; }
    }
}

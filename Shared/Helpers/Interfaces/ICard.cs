using System;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface ICard : IEntity
    {
        Texture2D texture2D { get; }
    }
}

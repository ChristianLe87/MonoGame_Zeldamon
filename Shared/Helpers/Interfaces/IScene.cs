using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public interface IScene
    {
        List<IEntity> entities { get; }
        Camera camera { get; }
        int moneyValue { get; }
        Text moneyText { get; }
        bool isDark { get; }
        void Initialize(Point startPlayerPosition);
    }
}
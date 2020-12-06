using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public interface IScene
    {
        List<IEntity> entities { get; set; }
        Camera camera { get; set; }
        int moneyValue { get; set; }
        Text moneyText { get; set; }
        bool isDark { get; set; }
        void Initialize(Point startPlayerPosition);
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public abstract class Scene : IScene
    {
        public abstract List<IEntity> entities { get; set; }
        public abstract Camera camera { get; set; }
        public abstract int moneyValue { get; set; }
        public abstract Text moneyText { get; set; }
        public abstract bool isDark { get; set; }
        public abstract void Initialize(Point startPlayerPosition);
    }
}

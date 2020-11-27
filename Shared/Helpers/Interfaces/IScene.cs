using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public interface IScene
    {
        public List<IEntity> entities { get; set; }
        public Camera camera { get; set; }
        public void Initialize(Point startPlayerPosition);
        public int moneyValue { get; set; }
        public Text moneyText { get; set; }
        public bool isDark { get; }
    }
}

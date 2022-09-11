using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class Collectable : EntityInterface
    {
        bool taken;

        public Collectable(EntityInstanceData data)
        {
            pos = data.Pos;
            depth = data.Depth;
            taken = false;
            id = data.Id;
        }

        public bool Taken
        {
            get { return taken; }
            set { taken = value; }
        }
    }
}

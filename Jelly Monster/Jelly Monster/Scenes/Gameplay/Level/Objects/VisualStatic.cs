using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class VisualStatic : EntityInterface
    {

        public VisualStatic(EntityInstanceData data)
        {
            this.pos = data.Pos;
            this.depth = data.Depth;
            this.id = data.Id;
        }
    }
}

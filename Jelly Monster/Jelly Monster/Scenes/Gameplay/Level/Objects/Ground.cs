using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class Ground : EntityInterface 
    {
        public Ground(EntityInstanceData data)
        {
            pos = data.Pos;
            depth = data.Depth;
            id = data.Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContentData;

namespace Jelly_Monster
{
    public class VisualAnimated : EntityInterface
    {
        byte index;

        public VisualAnimated(EntityInstanceData data)
        {
            this.pos = data.Pos;
            this.depth = data.Depth;
            this.id = data.Id;
        }

        public byte Index
        {
            get { return index; }
            set { index = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class EntityInterface
    {
        protected Vector2 pos;
        protected float depth;
        protected byte id;

        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public byte Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}

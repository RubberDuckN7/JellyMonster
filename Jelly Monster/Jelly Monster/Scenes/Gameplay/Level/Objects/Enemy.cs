using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class Enemy : EntityInterface
    {
        protected EnemyInstanceData core;
        protected Time time;
        protected byte index;
        protected bool facing_front;

        public EnemyInstanceData Core
        {
            get { return core; }
            set { core = value; }
        }

        public Time TimeA
        {
            get { return time; }
            set { time = value; }
        }

        public byte Index
        {
            get { return index; }
            set { index = value; }
        }

        public bool FacingFront
        {
            get { return facing_front; }
            set { facing_front = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class Trigger : EntityInterface
    {
        public CallbackTrigger Event;

        int width;
        int height;

        float force;

        bool activated;

        public Trigger(TriggerData data)
        {
            pos = new Vector2((float)data.Bounds.X, (float)data.Bounds.Y);
            width = data.Bounds.Width;
            height = data.Bounds.Height;

            force = data.Data;

            activated = false;
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Force
        {
            get { return force; }
            set { force = value; }
        }

        public bool Activated
        {
            get { return activated; }
            set { activated = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jelly_Monster
{
    public class Animation
    {
        Texture2D[] textures;

        public Animation(byte count)
        {
            textures = new Texture2D[count];
        }

        public Texture2D this[byte index]
        {
            get { return textures[index]; }
            set { textures[index] = value; }
        }

        public byte Count
        {
            get { return (byte)(textures.Length); }
        }
    }
}

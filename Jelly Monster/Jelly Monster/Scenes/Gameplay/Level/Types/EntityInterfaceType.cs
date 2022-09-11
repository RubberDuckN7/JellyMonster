using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;
using ContentData;

namespace Jelly_Monster
{
    public abstract class EntityInterfaceType
    {
        public virtual void Update(Level level, EntityInterface entity, float dt)
        {

        }

        public virtual void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {

        }
    }
}

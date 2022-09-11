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
    public class TriggerType : EntityInterfaceType
    {
        public EntityInterface CreateInstance(Level level, TriggerData data)
        {
            EntityInterface e = new Trigger(data);
            Trigger trigger = e as Trigger;

            if (data.Type == "Jump")
                trigger.Event += level.Scene.TriggerJump;
            else if (data.Type == "Exit")
                trigger.Event += level.Scene.TriggerExit;

            return e;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            Trigger trigger = entity as Trigger;
            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, trigger.Width, trigger.Height);

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                if (!trigger.Activated)
                {
                    trigger.Activated = true;
                    trigger.Event(trigger.Force, trigger.Id);
                }
            }
            else
            {
                trigger.Activated = false;
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            
        }
    }
}

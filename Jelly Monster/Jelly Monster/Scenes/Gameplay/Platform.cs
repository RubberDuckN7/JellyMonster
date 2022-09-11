using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IrisEngine;

namespace Jelly_Monster
{
    public static class Platform
    {
        public enum Side
        {
            Top,
            Right,
            Left,
            Bottom,
            None
        }

        public static Side CollideObjects(Rectangle obj, Rectangle tile, 
            Vector2 obj_center, Vector2 tile_center, Vector2 prev_pos, 
            out bool moving, out bool falling)
        {
            //obj.Y += 55;
            //obj.Height -= 55;

            Side side = Side.None;

            falling = true;

            float width = (float)(obj.Width);
            float height = (float)(obj.Height);

            moving = true;
            falling = true;

            if (Utility.RectangleVsRectangle(obj, tile))
            {
                if (prev_pos.X + width < tile.X || prev_pos.X > tile.X + tile.Width)
                {
                    moving = false;
                    falling = true;

                    if (obj_center.X < tile_center.X)
                        return Side.Left;
                    else
                        return Side.Right;
                }
                else
                {
                    if (obj_center.Y < tile_center.Y)
                    {
                        falling = false;
                        return Side.Top;
                    }
                    else
                    {
                        falling = true;
                        return Side.Bottom;
                    }
                }
            }

            return side;
        }

        public static Side CollideObjects(Rectangle obj, Rectangle tile, Vector2 prev_pos, bool player_falling,
            out bool moving, out bool falling)
        {
            // For visual colliding
            obj.Y += 25;
            obj.Height -= 25;

            Vector2 obj_center = new Vector2((float)(obj.X + obj.Width * 0.5f), (float)(obj.Y + obj.Height * 0.5f));
            Vector2 tile_center = new Vector2((float)(tile.X + tile.Width * 0.5f), (float)(tile.Y + tile.Height * 0.5f));

            Side side = Side.None;

            falling = true;

            float width = (float)(obj.Width);
            float height = (float)(obj.Height);

            moving = true;
            falling = true;

            if (Utility.RectangleVsRectangle(obj, tile))
            {
                if (prev_pos.X + width < tile.X || prev_pos.X > tile.X + tile.Width)
                {
                    moving = false;
                    falling = true;

                    if (obj_center.X < tile_center.X)
                        return Side.Left;
                    else
                        return Side.Right;
                }
                else
                {
                    if (obj_center.Y < tile_center.Y)
                    {
                        falling = false;
                        return Side.Top;
                    }
                    else
                    {
                        falling = true;
                        return Side.Bottom;
                    }
                }
            }

            return side;
        }

        //public static bool CollideObjects(GroundType [] types,
        //    InstanceObject[] objects, Rectangle wpos, Vector2 vel, out Vector2 out_vel, out Rectangle out_wpos)
        //{
        //    Rectangle wfeet = new Rectangle();
        //    wfeet.X = wpos.X;
        //    wfeet.Y = wpos.Y + wpos.Height - 2;
        //    wfeet.Width = wpos.Width;
        //    wfeet.Height = 5;

        //    Vector2 wcenter = new Vector2();
        //    wcenter.X = (float)(wpos.X + wpos.Width * 0.5f);
        //    wcenter.Y = (float)(wpos.Y + wpos.Height * 0.5f);

        //    bool falling = true;

        //    foreach (InstanceObject obj in objects)
        //    {
        //        Rectangle obj_b = new Rectangle();
        //        obj_b.X = (int)obj.Pos.X;
        //        obj_b.Y = (int)obj.Pos.Y;
        //        obj_b.Width = (int)(types[obj.ID].Extents.X);
        //        obj_b.Height = (int)(types[obj.ID].Extents.Y);

        //        if (falling)
        //        {
        //            falling = CollideObject(obj_b, wpos, wfeet, wcenter, vel, out vel, out wpos);
        //        }
        //        else
        //        {
        //            CollideObject(obj_b, wpos, wfeet, wcenter, vel, out vel, out wpos);
        //        }
        //    }

        //    out_wpos = wpos;
        //    out_vel = vel;

        //    return falling;
        //}

        //private static bool CollideObject(Rectangle obj,
        //    Rectangle wpos, Rectangle wfeet, Vector2 wcenter, 
        //    Vector2 vel, out Vector2 out_vel, out Rectangle out_wpos)
        //{
        //    bool falling = false;

        //    if (Utility.RectangleVsRectangle(wpos, obj))
        //    {
        //        // First check sides, to avoid that "jumping" bug
        //        // Body itself has collided with tile
        //        bool sided = false;
        //        if (wcenter.Y > obj.Y - 10 && wcenter.Y < obj.Y + obj.Height + 10)
        //        {
        //            sided = true;
        //            if (wcenter.X < obj.X)
        //            {
        //                // Left side
        //                vel.X = 0f;
        //                wpos.X = obj.X - wpos.Width - 1;
        //            }
        //            else
        //            {
        //                // Right side
        //                vel.X = 0f;
        //                wpos.X = obj.X + obj.Width + 1;
        //            }
        //        }


        //        // Now check up and down, because it is "inside" of tile
        //        if (!sided)
        //        {
        //            if (wcenter.Y < obj.Y)
        //            {
        //                // On top, but colliding
        //                wpos.Y = obj.Y - wpos.Height;
        //                vel.Y = 0f;
        //                falling = false;
        //            }
        //            else
        //            {
        //                // Under the tile
        //                vel.Y = 2.0f;
        //                wpos.Y = obj.Y + obj.Height + 2;
        //                falling = true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        falling = true;
        //        // If still outside, check feet, can be slightly on the ground
        //        if (Utility.RectangleVsRectangle(wfeet, obj))
        //        {
        //            wpos.Y = obj.Y - wpos.Height;
        //            vel.Y = 0f;
        //            falling = false;
        //        }
        //    }


        //    out_vel = vel;
        //    out_wpos = wpos;

        //    return falling;
        //}
    }
}

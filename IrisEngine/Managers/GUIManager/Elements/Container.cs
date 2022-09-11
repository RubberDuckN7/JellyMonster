using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace IrisEngine
{
    public class Container : IElement
    {
        public class Item
        {
            public Texture2D icon;
            public Vector2 pos;
            public byte id;
            public bool selected;
        }

        public delegate void Callback(byte id, TouchLocationState state);
        public Callback Event;

        EntityScaled entity;
        Texture2D tile_empty;
        Texture2D tile_selected;

        int tile_size;
        byte selected_id;

        List<Item> items;

        public Container(ContainerResources resources, int x, int y, int nr_w, int nr_h, float corner_w, float corner_h, float border_w, float border_h, float tile_size, float tile_spacing)
        {
            this.tile_size = (int)tile_size;

            tile_empty = resources.empty_tile;
            tile_selected = resources.selected_tile;

            int size_w = (int)((nr_w+1)*tile_spacing + nr_w * tile_size + border_w * 2.0f);
            int size_h = (int)((nr_h+1)*tile_spacing + nr_h * tile_size + border_h * 2.0f);

            entity = new EntityScaled(resources.background, new Rectangle(x, y, size_w, size_h), corner_w, corner_h, border_w, border_h);

            float tx = (float)(entity.Bounds.X + border_w + tile_spacing);
            float ty = (float)(entity.Bounds.Y + border_h + tile_spacing);

            items = new List<Item>();

            // Y wise
            for (byte i = 0; i < nr_h; i++)
            {
                // X wise
                for (byte j = 0; j < nr_w; j++)
                {
                    Item item = new Item();
                    item.pos = new Vector2(tx, ty);
                    item.icon = resources.empty_tile;
                    item.id = 255;
                    item.selected = false;

                    items.Add(item);

                    tx += tile_spacing + tile_size;
                }

                tx = (float)(entity.Bounds.X + border_w + tile_spacing);
                ty += tile_spacing + tile_size;
            }

            this.selected_id = 255;
        }

        public override void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            entity.Draw(sp, color, offset);

            Rectangle b = new Rectangle(0, 0, tile_size, tile_size);

            foreach(Item i in items)
            {
                b.X = (int)(i.pos.X + offset.X);
                b.Y = (int)(i.pos.Y + offset.Y);

                //sp.Draw(i.icon, b, color);
                sp.Draw(i.icon, b, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.9f);

                if (i.selected)
                    sp.Draw(tile_selected, b, null, color, 0f, Vector2.Zero, SpriteEffects.None, 1f);
                    //sp.Draw(tile_selected, b, color);
            }
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {
            for (byte i = 0; i < touches.Count; i++)
            {
                Vector2 point = touches[i].Position;

                if (touches[i].State == TouchLocationState.Pressed)
                {
                    if (selected_id != 255)
                    {
                        items[selected_id].selected = false;
                        selected_id = 255;
                    }
                    //selected_id = 255;
                    if (Utility.PointVsRectangle(point, entity.Bounds))
                    {
                        Rectangle b = new Rectangle(0, 0, tile_size, tile_size);

                        for (byte it = 0; it < items.Count; it++)
                        {
                            b.X = (int)items[it].pos.X;
                            b.Y = (int)items[it].pos.Y;

                            //if (selected_id != 255)
                            //    items[selected_id].selected = false;

                            if (items[it].id != 255 && Utility.PointVsRectangle(point, b))
                            {
                                items[it].selected = true;
                                selected_id = it;
                                Event(items[it].id, touches[i].State);
                            }
                        } // Tiles loop
                    } // If in bounds
                } // State if
            } // Touches loop
        }

        public float TileSize
        {
            get { return tile_size; }
        }

        public byte SelectedID
        {
            get 
            {
                if (selected_id == 255)
                    return 255;
                return items[selected_id].id;
            }
        }

        public bool AddItem(Texture2D icon, byte id)
        {
            foreach (Item i in items)
            {
                if (i.id == 255)
                {
                    i.icon = icon;
                    i.id = id;
                    return true;
                }
            }

            return false;
        }

        public void RemoveItem()
        {
            if (selected_id != 255)
            {
                items[selected_id].icon = tile_empty;
                items[selected_id].id = 255;
                items[selected_id].selected = false;
                selected_id = 255;
            }
        }

        public void SetItem(Texture2D icon, byte index,  byte id)
        {
            items[index].icon = icon;
            items[index].id = id;
        }

        public byte[] GetItems()
        {
            List<byte> ids = new List<byte>();

            for (byte i = 0; i < items.Count; i++)
            {
                ids.Add(items[i].id);
            }

            return ids.ToArray();
        }

        public Item[] GetRawItems
        {
            get { return items.ToArray(); }
        }

        public byte LastId()
        {
            byte id = 255;

            for (byte i = (byte)(items.Count - 1); i >= 0; i--)
            {
                if (items[i].id != 255)
                    return items[i].id;
            }

            return id;
        }

    }
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IrisEngine
{
    public class RectangleResources
    {
        public Texture2D background;
        public SpriteFont font;
    }

    public class RScaledResources
    {
        public Texture2D background;
        public Texture2D corner_tl;
        public Texture2D corner_tr;
        public Texture2D corner_bl;
        public Texture2D corner_br;
        public Texture2D border_horizontal;
        public Texture2D border_vertical;
    }

    public class ButtonResources
    {
        public Texture2D background;
        public Texture2D pressed;
        public SpriteFont font;
    }

    public class CheckBoxResources
    {
        public Texture2D background;
        public Texture2D pressed;
    }

    public class SliderResources
    {
        public Texture2D background;
        public Texture2D top;
        public Texture2D bottom;
        public Texture2D handle;
    }

    public class ContainerResources
    {
        public RScaledResources background;
        public Texture2D empty_tile;
        public Texture2D selected_tile;
    }

}

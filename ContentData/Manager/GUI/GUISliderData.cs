using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GUISliderData : ContentObject
    {
        private string background;
        private string top;
        private string bottom;
        private string handle;

        public string Background
        {
            get { return background; }
            set { background = value; }
        }

        public string Top
        {
            get { return top; }
            set { top = value; }
        }

        public string Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        public string Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        public class GUISliderDataReader : ContentTypeReader<GUISliderData>
        {
            protected override GUISliderData Read(ContentReader input,
                GUISliderData existingInstance)
            {
                GUISliderData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GUISliderData();
                }

                desc.Background = input.ReadString();
                desc.Top = input.ReadString();
                desc.Bottom = input.ReadString();
                desc.Handle = input.ReadString();

                return desc;
            }
        }
    }
}
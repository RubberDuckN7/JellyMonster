using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GUIButtonData : ContentObject
    {
        private string background;
        private string pressed;
        private string font;

        public string Background
        {
            get { return background; }
            set { background = value; }
        }

        public string Pressed
        {
            get { return pressed; }
            set { pressed = value; }
        }

        public string Font
        {
            get { return font; }
            set { font = value; }
        }

        public class GUIButtonDataReader : ContentTypeReader<GUIButtonData>
        {
            protected override GUIButtonData Read(ContentReader input,
                GUIButtonData existingInstance)
            {
                GUIButtonData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GUIButtonData();
                }

                desc.Background = input.ReadString();
                desc.Pressed = input.ReadString();
                desc.Font = input.ReadString();

                return desc;
            }
        }
    }
}
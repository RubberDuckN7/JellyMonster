using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GUICheckBoxData : ContentObject
    {
        private string background;
        private string pressed;

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

        public class GUICheckBoxDataReader : ContentTypeReader<GUICheckBoxData>
        {
            protected override GUICheckBoxData Read(ContentReader input,
                GUICheckBoxData existingInstance)
            {
                GUICheckBoxData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GUICheckBoxData();
                }

                desc.Background = input.ReadString();
                desc.Pressed = input.ReadString();

                return desc;
            }
        }
    }
}
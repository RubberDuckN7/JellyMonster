using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GUIRectangleData : ContentObject
    {
        string background;
        string font;

        public string Background
        {
            get { return background; }
            set { background = value; }
        }

        public string Font
        {
            get { return font; }
            set { font = value; }
        }

        public class GUIRectangleDataReader : ContentTypeReader<GUIRectangleData>
        {
            protected override GUIRectangleData Read(ContentReader input,
                GUIRectangleData existingInstance)
            {
                GUIRectangleData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GUIRectangleData();
                }

                desc.Background = input.ReadString();
                desc.Font = input.ReadString();

                return desc;
            }
        }
    }
}
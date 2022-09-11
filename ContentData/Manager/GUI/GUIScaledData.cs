using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GUIRScaledData : ContentObject
    {
        private string background;
        private string corner_tl;
        private string corner_tr;
        private string corner_bl;
        private string corner_br;
        private string border_horizontal;
        private string border_vertical;

        public string Background
        {
            get { return background; }
            set { background = value; }
        }

        public string CornerTL
        {
            get { return corner_tl; }
            set { corner_tl = value; }
        }

        public string CornerTR
        {
            get { return corner_tr; }
            set { corner_tr = value; }
        }

        public string CornerBL
        {
            get { return corner_bl; }
            set { corner_bl = value; }
        }

        public string CornerBR
        {
            get { return corner_br; }
            set { corner_br = value; }
        }

        public string BorderHorizontal
        {
            get { return border_horizontal; }
            set { border_horizontal = value; }
        }

        public string BorderVertical
        {
            get { return border_vertical; }
            set { border_vertical = value; }
        }

        public class GUIRScaledDataReader : ContentTypeReader<GUIRScaledData>
        {
            protected override GUIRScaledData Read(ContentReader input,
                GUIRScaledData existingInstance)
            {
                GUIRScaledData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GUIRScaledData();
                }

                desc.Background = input.ReadString();
                desc.CornerTL = input.ReadString();
                desc.CornerTR = input.ReadString();
                desc.CornerBL = input.ReadString();
                desc.CornerBR = input.ReadString();
                desc.BorderHorizontal = input.ReadString();
                desc.BorderVertical = input.ReadString();

                return desc;
            }
        }
    }
}

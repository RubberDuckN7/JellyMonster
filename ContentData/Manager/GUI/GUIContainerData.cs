using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GUIContainerData : ContentObject
    {
        private GUIRScaledData background;
        private string empty_tile;
        private string selected_tile;

        public GUIRScaledData Background
        {
            get { return background; }
            set { background = value; }
        }

        public string EmptyTile
        {
            get { return empty_tile; }
            set { empty_tile = value; }
        }

        public string SelectedTile
        {
            get { return selected_tile; }
            set { selected_tile = value; }
        }

        public class GUIContainerDataReader : ContentTypeReader<GUIContainerData>
        {
            protected override GUIContainerData Read(ContentReader input,
                GUIContainerData existingInstance)
            {
                GUIContainerData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GUIContainerData();
                }

                desc.Background = input.ReadObject<GUIRScaledData>();
                desc.EmptyTile = input.ReadString();
                desc.SelectedTile = input.ReadString();

                return desc;
            }
        }
    }
}
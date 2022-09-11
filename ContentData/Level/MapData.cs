using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class MapData : ContentObject
    {
        private List<string> levels = new List<string>();

        public List<string> Levels
        {
            get { return levels; }
            set { levels = value; }
        }

        public class MapDataReader : ContentTypeReader<MapData>
        {
            protected override MapData Read(ContentReader input,
                MapData existingInstance)
            {
                MapData desc = existingInstance;
                if (desc == null)
                {
                    desc = new MapData();
                }

                desc.Levels.AddRange(input.ReadObject<List<string>>());

                return desc;
            }
        }
    }
}

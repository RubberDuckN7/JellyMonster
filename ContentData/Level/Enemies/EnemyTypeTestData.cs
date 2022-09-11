using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class EnemyTypeTestData : ContentObject
    {
        private List<string> path = new List<string>();
        private Vector2 extents;
        private float speed;

        public List<string> Path
        {
            get { return path; }
            set { path = value; }
        }

        public Vector2 Extents
        {
            get { return extents; }
            set { extents = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public class EnemyTypeTestDataReader : ContentTypeReader<EnemyTypeTestData>
        {
            protected override EnemyTypeTestData Read(ContentReader input,
                EnemyTypeTestData existingInstance)
            {
                EnemyTypeTestData desc = existingInstance;
                if (desc == null)
                {
                    desc = new EnemyTypeTestData();
                }

                // List<string> path

                desc.Path.AddRange(input.ReadObject<List<string>>());
                desc.Extents = input.ReadObject<Vector2>();
                desc.Speed = input.ReadSingle();

                return desc;
            }
        }
    }
}

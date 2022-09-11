using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class TypeData : ContentObject
    {
		private string path;
		private string name;

		public string Path
		{
			get { return path; }
			set { path = value; }
		}
		
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		

		public class TypeDataReader : ContentTypeReader<TypeData>
        {
            protected override TypeData Read(ContentReader input,
                TypeData existingInstance)
            {
                TypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new TypeData();
                }

				// string path
				// string name

                desc.Path = input.ReadString();
                desc.Name = input.ReadString();

                return desc;
            }
		}
	}
}

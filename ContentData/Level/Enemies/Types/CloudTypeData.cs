using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class CloudTypeData : ContentObject
    {
		private List<string> cloud_attacking = new List<string>();
		private List<string> cloud_waiting = new List<string>();
		private string thunder_one;
		private string thunder_two;
		private Vector2 extents;
		private float speed;
		private float thunder_length;
		private float wait_length;

		public List<string> Cloud_Attacking
		{
			get { return cloud_attacking; }
			set { cloud_attacking = value; }
		}
		
		public List<string> Cloud_Waiting
		{
			get { return cloud_waiting; }
			set { cloud_waiting = value; }
		}
		
		public string Thunder_One
		{
			get { return thunder_one; }
			set { thunder_one = value; }
		}
		
		public string Thunder_Two
		{
			get { return thunder_two; }
			set { thunder_two = value; }
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
		
		public float Thunder_Length
		{
			get { return thunder_length; }
			set { thunder_length = value; }
		}
		
		public float Wait_Length
		{
			get { return wait_length; }
			set { wait_length = value; }
		}
		

		public class CloudTypeDataReader : ContentTypeReader<CloudTypeData>
        {
            protected override CloudTypeData Read(ContentReader input,
                CloudTypeData existingInstance)
            {
                CloudTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new CloudTypeData();
                }

				// List<string> cloud_attacking
				// List<string> cloud_waiting
				// string thunder_one
				// string thunder_two
				// Vector2 extents
				// float speed
				// float thunder_length
				// float wait_length

                desc.Cloud_Attacking.AddRange(input.ReadObject<List<string>>());
                desc.Cloud_Waiting.AddRange(input.ReadObject<List<string>>());
                desc.Thunder_One = input.ReadString();
                desc.Thunder_Two = input.ReadString();
                desc.Extents = input.ReadObject<Vector2>();
                desc.Speed = input.ReadSingle();
                desc.Thunder_Length = input.ReadSingle();
                desc.Wait_Length = input.ReadSingle();

                return desc;
            }
		}
	}
}

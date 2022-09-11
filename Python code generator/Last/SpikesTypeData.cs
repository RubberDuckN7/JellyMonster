using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class SpikesTypeData : ContentObject
    {
		private List<string> spikes_attacking = new List<string>();
		private List<string> spikes_removing = new List<string>();
		private string spikes_waiting;
		private Vector2 extents;

		public List<string> Spikes_Attacking
		{
			get { return spikes_attacking; }
			set { spikes_attacking = value; }
		}
		
		public List<string> Spikes_Removing
		{
			get { return spikes_removing; }
			set { spikes_removing = value; }
		}
		
		public string Spikes_Waiting
		{
			get { return spikes_waiting; }
			set { spikes_waiting = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		

		public class SpikesTypeDataReader : ContentTypeReader<SpikesTypeData>
        {
            protected override SpikesTypeData Read(ContentReader input,
                SpikesTypeData existingInstance)
            {
                SpikesTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new SpikesTypeData();
                }

				// List<string> spikes_attacking
				// List<string> spikes_removing
				// string spikes_waiting
				// Vector2 extents

                return desc;
            }
		}
	}
}

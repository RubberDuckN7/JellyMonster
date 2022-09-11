using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class WizardTypeData : ContentObject
    {
		private List<string> wizard_attacking = new List<string>();
		private List<string> wizard_waiting = new List<string>();
		private string magic_missile;
		private Vector2 extents;
		private float magic_speed;
		private float fire_rate;

		public List<string> Wizard_Attacking
		{
			get { return wizard_attacking; }
			set { wizard_attacking = value; }
		}
		
		public List<string> Wizard_Waiting
		{
			get { return wizard_waiting; }
			set { wizard_waiting = value; }
		}
		
		public string Magic_Missile
		{
			get { return magic_missile; }
			set { magic_missile = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public float Magic_Speed
		{
			get { return magic_speed; }
			set { magic_speed = value; }
		}
		
		public float Fire_Rate
		{
			get { return fire_rate; }
			set { fire_rate = value; }
		}
		

		public class WizardTypeDataReader : ContentTypeReader<WizardTypeData>
        {
            protected override WizardTypeData Read(ContentReader input,
                WizardTypeData existingInstance)
            {
                WizardTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new WizardTypeData();
                }

				// List<string> wizard_attacking
				// List<string> wizard_waiting
				// string magic_missile
				// Vector2 extents
				// float magic_speed
				// float fire_rate

                return desc;
            }
		}
	}
}

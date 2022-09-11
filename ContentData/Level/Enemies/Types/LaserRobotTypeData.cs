using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class LaserRobotTypeData : ContentObject
    {
		private List<string> laser_robot_waiting = new List<string>();
		private List<string> laser_robot_attacking = new List<string>();
		private string laser_shot;
		private Vector2 extents;
		private float bullet_speed;
		private float fire_rate;

		public List<string> Laser_Robot_Waiting
		{
			get { return laser_robot_waiting; }
			set { laser_robot_waiting = value; }
		}
		
		public List<string> Laser_Robot_Attacking
		{
			get { return laser_robot_attacking; }
			set { laser_robot_attacking = value; }
		}
		
		public string Laser_Shot
		{
			get { return laser_shot; }
			set { laser_shot = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public float Bullet_Speed
		{
			get { return bullet_speed; }
			set { bullet_speed = value; }
		}
		
		public float Fire_Rate
		{
			get { return fire_rate; }
			set { fire_rate = value; }
		}
		

		public class LaserRobotTypeDataReader : ContentTypeReader<LaserRobotTypeData>
        {
            protected override LaserRobotTypeData Read(ContentReader input,
                LaserRobotTypeData existingInstance)
            {
                LaserRobotTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new LaserRobotTypeData();
                }

				// List<string> laser_robot_waiting
				// List<string> laser_robot_attacking
				// string laser_shot
				// Vector2 extents
				// float bullet_speed
				// float fire_rate

                desc.Laser_Robot_Waiting.AddRange(input.ReadObject<List<string>>());
                desc.Laser_Robot_Attacking.AddRange(input.ReadObject<List<string>>());
                desc.Laser_Shot = input.ReadString();
                desc.Extents = input.ReadObject<Vector2>();
                desc.Bullet_Speed = input.ReadSingle();
                desc.Fire_Rate = input.ReadSingle();

                return desc;
            }
		}
	}
}

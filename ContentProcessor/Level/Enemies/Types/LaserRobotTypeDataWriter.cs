using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using ContentData;

namespace ContentProcessor
{
    [ContentTypeWriter]
    public class LaserRobotTypeDataWriter : ContentDataWriter<LaserRobotTypeData>
    {
        protected override void Write(ContentWriter output, LaserRobotTypeData value)
        {
			// List<string> laser_robot_waiting
			// List<string> laser_robot_attacking
			// string laser_shot
			// Vector2 extents
			// float bullet_speed
			// float fire_rate

            output.WriteObject<List<string>>(value.Laser_Robot_Waiting);
            output.WriteObject<List<string>>(value.Laser_Robot_Attacking);
            output.Write(value.Laser_Shot);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Bullet_Speed);
            output.Write(value.Fire_Rate);
        }
    }
}

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

        }
    }
}

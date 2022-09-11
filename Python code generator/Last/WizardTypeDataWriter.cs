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
    public class WizardTypeDataWriter : ContentDataWriter<WizardTypeData>
    {
        protected override void Write(ContentWriter output, WizardTypeData value)
        {
			// List<string> wizard_attacking
			// List<string> wizard_waiting
			// string magic_missile
			// Vector2 extents
			// float magic_speed
			// float fire_rate

        }
    }
}

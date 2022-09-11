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
    public class GUIManagerDataWriter : ContentDataWriter<GUIManagerData>
    {
        protected override void Write(ContentWriter output, GUIManagerData value)
        {
            output.WriteObject<GUIRectangleData>(value.DataRectangle);
            output.WriteObject<GUIRScaledData>(value.DataRScaled);
            output.WriteObject<GUIButtonData>(value.DataButton);
            output.WriteObject<GUICheckBoxData>(value.DataCheckBox);
            output.WriteObject<GUISliderData>(value.DataSlider);
            output.WriteObject<GUIContainerData>(value.DataContainer);
        }
    }
}

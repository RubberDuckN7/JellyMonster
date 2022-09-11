using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

////////////////////////////////////////////////////////////////////////////////////////////
// 1: scaled rectangle for scaled buttons or frames.
// 2: simple rectangle for small use of buttons or buttons inside UI element.
// 3: simple box for all around use, check box.
////////////////////////////////////////////////////////////////////////////////////////////

namespace ContentData
{
    public class GUIManagerData : ContentObject
    {
        private GUIRectangleData data_rectangle;
        private GUIRScaledData data_rscaled;
        private GUIButtonData data_button;
        private GUICheckBoxData data_cbox;
        private GUISliderData data_slider;
        private GUIContainerData data_container;

        public GUIRectangleData DataRectangle
        {
            get { return data_rectangle; }
            set { data_rectangle = value; }
        }

        public GUIRScaledData DataRScaled
        {
            get { return data_rscaled; }
            set { data_rscaled = value; }
        }

        public GUIButtonData DataButton
        {
            get { return data_button; }
            set { data_button = value; }
        }

        public GUICheckBoxData DataCheckBox
        {
            get { return data_cbox; }
            set { data_cbox = value; }
        }

        public GUISliderData DataSlider
        {
            get { return data_slider; }
            set { data_slider = value; }
        }

        public GUIContainerData DataContainer
        {
            get { return data_container; }
            set { data_container = value; }
        }

        public class GUIManagerDataReader : ContentTypeReader<GUIManagerData>
        {
            protected override GUIManagerData Read(ContentReader input,
                GUIManagerData existingInstance)
            {
                GUIManagerData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GUIManagerData();
                }

                desc.DataRectangle = input.ReadObject<GUIRectangleData>();
                desc.DataRScaled = input.ReadObject<GUIRScaledData>();
                desc.DataButton = input.ReadObject<GUIButtonData>();
                desc.DataCheckBox = input.ReadObject<GUICheckBoxData>();
                desc.DataSlider = input.ReadObject<GUISliderData>();
                desc.DataContainer = input.ReadObject<GUIContainerData>();

                return desc;
            }
        }
    }
}
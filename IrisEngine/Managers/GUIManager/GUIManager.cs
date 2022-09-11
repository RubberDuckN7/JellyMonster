/////////////////////////////////////////////////////////////////////////////////////
// Base includes.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/////////////////////////////////////////////////////////////////////////////////////
// Resource includes.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

/////////////////////////////////////////////////////////////////////////////////////
// A manager for handling different UI elements.
// Should be global, for everyone.
// 
// * Resources for GUI elements are global, and only are loaded once in beginning of
//   system startup.
// * Additional GUI elements can be used as standalone for creating different
//   resource use.
// * Use base classes for GUI elements if changed GUI behaviour is desirable. :3  
// * Custom buttons are supported.
// 
// * May change how different regions are handled, wont be noticable for outer use.
// * Control from xml files which element resources will be loaded, in any case,
//   custom resources for a specific element can be loaded separately at specific
//   point, in scene.
//
/////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////
// This GUI supports right now: 
//
// MessageBox:     Done
// MessageCounter: Done
// Button:         Done
// Container:      Done
// Checkbox:       Done
// Slider:         Done
//
/////////////////////////////////////////////////////////////////////////////////////

namespace IrisEngine
{
    public class GUIManager
    {
        ContentManager content;

        RectangleResources resources_rectangle;
        RScaledResources resources_rscaled;
        ButtonResources resources_button;
        CheckBoxResources resources_cbox;
        SliderResources resources_slider;
        ContainerResources resources_container;

        public GUIManager()
        {
            content = null;
        }

        public bool Load(Game game, string xml_name, string additional_folder)
        {
            string folder = "Content" + additional_folder;

            if (content == null)
                content = new ContentManager(game.Services, folder);

            ContentData.GUIManagerData gm_data = content.Load<ContentData.GUIManagerData>(xml_name);

            // Default for simple rectangles and counters etc.
            resources_rectangle = new RectangleResources();

            resources_rectangle.background = content.Load<Texture2D>(gm_data.DataRectangle.Background);
            resources_rectangle.font = content.Load<SpriteFont>(gm_data.DataRectangle.Font);

            // Default for scaled boxes.
            resources_rscaled = new RScaledResources();

            resources_rscaled.background = content.Load<Texture2D>(gm_data.DataRScaled.Background);
            resources_rscaled.corner_tl = content.Load<Texture2D>(gm_data.DataRScaled.CornerTL);
            resources_rscaled.corner_tr = content.Load<Texture2D>(gm_data.DataRScaled.CornerTR);
            resources_rscaled.corner_bl = content.Load<Texture2D>(gm_data.DataRScaled.CornerBL);
            resources_rscaled.corner_br = content.Load<Texture2D>(gm_data.DataRScaled.CornerBR);
            resources_rscaled.border_horizontal = content.Load<Texture2D>(gm_data.DataRScaled.BorderHorizontal);
            resources_rscaled.border_vertical = content.Load<Texture2D>(gm_data.DataRScaled.BorderVertical);

            // Default for buttons
            resources_button = new ButtonResources();

            resources_button.background = content.Load<Texture2D>(gm_data.DataButton.Background);
            resources_button.pressed = content.Load<Texture2D>(gm_data.DataButton.Pressed);
            resources_button.font = content.Load<SpriteFont>(gm_data.DataButton.Font);

            // Default for check box
            resources_cbox = new CheckBoxResources();

            resources_cbox.background = content.Load<Texture2D>(gm_data.DataCheckBox.Background);
            resources_cbox.pressed = content.Load<Texture2D>(gm_data.DataCheckBox.Pressed);

            // Default for slider
            resources_slider = new SliderResources();

            resources_slider.background = content.Load<Texture2D>(gm_data.DataSlider.Background);
            resources_slider.top = content.Load<Texture2D>(gm_data.DataSlider.Top);
            resources_slider.bottom = content.Load<Texture2D>(gm_data.DataSlider.Bottom);
            resources_slider.handle = content.Load<Texture2D>(gm_data.DataSlider.Handle);

            // Default for container
            resources_container = new ContainerResources();

            resources_container.background = new RScaledResources();

            resources_container.background.background = content.Load<Texture2D>(gm_data.DataContainer.Background.Background);
            resources_container.background.corner_tl = content.Load<Texture2D>(gm_data.DataContainer.Background.CornerTL);
            resources_container.background.corner_tr = content.Load<Texture2D>(gm_data.DataContainer.Background.CornerTR);
            resources_container.background.corner_bl = content.Load<Texture2D>(gm_data.DataContainer.Background.CornerBL);
            resources_container.background.corner_br = content.Load<Texture2D>(gm_data.DataContainer.Background.CornerBR);
            resources_container.background.border_horizontal = content.Load<Texture2D>(gm_data.DataContainer.Background.BorderHorizontal);
            resources_container.background.border_vertical = content.Load<Texture2D>(gm_data.DataContainer.Background.BorderVertical);

            resources_container.empty_tile = content.Load<Texture2D>(gm_data.DataContainer.EmptyTile);
            resources_container.selected_tile = content.Load<Texture2D>(gm_data.DataContainer.SelectedTile);

            return true;
        }

        public void Unload()
        {

        }

        // Add to main list to.
        public GUIPage AddPage()
        {
            return new GUIPage(this);
        }

        public void Update(TouchCollection touches, float dt)
        {
            //for (byte i = 0; i < elements_top.Count; i++)
            //{
            //    elements_top[i].HandleInput(touches, dt);
            //}

            //for (byte i = 0; i < elements_bottom.Count; i++)
            //{
            //    elements_bottom[i].HandleInput(touches, dt);
            //}

            //for (byte i = 0; i < elements_left.Count; i++)
            //{
            //    elements_left[i].HandleInput(touches, dt);
            //}

            //for (byte i = 0; i < elements_right.Count; i++)
            //{
            //    elements_right[i].HandleInput(touches, dt);
            //}
        }

        public void Draw(SpriteBatch sp)
        {
            //for (byte i = 0; i < elements_top.Count; i++)
            //{
            //    elements_top[i].Draw(sp);
            //}

            //for (byte i = 0; i < elements_bottom.Count; i++)
            //{
            //    elements_bottom[i].Draw(sp);
            //}

            //for (byte i = 0; i < elements_left.Count; i++)
            //{
            //    elements_left[i].Draw(sp);
            //}

            //for (byte i = 0; i < elements_right.Count; i++)
            //{
            //    elements_right[i].Draw(sp);
            //}
        }

        //public void AddElement(IElement e, EORIENTATION orientation)
        //{
        //switch (orientation)
        //{
        //    case EORIENTATION.Top:
        //        elements_top.Add(e);
        //        break;
        //    case EORIENTATION.Bottom:
        //        elements_bottom.Add(e);
        //        break;
        //    case EORIENTATION.Left:
        //        elements_left.Add(e);
        //        break;
        //    case EORIENTATION.Right:
        //        elements_right.Add(e);
        //        break;
        //    default:
        //        elements_top.Add(e);
        //        break;
        //}
        //}

        private void TransitAway(TouchCollection touches, float dt)
        {
            //for (byte i = 0; i < elements_top.Count; i++)
            //{

            //}

            //for (byte i = 0; i < elements_bottom.Count; i++)
            //{

            //}

            //for (byte i = 0; i < elements_left.Count; i++)
            //{

            //}

            //for (byte i = 0; i < elements_right.Count; i++)
            //{

            //}
        }

        public RectangleResources ResourceRectangle
        {
            get { return resources_rectangle; }
        }

        public RScaledResources ResourcesRScaled
        {
            get { return resources_rscaled; }
        }

        public ButtonResources ResourcesButton
        {
            get { return resources_button; }
        }

        public CheckBoxResources ResourcesCheckBox
        {
            get { return resources_cbox; }
        }

        public SliderResources ResourcesSlider
        {
            get { return resources_slider; }
        }

        public ContainerResources ResourcesContainer
        {
            get { return resources_container; }
        }


    }
}

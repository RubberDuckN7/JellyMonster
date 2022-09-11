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

namespace IrisEngine
{
    public class GUIPage
    {
        List<IElement> elements_top;
        List<IElement> elements_bottom;
        List<IElement> elements_right;
        List<IElement> elements_left;

        GUIManager manager_gui;

        public GUIPage(GUIManager manager_gui)
        {
            this.manager_gui = manager_gui;

            elements_top = new List<IElement>();
            elements_bottom = new List<IElement>();
            elements_right = new List<IElement>();
            elements_left = new List<IElement>();
        }

        public void Draw(SpriteBatch sp, float time_alpha)
        {
            //sp.Begin();
            sp.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);


            time_alpha = 1.0f - time_alpha;

            Vector2 offset = new Vector2();

            for (byte i = 0; i < elements_top.Count; i++)
            {
                offset.X = 0.0f;
                offset.Y = -480.0f * time_alpha;
                offset.Y = MathHelper.Clamp(offset.Y, -480f, 0f);

                elements_top[i].Draw(sp, Color.White, offset);
            }

            for (byte i = 0; i < elements_bottom.Count; i++)
            {
                offset.X = 0.0f;
                offset.Y = 480.0f * time_alpha;
                offset.Y = MathHelper.Clamp(offset.Y, 0f, 480f);

                elements_bottom[i].Draw(sp, Color.White, offset);
            }

            for (byte i = 0; i < elements_left.Count; i++)
            {
                offset.X = -800.0f * time_alpha;
                offset.Y = 0f;
                offset.X = MathHelper.Clamp(offset.X, -800f, 0f);

                elements_left[i].Draw(sp, Color.White, offset);
            }

            for (byte i = 0; i < elements_right.Count; i++)
            {
                offset.X = 800.0f * time_alpha;
                offset.Y = 0f;
                offset.X = MathHelper.Clamp(offset.X, 0f, 800f);

                elements_right[i].Draw(sp, Color.White, offset);
            }

            sp.End();
        }

        public void HandleInput(TouchCollection touches, float dt)
        {
            for (byte i = 0; i < elements_top.Count; i++)
            {
                elements_top[i].HandleInput(touches, dt);
            }

            for (byte i = 0; i < elements_bottom.Count; i++)
            {
                elements_bottom[i].HandleInput(touches, dt);
            }

            for (byte i = 0; i < elements_left.Count; i++)
            {
                elements_left[i].HandleInput(touches, dt);
            }

            for (byte i = 0; i < elements_right.Count; i++)
            {
                elements_right[i].HandleInput(touches, dt);
            }
        }

        public void AddElement(IElement e, EORIENTATION orientation)
        {
            switch (orientation)
            {
                case EORIENTATION.Top:
                    elements_top.Add(e);
                    break;
                case EORIENTATION.Bottom:
                    elements_bottom.Add(e);
                    break;
                case EORIENTATION.Left:
                    elements_left.Add(e);
                    break;
                case EORIENTATION.Right:
                    elements_right.Add(e);
                    break;
                default:
                    elements_top.Add(e);
                    break;
            }
        }

        #region ADD MSG COUNTER

        public MsgCounter AddMsgCounter(SpriteFont font, Rectangle bounds, EORIENTATION orientation, string message)
        {
            MsgCounter msg = new MsgCounter(manager_gui.ResourceRectangle.background, font, bounds, message);

            AddElement(msg, orientation);

            return msg;
        }

        public MsgCounter AddMsgCounter(Rectangle bounds, EORIENTATION orientation, string message)
        {
            MsgCounter msg = new MsgCounter(manager_gui.ResourceRectangle.background, manager_gui.ResourceRectangle.font, bounds, message);

            AddElement(msg, orientation);

            return msg;
        }

        #endregion

        #region ADD MESSAGE BOX

        public MsgBox AddMsgBox(SpriteFont font, Rectangle bounds, EORIENTATION orientation, string message)
        {
            MsgBox box = new MsgBox(manager_gui.ResourcesRScaled, font, bounds, 50.0f, 50.0f, 16.0f, 16.0f, message);
            AddElement(box, orientation);
            return box;
        }

        public MsgBox AddMsgBox(SpriteFont font, float x, float y, EORIENTATION orientation, string message)
        {
            MsgBox box = new MsgBox(manager_gui.ResourcesRScaled, font, x, y, 50.0f, 50.0f, 16.0f, 16.0f, message);
            AddElement(box, orientation);
            return box;
        }

        public MsgBox AddMsgBox(RScaledResources resources, SpriteFont font, Rectangle bounds, EORIENTATION orientation, string message)
        {
            MsgBox box = new MsgBox(resources, font, bounds, 50.0f, 50.0f, 16.0f, 16.0f, message);
            AddElement(box, orientation);
            return box;
        }

        public MsgBox AddMsgBox(RScaledResources resources, SpriteFont font, float x, float y, EORIENTATION orientation, string message)
        {
            MsgBox box = new MsgBox(resources, font, x, y, 50.0f, 50.0f, 16.0f, 16.0f, message);
            AddElement(box, orientation);
            return box;
        }

        #endregion

        #region ADD BUTTON

        public Button AddButton(Rectangle bounds, EORIENTATION orientation, byte id)
        {
            Button button = new Button(manager_gui.ResourcesButton, bounds, id);

            AddElement(button, orientation);

            return button;
        }

        public Button AddButton(ButtonResources resources, Rectangle bounds, EORIENTATION orientation, byte id)
        {
            Button button = new Button(resources, bounds, id);

            AddElement(button, orientation);

            return button;
        }

        public ButtonNamed AddButton(Rectangle bounds, EORIENTATION orientation, string name, byte id)
        {
            ButtonNamed button = new ButtonNamed(manager_gui.ResourcesButton, bounds, name, id);

            AddElement(button, orientation);

            return button;
        }

        public ButtonNamed AddButton(ButtonResources resources, Rectangle bounds, EORIENTATION orientation, string name, byte id)
        {
            ButtonNamed button = new ButtonNamed(resources, bounds, name, id);

            AddElement(button, orientation);

            return button;
        }

        #endregion

        #region CHECK BOX

        public CheckBox AddCheckBox(Rectangle bounds, EORIENTATION orientation, byte id)
        {
            CheckBox box = new CheckBox(manager_gui.ResourcesCheckBox, bounds, id);

            AddElement(box, orientation);

            return box;
        }

        public CheckBox AddCheckBox(CheckBoxResources resources, Rectangle bounds, EORIENTATION orientation, byte id)
        {
            CheckBox box = new CheckBox(resources, bounds, id);

            AddElement(box, orientation);

            return box;
        }

        #endregion

        #region ADD SLIDER

        public Slider AddSlider(Rectangle bounds, EORIENTATION orientation)
        {
            Slider slider = new Slider(manager_gui.ResourcesSlider, bounds);

            AddElement(slider, orientation);

            return slider;
        }

        public Slider AddSlider(Rectangle bounds, EORIENTATION orientation, int handle_w, int handle_h, int end_w, int end_h)
        {
            Slider slider = new Slider(manager_gui.ResourcesSlider, bounds, handle_w, handle_h, end_w, end_h);

            AddElement(slider, orientation);

            return slider;
        }

        #endregion

        #region ADD CONTAINER

        public Container AddContainer(EORIENTATION orientation, int count_w, int count_h, int x, int y)
        {
            Container container = new Container(manager_gui.ResourcesContainer, x, y, count_w, count_h, 50.0f, 50.0f, 16.0f, 16.0f, 30.0f, 5.0f);

            AddElement(container, orientation);

            return container;
        }

        public Container AddContainer(EORIENTATION orientation, int x, int y, int count_w, int count_h, float corner_w, float corner_h, float border_w, float border_h, float tile_size, float tile_spacing)
        {
            Container container = new Container(manager_gui.ResourcesContainer, x, y, count_w, count_h, corner_w, corner_h, border_w, border_h, tile_size, tile_spacing);

            AddElement(container, orientation);

            return container;
        }

        public Container AddContainer(ContainerResources resources, EORIENTATION orientation, int count_w, int count_h, int x, int y)
        {
            Container container = new Container(resources, x, y, count_w, count_h, 50.0f, 50.0f, 16.0f, 16.0f, 30.0f, 5.0f);

            AddElement(container, orientation);

            return container;
        }

        #endregion

    }
}

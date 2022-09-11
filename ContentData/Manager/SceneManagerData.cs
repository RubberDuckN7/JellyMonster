using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class SceneManagerData : ContentObject
    {
        private string xml_name_gui;
        private string loading_texture;
        private string system_font;

        public string XmlNameGUI
        {
            get { return xml_name_gui; }
            set { xml_name_gui = value; }
        }

        public string LoadingTexture
        {
            get { return loading_texture; }
            set { loading_texture = value; }
        }

        public string SystemFont
        {
            get { return system_font; }
            set { system_font = value; }
        }

        public class SceneManagerDataReader : ContentTypeReader<SceneManagerData>
        {
            protected override SceneManagerData Read(ContentReader input,
                SceneManagerData existingInstance)
            {
                SceneManagerData desc = existingInstance;
                if (desc == null)
                {
                    desc = new SceneManagerData();
                }

                desc.XmlNameGUI = input.ReadString();
                desc.LoadingTexture = input.ReadString();
                desc.SystemFont = input.ReadString();

                return desc;
            }
        }
    }
}
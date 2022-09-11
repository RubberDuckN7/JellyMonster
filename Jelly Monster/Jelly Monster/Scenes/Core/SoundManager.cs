using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Jelly_Monster
{
    static class SoundManager
    {
        static float volume;
        static bool sound_off;
        static bool music_off;

        //static Song theme;
        static SoundEffectInstance inst_button;
        static SoundEffectInstance inst_jump;
        static SoundEffectInstance inst_pickup;
        static SoundEffectInstance inst_score;
        static SoundEffectInstance inst_theme;

        public static float Volume
        {
            get { return volume; }
            set 
            { 
                volume = value;
                if (inst_button != null)
                {
                    //MediaPlayer.Volume = volume;
                    inst_button.Volume = volume;
                    inst_jump.Volume = volume;
                    inst_pickup.Volume = volume;
                    inst_score.Volume = volume;
                }
            }
        }

        public static bool SoundOff
        {
            get { return sound_off; }
            set { sound_off = value; }
        }

        public static bool MusicOff
        {
            get { return music_off; }
            set { music_off = value; }
        }

        public static void StartMusic()
        {
            if (music_off)
                return;

            inst_theme.Play();

            /*if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(theme);
            }*/
        }

        public static void StopMusic()
        {
            inst_theme.Stop();

            /*if (MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Stop();
            }*/
        }

        public static void PlayJump()
        {
            if (sound_off)
                return;

            //inst_jump.Play();      
        }

        public static void PlayOnDeath()
        {
            if (sound_off)
                return;

            inst_jump.Play();
        }

        public static void PlayOnCollect()
        {
            if (sound_off)
                return;

            inst_pickup.Play();
        }

        public static void PlayOnClick()
        {
            if (sound_off)
                return;

            inst_button.Play();
        }

        public static void PlayOnScore()
        {
            if (sound_off)
                return;

            inst_score.Play();
        }

        public static void LoadContent(ContentManager content)
        {
            //theme = content.Load<Song>("Sounds/theme");
            SoundEffect button = content.Load<SoundEffect>("Sounds/button_press");
            SoundEffect jump = content.Load<SoundEffect>("Sounds/jump");
            SoundEffect pickup = content.Load<SoundEffect>("Sounds/pickup");
            SoundEffect score = content.Load<SoundEffect>("Sounds/score_scene");
            SoundEffect theme_looped = content.Load<SoundEffect>("Sounds/loop_theme");

            inst_button = button.CreateInstance();
            inst_jump = jump.CreateInstance();
            inst_pickup = pickup.CreateInstance();
            inst_score = score.CreateInstance();
            inst_theme = theme_looped.CreateInstance();

            inst_button.IsLooped = false;
            inst_jump.IsLooped = false;
            inst_pickup.IsLooped = false;
            inst_score.IsLooped = false;
            inst_theme.IsLooped = true;

            inst_button.Volume = volume;
            inst_jump.Volume = volume;
            inst_pickup.Volume = volume;
            inst_score.Volume = volume;
            inst_theme.Volume = volume;
        }

        public static void StopAll()
        {
            if (inst_theme != null)
                inst_theme.Stop();
            //if (MediaPlayer.State != MediaState.Stopped)
            //{
            //    MediaPlayer.Stop();
            //}
        }
    }
}

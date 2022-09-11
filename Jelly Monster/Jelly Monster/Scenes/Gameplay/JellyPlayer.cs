using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using IrisEngine;

namespace Jelly_Monster
{
    public class JellyPlayer
    {
        #region ATTRIBUTES

        Level level;
        Animation animation_moving;
        Texture2D texture_default;

        Rectangle bounds;
        Vector2 velocity;
        Vector2 offset;
        Vector2 prev_pos;
        
        const float gravity = 700f;

        float time;
        float spawn_time;

        byte current_index;

        bool falling;
        bool moving;
        bool jumped;
        bool face_front;
        bool respawning;

        #endregion

        #region INITIALIZATION

        public JellyPlayer()
        {
            animation_moving = new Animation(5);

            bounds = new Rectangle(0, 100, 60, 60);
            velocity = new Vector2(0f, 0f);
            offset = Vector2.Zero;
            prev_pos = Vector2.Zero;

            time = 0f;
            spawn_time = 0f;
            current_index = 0;

            falling = true;
            moving = false;
            jumped = false;
            face_front = true;
            respawning = false;
        }

        public JellyPlayer(Level level, int x, int y, int w, int h)
        {
            this.level = level;
            animation_moving = new Animation(5);

            bounds = new Rectangle(x, y, w, h);
            velocity = Vector2.Zero;
            offset = Vector2.Zero;

            time = 0f;
            current_index = 0;

            falling = true;
            moving = false;
        }

        public void Load(ContentManager content)
        {
            for (byte i = 0; i < animation_moving.Count; i++)
            {
                animation_moving[i] = content.Load<Texture2D>("Textures/Jelly/Move/jelly_moving_" + (int)(i + 1));
            }

            texture_default = content.Load<Texture2D>("Textures/Jelly/Stand/jelly_standing");
        }

        #endregion

        public void Draw(SpriteBatch sp, Vector2 offset)
        {
            if (respawning)
                return;

            int x = bounds.X;
            int y = bounds.Y;

            bounds.X -= (int)offset.X;
            bounds.Y -= (int)offset.Y - 5;

            Texture2D texture = texture_default;

            if (moving)
                texture = animation_moving[current_index];

            if(face_front)
                sp.Draw(texture, bounds, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.6f);
            else
                sp.Draw(texture, bounds, null, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.6f);

            bounds.X = x;
            bounds.Y = y;
        }

        // Works correctly
        public void Update(float dt)
        {
            if (respawning)
            {
                time += dt;

                if (time > 0.5f)
                {
                    respawning = false;
                    time = 0f;
                    Respawn();
                }
                return;
            }

            prev_pos.X = (float)bounds.X;
            prev_pos.Y = (float)bounds.Y;

            if (falling)
            {
                bounds.Y += (int)(dt * velocity.Y);
                velocity.Y += gravity * dt;
            }

            bounds.X += (int)(velocity.X * dt);

            if (moving)
            {
                time += dt;

                if (time > 0.06f)
                {
                    time = 0f;

                    if (animation_moving.Count - 1 == current_index)
                        current_index = 0;
                    else
                        current_index++;
                }
            }
        }

        #region MISC FUNCTIONS

        public void Jump()
        {
            if (!falling)
            {
                velocity.Y = -450.0f;
                falling = true;
                jumped = true;
                current_index = 0;
            }
        }

        public void Jump(float force)
        {
            bounds.Y += 2;
            velocity.Y = -force;
            falling = true;
            jumped = true;
            current_index = 0;
        }

        public void MoveLeft()
        {
            velocity.X = -200.0f;
            moving = true;
            face_front = false;
        }

        public void MoveRight()
        {
            velocity.X = 200.0f;
            moving = true;
            face_front = true;
        }

        public void StopMoving()
        {
            moving = false;
            current_index = 0;
            velocity.X = 0f;
        }

        public void Landed()
        {
            velocity.Y = 0f;
            falling = false;
        }

        public void Landed(int height)
        {
            velocity.Y = 0f;
            falling = false;
            bounds.Y = height - bounds.Height;
        }

        public void Respawn()
        {
            bounds.X = 370;
            bounds.Y = 210;

            offset.X = 0f;
            offset.Y = 0f;

            respawning = false;
            spawn_time = 0f;

            velocity.X = 0f;
            velocity.Y = 0f;

            level.OffsetWorld = Vector2.Zero;
            time = 0f;
        }

        public void Kill()
        {
            respawning = true;
            time = 0f;
        }

#endregion

        #region GET FUNCTIONS

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 PrevPos
        {
            get { return prev_pos; }
            set { prev_pos = value; }
        }

        public int X
        {
            get { return bounds.X; }
            set { bounds.X = value; }
        }

        public int Y
        {
            get { return bounds.Y; }
            set { bounds.Y = value; }
        }

        public int Width
        {
            get { return bounds.Width; }
            set { bounds.Width = value; }
        }

        public int Height
        {
            get { return bounds.Height; }
            set { bounds.Height = value; }
        }

        public bool Falling
        {
            get { return falling; }
            set { falling = value; }
        }

        public bool Jumped
        {
            get { return jumped; }
            set { jumped = value; }
        }
        public bool Respawning
        {
            get { return respawning; }
        }

        #endregion
    }
}

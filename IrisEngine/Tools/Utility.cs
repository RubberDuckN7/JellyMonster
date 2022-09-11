using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IrisEngine
{
    public static class Converter
    {
        public static int BytesToInt(byte[] arg)
        {
            return System.BitConverter.ToInt32(arg, 0);
        }

        public static byte BytesToByte(byte[] b)
        {
            return b[0];
        }

        public static byte[] ByteToBytes(byte b)
        {
            return new byte[1] { b };
        }

        public static byte[] IntToBytes(int arg)
        {
            return System.BitConverter.GetBytes(arg);
        }
    }

    public struct Triangle
    {
        public Vector3 V0;
        public Vector3 V1;
        public Vector3 V2;

        public Triangle(Vector3 v0, Vector3 v1, Vector3 v2)
        {
            V0 = v0;
            V1 = v1;
            V2 = v2;
        }
    }

    public static class Intersection
    {
        const float EPSILON = 1e-20F;

        public static float? Intersects(ref Ray ray, ref Vector3 v0, ref Vector3 v1, ref Vector3 v2)
        {
            // The algorithm is based on Moller, Tomas and Trumbore, "Fast, Minimum Storage 
            // Ray-Triangle Intersection", Journal of Graphics Tools, vol. 2, no. 1, 
            // pp 21-28, 1997.

            Vector3 e1 = v1 - v0;
            Vector3 e2 = v2 - v0;

            Vector3 p = Vector3.Cross(ray.Direction, e2);

            float det = Vector3.Dot(e1, p);

            float t;
            if (det >= EPSILON)
            {
                // Determinate is positive (front side of the triangle).
                Vector3 s = ray.Position - v0;
                float u = Vector3.Dot(s, p);
                if (u < 0 || u > det)
                    return null;

                Vector3 q = Vector3.Cross(s, e1);
                float v = Vector3.Dot(ray.Direction, q);
                if (v < 0 || ((u + v) > det))
                    return null;

                t = Vector3.Dot(e2, q);
                if (t < 0)
                    return null;
            }
            else if (det <= -EPSILON)
            {
                // Determinate is negative (back side of the triangle).
                Vector3 s = ray.Position - v0;
                float u = Vector3.Dot(s, p);
                if (u > 0 || u < det)
                    return null;

                Vector3 q = Vector3.Cross(s, e1);
                float v = Vector3.Dot(ray.Direction, q);
                if (v > 0 || ((u + v) < det))
                    return null;

                t = Vector3.Dot(e2, q);
                if (t > 0)
                    return null;
            }
            else
            {
                // Parallel ray.
                return null;
            }

            return t / det;
        }
    }

    public static class Utility
    {
        private static readonly Random random = new Random();

        public static float Random(float min, float max)
        {
            return min + (float)random.NextDouble() * (max - min);
        }

        public static float Random()
        {
            return (float)random.NextDouble();
        }

        public static Vector2 GetTextPosition(SpriteFont font, Rectangle bounds, string name)
        {
            Vector2 text = Vector2.Zero;

            text = font.MeasureString(name);

            float sx = (float)(bounds.Width) - text.X;
            float sy = (float)(bounds.Height) - text.Y;

            text.X = (float)(bounds.X) + sx * 0.5f;
            text.Y = (float)(bounds.Y) + sy * 0.5f;

            return text;
        }

        public static bool PointVsBox(Vector2 p_dot, Vector2 p_box, float size)
        {
            if (p_dot.X < p_box.X)
                return false;
            if (p_dot.X > p_box.X + size)
                return false;

            if (p_dot.Y < p_box.Y)
                return false;
            if (p_dot.Y > p_box.Y + size)
                return false;

            return true;
        }

        public static bool PointVsBoxCenter(Vector2 point, Vector2 box, float size)
        {
            float half = size * 0.5f;
            if (point.X < box.X - half)
                return false;
            if (point.X > box.X + half)
                return false;

            if (point.Y < box.Y - half)
                return false;
            if (point.Y > box.Y + half)
                return false;

            return true;
        }

        public static bool PointVsRectangle(Vector2 p, Rectangle rect)
        {
            if (p.X < rect.X)
                return false;
            if (p.X > rect.X + rect.Width)
                return false;

            if (p.Y < rect.Y)
                return false;
            if (p.Y > rect.Y + rect.Height)
                return false;

            return true;
        }

        public static bool PointVsRectangle(Vector2 p_dot, Vector2 p_box, Vector2 p_bounds)
        {
            if (p_dot.X < p_box.X)
                return false;
            if (p_dot.X > p_box.X + p_bounds.X)
                return false;

            if (p_dot.Y < p_box.Y)
                return false;
            if (p_dot.Y > p_box.Y + p_bounds.Y)
                return false;


            return true;
        }

        public static bool BoxVsBox(Vector2 b_p1, float b_s1, Vector2 b_p2, float b_s2)
        {
            Vector2 b1 = new Vector2(b_p1.X, b_p1.Y);
            Vector2 b2 = new Vector2(b_p2.X, b_p2.Y);

            if (b1.X + b_s1 < b2.X)
                return false;

            if (b1.X > b2.X + b_s2)
                return false;

            if (b1.Y + b_s1 < b2.Y)
                return false;

            if (b1.Y > b2.Y + b_s2)
                return false;

            return true;
        }

        public static bool RectangleVsRectangle(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.X + rect1.Width < rect2.X)
                return false;
            if (rect1.X > rect2.X + rect2.Width)
                return false;
            if (rect1.Y + rect1.Height < rect2.Y)
                return false;
            if (rect1.Y > rect2.Y + rect2.Height)
                return false;

            return true;
        }

        public static bool InCircle(Vector2 pos, float radie, Vector2 target)
        {
            float range = (pos - target).Length();

            return (range < radie) ? true : false;
        }

        public static float Angle(Vector3 v1, Vector3 v2)
        {
            float dot = Vector3.Dot(v1, v2);
            dot = dot / (v1.Length() * v2.Length());

            double acos = Math.Acos((double)dot);

            return (float)(acos * 180.0f / Math.PI);
        }

        public static float AngleR(Vector3 v1, Vector3 v2)
        {
            float dot = Vector3.Dot(v1, v2);
            dot = dot / (v1.Length() * v2.Length());

            double acos = Math.Acos((double)dot);

            return (float)acos;
        }

        public static Rectangle ShrinkRectangle(Rectangle rect, float by_x, float by_y)
        {
            rect.X += (int)(by_x * 0.5f);
            rect.Y += (int)(by_y * 0.5f);

            rect.Width -= (int)(by_x);
            rect.Height -= (int)(by_y);

            return rect;
        }


    }
}

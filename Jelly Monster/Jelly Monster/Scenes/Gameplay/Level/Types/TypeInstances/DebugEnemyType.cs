//using System;
//using System.Collections.Generic;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Input.Touch;

//using IrisEngine;
//using ContentData;

//namespace Jelly_Monster
//{
//    public class DebugEnemyType : EnemyType
//    {
//        float speed;

//        public DebugEnemyType()
//        {
//        }

//        public override EntityInterface CreateInstance(EnemyInstanceData data)
//        {
//            EntityInterface e = null;
//            e = new EnemyDebug(data);
//            return e;
//        }

//        public override void Load(ContentManager content, string path)
//        {
//            EnemyTypeTestData data = content.Load<EnemyTypeTestData>(path);

//            animation = new Animation((byte)data.Path.Count);

//            for (byte i = 0; i < animation.Count; i++)
//            {
//                Textures[i] = content.Load<Texture2D>(data.Path[i]);
//            }

//            extents = data.Extents;
//            speed = data.Speed;
//        }

//        public override void Update(Level level, EntityInterface entity, float dt)
//        {
//            Enemy enemy = entity as Enemy;

//            Vector2 dir = enemy.Core.End - enemy.Core.Start;

//            if (!enemy.FacingFront)
//                dir = enemy.Core.Start - enemy.Core.End;
//            dir.Normalize();

//            enemy.Pos += dir * speed * dt;

//            if (enemy.FacingFront)
//            {
//                if (enemy.Pos.X + extents.X > enemy.Core.End.X)
//                    enemy.FacingFront = false;
//            }
//            else
//            {
//                if (enemy.Pos.X < enemy.Core.Start.X)
//                    enemy.FacingFront = true;
//            }

//            base.Update(level, entity, dt);
//        }

//        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
//        {
//            base.Draw(level, sp, entity);
//        }
//    }
//}

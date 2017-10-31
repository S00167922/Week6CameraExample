using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//monogame classes are in these namepspaces
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Week6Lab1
{
    public class Sprite
    {
        //variables
        public Texture2D Image;
        public Vector2 Position;
        public Rectangle Bounds;
        public Color Tint;

        //properties... later

        //constructor
        public Sprite(Texture2D image, Vector2 position, Color tint)
        {
            Image = image;
            Position = position;
            Tint = tint;
            Bounds = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }

        //caller has a SpriteBatch ready and has already called Begin
        public void Draw(SpriteBatch sp)
        {
            sp.Draw(Image, Position, Tint);
        }

        //overload. Same name, different arguments
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="sfont"></param>
        public void Draw(SpriteBatch sp, SpriteFont sfont)
        {
            Draw(sp);//call the other Draw method above
            sp.DrawString(sfont, Position.ToString(), Position, Color.White);
        }

        //move the sprite by the given amount
        public void Move(Vector2 delta)
        {
            Position += delta;
            Bounds.X = (int)Position.X;
            Bounds.Y = (int)Position.Y;
        }

        //check for collision
        public void CheckCollision(Sprite other)
        {
            if (Bounds.Intersects(other.Bounds))
            {
                Tint = Color.Black;
            }
            else
            {
                Tint = Color.White;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Jumpybird.Entities
{
    public class Pipe
    {
        public Texture2D Texture;
        public Vector2 Position;
        public bool scored = false;
        public bool debug = false;

        public Pipe()
        {
            this.Texture = Statics.CONTENT.Load<Texture2D>("Textures/pipe");
            this.Position = new Vector2(400,Statics.RANDOM.Next(-400,-100));
        }

        public void Update()
        {
            this.Position.X -= 2;
        }
        public Rectangle TopBound { get { return new Rectangle((int)this.Position.X, (int)this.Position.Y, 84, 408); } }
        public Rectangle bottomBound { get { return new Rectangle((int)this.Position.X, (int)this.Position.Y+642, 84, 492); } }

        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(this.Texture, this.Position, Color.White);
            if (debug)
            {
                //show topbound bugs
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound, new Color(1f, 0f, 0f, 0.3f));
                //show bottombound bugs
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.bottomBound, new Color(1f, 0f, 0f, 0.3f));
            }
        }
    }
}

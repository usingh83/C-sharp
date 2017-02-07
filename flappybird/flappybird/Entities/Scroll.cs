using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Jumpybird.Entities
{
    public class Scroll
    {
        public Vector2 Position;
        public Texture2D Texture;

        public int amineTimer = 10;
        public double amineElapse=0;
        public int decalX = 0;

        public Scroll()
        {
            this.Position = new Vector2(0, 529);
            this.Texture = Statics.CONTENT.Load<Texture2D>("Textures/scroll");

        }

        public void update()
        {
            amineElapse += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (amineElapse > amineTimer)
            {
                this.decalX+=2;
                if (this.decalX >14 )
                    this.decalX=0;
                amineElapse = 0;
            }
        }
        public void draw()
        {
            
            Statics.SPRITEBATCH.Draw(this.Texture, this.Position,new Rectangle(this.decalX,0,Statics.GAME_WIDTH,14),Color.White);
            
        }
    }
}

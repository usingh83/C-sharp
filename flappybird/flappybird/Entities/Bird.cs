using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Jumpybird.Entities
{
    public class Bird
    {
        public Texture2D[] Texture;
        public float rotation;

        public float YSpeed;
        public int TexturePosition;
        public Vector2 position;

        
        public Texture2D[] CountDown;
        public bool CountDownComplete = false;
        public int countdowntimer = 1000;
        public double countdownelapse = 0;
        public int countdownPosition;


        public int jumptime=500;
        public double jumpelapsed=0;

        public int amineTimer=300;
        public double amineElapse=0;
        public int textureAdd = 1;
        public bool dead = false;
        public bool canjump = true;
        public bool debug=false;
        public Bird()
        {
            Texture=new Texture2D[3];
            this.Texture[0]= Statics.CONTENT.Load<Texture2D>("Textures/Bird-1");
            this.Texture[1]= Statics.CONTENT.Load<Texture2D>("Textures/Bird-2");
            this.Texture[2]= Statics.CONTENT.Load<Texture2D>("Textures/Bird-3");
            CountDown = new Texture2D[3];
            this.CountDown[0] = Statics.CONTENT.Load<Texture2D>("Textures/Start-2");
            this.CountDown[1] = Statics.CONTENT.Load<Texture2D>("Textures/Start-3");
            this.CountDown[2] = Statics.CONTENT.Load<Texture2D>("Textures/Start-4");
            YSpeed=0;
            this.position = new Vector2(150, 300);
        }
        public void Update()
        {
            if (!CountDownComplete)
            {
                countdownelapse += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
                if (countdownelapse > countdowntimer)
                {
                    this.countdownPosition += 1;
                    countdownelapse = 0;
                }
                if (countdownPosition > 2)
                {
                    CountDownComplete = true;
                    dead = false;
                }
            }
            else
            {
                YSpeed += 0.2f;
                jumpelapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
                if (jumpelapsed > jumptime)
                {
                    canjump = true;
                    jumpelapsed = 0;
                }
                amineElapse += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
                if (amineElapse > amineTimer)
                {
                    this.TexturePosition += this.textureAdd;
                    if (this.TexturePosition == 2 || this.TexturePosition == 0)
                        this.textureAdd = this.textureAdd * -1;
                    amineElapse = 0;
                }
                if (Statics.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space) && canjump)
                {
                    YSpeed = -8f;
                }
                rotation = (float)Math.Atan2(YSpeed, 10);

                //if (YSpeed > 0f)
                //{
                //    rotation = 1f;
                //}
                //else
                //    rotation = -1f;

                this.position.Y += YSpeed;
                if (this.position.Y > 500)
                {
                    dead = true;
                }
            }
        }
        public Rectangle Bound { get { return new Rectangle((int)this.position.X-14, (int)this.position.Y-10, 35, 35); } }
        public void Draw()
        {

            if (!CountDownComplete)
            {
                Statics.SPRITEBATCH.Draw(this.CountDown[this.countdownPosition], new Vector2(0, 0), null, Color.White,0f,new Vector2(0,0),1f,SpriteEffects.None,0f);
            }
            else
            {
                Statics.SPRITEBATCH.Draw(this.Texture[this.TexturePosition], this.position, null, Color.White, this.rotation, new Vector2(20, 20), 1f, SpriteEffects.None, 0f);
            }
            if (debug)
            {
                //show bugs
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.Bound, new Color(1f, 0f, 0f, 0.3f));
            }
        }
    }
    
}

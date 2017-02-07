using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Jumpybird.Screens
{
    public class GameScreen : Screen
    {
        public Texture2D BackGround;
        public Texture2D sand;
        public Texture2D GameOver;
        

        public Entities.Bird bird;
        public Entities.Scroll Scroll;
        public List<Entities.Pipe> Pipe;
        public static readonly SamplerState LinearWrap;
        public int pipetimer = 1500;
        public double pipeElapse = 0;
        public int score = 0;
        public SpriteFont font;
        public bool debug;
       
        
        public GameScreen()
        {


        }
        public override void LoadContent()
        {
            BackGround = Statics.CONTENT.Load<Texture2D>("Textures/Background");
            sand = Statics.CONTENT.Load<Texture2D>("Textures/sand");
            font = Statics.CONTENT.Load<SpriteFont>("font/font");
            GameOver = Statics.CONTENT.Load<Texture2D>("Textures/Gameover");

            base.LoadContent();
            Reset();
                      
        }

        public void Reset()
        {
            
            bird = new Entities.Bird();
            Pipe = new List<Entities.Pipe>();
            //Pipe.Add(new Entities.Pipe());

  
            Scroll = new Entities.Scroll();
            score = 0;
            
        }

        public override void update()
        {
            base.update();
            if (!bird.dead)
                {
                    pipeCreator();
                    for (int i = Pipe.Count - 1; i > -1; i--)
                    {
                        if (Pipe[i].Position.X < -50 || bird.dead)
                            Pipe.RemoveAt(i);
                        else
                        {
                            Pipe[i].Update();
                            if (!Pipe[i].scored && bird.position.X > Pipe[i].Position.X + 50)
                            {
                                Pipe[i].scored = true;
                                score++;
                            }
                            if (bird.Bound.Intersects(Pipe[i].TopBound) || bird.Bound.Intersects(Pipe[i].bottomBound))
                            {
                                bird.dead = true;
                            }

                        }

                    }


                    foreach (var item in Pipe)
                    {
                        item.Update();
                    }
                    if (bird.CountDownComplete)
                    {
                        Scroll.update();
                    }
                    bird.Update();
                }
            

                if (bird.dead && Statics.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
                {
                    this.Reset();
                }
            
        }
        public void Score()
        {
        }
        public void pipeCreator()
        {
            pipeElapse += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (bird.CountDownComplete)
            {
                if (pipeElapse > pipetimer)
                {
                    Pipe.Add(new Entities.Pipe());
                    pipeElapse = 0;
                }
            }
        }
        public override void draw()
        {
            Statics.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,SamplerState.LinearWrap, null, null);
            Statics.SPRITEBATCH.Draw(this.BackGround, Vector2.Zero, Color.White);
            
           
                foreach (var item in Pipe)
                {
                    item.Draw();
                }
                
            
            Statics.SPRITEBATCH.Draw(this.sand,new Vector2(0,529), Color.White);
            Scroll.draw();
            bird.Draw();
            if (bird.dead)
            {
                Statics.SPRITEBATCH.Draw(this.GameOver, Vector2.Zero, Color.White);
            }
            Statics.SPRITEBATCH.DrawString(this.font, this.score.ToString(), new Vector2(10, 10), Color.Red);

            Statics.SPRITEBATCH.End();
            
            base.draw();
        }
    }
}

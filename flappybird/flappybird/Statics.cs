using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Jumpybird
{
    public class Statics
    {
        public static int GAME_WIDTH = 400;
        public static int GAME_HEIGHT = 600;

        public static string GAME_TITLE="JumpyBirds";

        public static Random RANDOM = new Random();

        public static GameTime GAMETIME;
        public static SpriteBatch SPRITEBATCH;
        public static ContentManager CONTENT;
        public static GraphicsDevice GRAPHICDEVICE;
        public static Managers.InputManager INPUT;
        public static Texture2D PIXEL;

    }
}

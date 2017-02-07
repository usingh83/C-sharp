using System;

namespace Jumpybird
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Jumpybird game = new Jumpybird())
            {
                game.Run();
            }
        }
    }
#endif
}


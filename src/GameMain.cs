using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{

    public enum Type {
    Dust,
    Gas,
    Liquid,
    Solid
    };
    
    public class GameMain
    {  
        private static Game game;

        public static void Main ()
        {
            //Open the game window
            game = new Game ();
            game.Run ();
        }
    }
}
using System;

namespace Ex02
{
    class Program
    {
        static void Main()
        {
            GameManager manager = new GameManager();
            manager.Run();
        }
    }
}

/*
 * what which is in the main is a placeholder for now
 * the main will work later as call to Menu screen which will do the logic for the settings of the game
 * feel free to chaange the main if its for Menu (which need to be crearted) or for testing purposes
 * 
 * 
 * what i did this session:
 * 
 * make metod for game board which turn the board into string for printing
 * screen class 
 * in screen class game loop logic
 * 
 * 
 * what left to do:
 * 
 * Menu Screen
 * CPU player class (polymorphic to player class)
 * CPU player logic (i have good idea for it )
 * modify the Screen.runGame in terms if CPU player is on
 * check if we can tight up the access of methods and data memebers 
 * 
 */


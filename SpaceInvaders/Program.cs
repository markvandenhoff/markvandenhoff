using System;
using SplashKitSDK;
 
public class Program
{
    public static void Main()
    {
           //Create New Objects - Window and player
        Window gameWindow = new Window("SpaceInvaders", 600, 600);
        SpaceInvaders spaceInvaders = new SpaceInvaders(gameWindow);
 
        while(! gameWindow.CloseRequested && !spaceInvaders.Quit) //while the gameWindow is not closed
        {
            spaceInvaders.HandleInput(); // handle inputs
            spaceInvaders.Update(); // update the game
            spaceInvaders.Draw(); // draw the game 
        }
    }
}
using System;
using SplashKitSDK;

public class Player // New Player Class
{
    // Declare Variables
    private Bitmap _PlayerBitmap;
    public double _x { get; private set; }
    public double _y { get; private set; }
    public bool Quit { get; private set; }

    public int Lives = 5; // Player starts with 5 lives

    public int Score; // Player has a score

    //Declare X, Y and ANGLE variables
    public double X
    {
        get { return _x; }
        set { _x = value; }
    }
    public double Y
    {
        get { return _y; }
        set { _y = value; }
    }

    //Declare Width = Width of Bitmap File
    public int Width
    {
        get 
        {
            return _PlayerBitmap.Width;
        }
    }
    //Declare Height = Height of Bitmap File
    public int Height
    {
        get 
        {
            return _PlayerBitmap.Height;
        }
    }
    //Declare new Player Class, pass in gamewindow constructor
    public Player (Window gameWindow)
    {
        Quit = false;
        _PlayerBitmap = new Bitmap("Player", "Player.png"); //use the image 'Player'
        X = (gameWindow.Width - Width) / 2; // Set X = half of width - middle of screen
        Y = (gameWindow.Height) * 0.9; // somewhere near the bottom or 90% of the screen
    }


    // Declare new method DRAW
    public void Draw()
    {
        SplashKit.ProcessEvents();
        _PlayerBitmap.Draw(X, Y); //Draw the bitmap
    }

    //Declare new method Handle Inputs
    public void HandleInput()
    {
        const int speed = 5;
        // Let the keyboard buttons move the Player
        SplashKit.ProcessEvents(); 
        if (SplashKit.KeyDown(KeyCode.LeftKey)) //left arrow key moves left
            X = X - speed;
        if (SplashKit.KeyDown(KeyCode.RightKey)) //right arrow key moves right
            X = X + speed;
        if (SplashKit.KeyDown(KeyCode.EscapeKey)) //escape key will quit
            Quit = true;
        if (Lives <= 0)
        {
            SplashKit.ClearScreen(Color.Red);
            SplashKit.DrawText("GAME OVER!", Color.Black, 300, 300);
        }
            
    }

    //Delcare new method StayOnWindow
    public void StayOnWindow(Window gameWindow) //pass in gamewindow variable
    {
        const int GAP = 10; // GAP = 10
        if (Y + _PlayerBitmap.Height > gameWindow.Height - GAP) // case for when Y is close to bottom
        {
            // if case true, then do a bounce and dont go off window. 
            Y = gameWindow.Height - GAP - _PlayerBitmap.Height;
            Y = gameWindow.Height - GAP - _PlayerBitmap.Height - GAP * 5;
        }
        if (Y < GAP) // case for when Y is less than the GAP
        {
            // if case true, then do a bounce and dont go off window. 
            Y = GAP;
            Y = Height - GAP;
        }
        if (X + _PlayerBitmap.Width > gameWindow.Width - GAP) // case for when X is close to right side
        {
            // if case true, then do a bounce and dont go off window. 
            X = gameWindow.Width - GAP - _PlayerBitmap.Width;
            X = gameWindow.Width - GAP - _PlayerBitmap.Width - GAP * 5;
        }
        if (X < GAP) // case for when X is less than the GAP
        {
            // if case true, then do a bounce and dont go off window. 
            X = GAP;
            X = Width - GAP;
        }
   }
   public bool CollidedWithAlien(Alien alien) // collided with method
   {
       // return true or false if the colliision occurs
       return _PlayerBitmap.CircleCollision(X, Y, alien.CollisionCircle);
   }
}
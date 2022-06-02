using System;
using SplashKitSDK;

public class Alien
{
    // Declare Variables
    public double _x { get; private set; }
    public double _y { get; private set; }
    private Vector2D Velocity { get; set; }
    private Bitmap _AlienBitmap;


    //Declare X, Y and ANGLE variables
    public double X // Declare X
    {
        get { return _x; }
        set { _x = value; }
    }
    public double Y // Declare  Y
    {
        get { return _y; }
        set { _y = value; }
    }
    public int Width // Declare width = 50
    {
        get 
        {
            return _AlienBitmap.Width;
        }
    }
    public int Height //Declare Height = 50
    {
        get 
        {
            return _AlienBitmap.Height;
        }
    }

    // Circle Constructor
    public Circle CollisionCircle // Collision Circle
    {
        // work out the middle of the collission circle
        get { return SplashKit.CircleAt((X+Width/2), (Y+Height/2), 20); }
    }

    // Robot constructor
    public Alien(Window gameWindow, Player player)
    {
        _AlienBitmap = new Bitmap("Alien", "Alien.png"); //use the image 'Player'
        {
            Y = gameWindow.Height * 0.1;
            X = gameWindow.Width * 0.1;

        }        
    }

    public void Update() // update method
    {
        int SPEED = 10;
        X = X + SPEED ; // add the X velocity to the X
    }    

    public bool IsOffScreen(Window screen) // new method for offscreen
    {
        // this returns true (bool) if the robot os off the screen
        return ( X < -Width || X > screen.Width || Y < -Height || Y > screen.Height);
    }
    public void Draw()
    {
        _AlienBitmap.Draw(X, Y); //Draw the bitmap
    }

}

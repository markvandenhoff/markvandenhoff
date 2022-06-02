using System;
using SplashKitSDK;

public class Bullet // New Player Class
{
    // Declare Variables
    private Bitmap _BulletBitmap;
    public double _x { get; private set; }
    public double _y { get; private set; }

    private Vector2D Velocity { get ; set ; }

    //Declare X, Y
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
            return _BulletBitmap.Width;
        }
    }
    //Declare Height = Height of Bitmap File
    public int Height
    {
        get 
        {
            return _BulletBitmap.Height;
        }
    }
    //Declare new Player Class, pass in gamewindow constructor
    public Bullet (Window gameWindow, Player _Player)
    {
        _BulletBitmap = new Bitmap("Bullet", "Bullet.png"); //use the image 'player'
       // make the bullet come from player
       X = _Player.X + _Player.Width / 2;
       Y = _Player.Y + _Player.Height / 2;

    }


    // Declare new method DRAW
    public void Draw()
    {
        SplashKit.ProcessEvents();
        SplashKit.DrawBitmap(_BulletBitmap, X, Y);
    }

    public void Update() // update method
    {
        int SPEED = -5;
        Y = Y + SPEED; // add the X velocity to the X
    }    
    public bool IsOffScreen(Window screen) // new method for offscreen
    {
        // this returns true (bool) if the robot os off the screen
        return ( X < -Width || X > screen.Width || Y < -Height || Y > screen.Height);
    }

   public bool BulletCollidedWith(Alien alien) // collided with method
   {
       // return true or false if the colliision occurs
       return _BulletBitmap.CircleCollision(X, Y, alien.CollisionCircle);
   }
}
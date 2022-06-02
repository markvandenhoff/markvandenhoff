using System;
using SplashKitSDK;
using System.IO;
using System.Collections.Generic;
public class SpaceInvaders // Class
{
    // Declare Variables
    private Player _Player;
    private Window _GameWindow;
    private List<Alien> _Aliens = new List<Alien>(); //new list for aliens
    private List<Alien> _removedAliens = new List<Alien>(); // new list to remove aliens
    private List<Bullet> _Bullets = new List<Bullet>(); //new list for robots
    private List<Bullet> _removedBullets = new List<Bullet>(); // new list to remove robots
    int noOfAliens = 0;


    // PlayerRun Constructor
    public SpaceInvaders(Window gameWindow)
    {
        // declare gamewindow = gamewindow
        _GameWindow = gameWindow;
    
        // create new player
        Player player = new Player(_GameWindow);
        
        // player = player local 
        _Player = player;

        // create a new timer
    }
    public bool Quit
    {
        get
        {
            return _Player.Quit;
        }
    }
    public void HandleInput() // new method to handle inputs
    {
        _Player.HandleInput(); // call player class and handle inputs, pass gamewindow
        _Player.StayOnWindow(_GameWindow); // call player class and stay on window, pass gamewindow

    }

    public void Update() // update method to update the random alien
    {

        foreach (Alien alien in _Aliens) // check aliens in list
        {
            alien.Update(); // update all aliens in the list
        }
        CheckCollisions(); // run check collision method
        double randomNumber = SplashKit.Rnd(1000);
        if (randomNumber < 25)
        {
            _Aliens.Add(RandomAlien()); // add more aliens
        }
        if (SplashKit.KeyDown(KeyCode.SpaceKey)) // if mouse left clicked..
        {
            _Bullets.Add(AddBullet()); // add new bullet to the bullets list
        }
        foreach (Bullet bullet in _Bullets) // for each bullet in the bullet list
        {
            bullet.Update(); // update bullets in the list
        }
        
    }
    public void CheckCollisions() // new method to check for collisions
    {
        foreach (Alien alien in _Aliens) // for each alien in list
        {
            if (_Player.CollidedWithAlien(alien)) // if a player collides with a alien
            {
                _Player.Lives = _Player.Lives - 1; // player loses 1 life
            }
            // check if alien collided with player OR alien is off screen
            if(alien.IsOffScreen(_GameWindow)) 
            {
                alien.Y = alien.Y + alien.Height; // add alien to the remove alien list
                alien.X = 10;
            }
            foreach (Bullet bullet in _Bullets) // for each bullet in the bullet list
            {
                if (bullet.BulletCollidedWith(alien)) // if bullet collides with robot
                {
                    _removedBullets.Add(bullet); // add the bullet to the removed bullets list
                    _removedAliens.Add(alien); // add the robot to the removed robots list
                    _Player.Score = _Player.Score + 10;
                }
            }
        }
        foreach (Alien alien in _removedAliens)
        {
            _Aliens.Remove(alien);
        }
        foreach (Bullet bullet in _removedBullets) // for each bullet in the remove robot list
        {
            _Bullets.Remove(bullet); // remove bullet from the bullets list
        }
    }
    public void Draw() // method to draw
    {
        _GameWindow.Clear(Color.White); // clear the gamewindow
        foreach (Alien alien in _Aliens) // for each alien in the alien list
        {
            alien.Draw(); // draw the aliens in the list

        }
        DisplayHUD();
        _Player.Draw(); // draw the player
        if (_Player.Lives <= 0) // if player lifes is equal or less than 0
        {
            _GameWindow.Clear(Color.Red);
            SplashKit.DrawText("Game Over!!!", Color.Black, 200 ,250);
        }
        foreach (Bullet bullet in _Bullets) // for each bullet in the bullet list
        {
            bullet.Draw(); //draw the bullet
        }
        _GameWindow.Refresh(60); //refresh the window
    }
    public Alien RandomAlien() // method to create random alien
    {
        Alien _RandomAlien = new Alien(_GameWindow, _Player); // new alien
        return _RandomAlien;
        
    }
    public Bullet AddBullet() // new method to add bullet
    {
        Bullet _RandomBullet = new Bullet(_GameWindow, _Player); // create a new bullet object with gamewindow and player passed in
        return _RandomBullet; // return bullet
    }

    public void DisplayHUD()
    {
        SplashKit.DrawText("PLAYER SCORE: " + _Player.Score, Color.Black, _GameWindow.Width * 0.05, _GameWindow.Height * 0.975);
    }

}
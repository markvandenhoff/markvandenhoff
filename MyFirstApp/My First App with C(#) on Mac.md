# My First App with C(#) on Mac
Here I am going to show you how to create a simple application with C# using [Microsoft Visual Code](https://code.visualstudio.com/). (Assuming you have .Net already installed)

## Step 1 - Open the Terminal and Navigate to a folder to create your new app. (i have created a new folder in documents called 'Code'.
Open the terminal and navigate to your code folder.

`cd ~/Documents/Code`

![ScreenShot1](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot1.png)

Then make a new folder / directory for you app

`mkdir MyFirstApp`

![ScreenShot2](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot2.png)

Navigate to the new app folder

`cd MyFirstApp`

![ScreenShot3](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot3.png)

## Step 2 - Create a new console for the basis of the application

To create a new Console.  Type the command into the terminal

`skm dotnet new console`

![ScreenShot4](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot4.png)

A new console will be created


## Step 3 - Open Visual Studio Code and Open the new Folder 'MyFirstApp'

Open Visual Code

Open Folder

In the right hand side bar, you will the folder 'MyFirstApp', and below it a file called **'Program.cs'**. Click on this file, and open to edit to see the code. it should contain the below example code.

	using System;
	using Splashkit;
	public class Program;
	{
		public static Main()
		{
		
		}
	}

![ScreenShot5](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot5.png)

## Step 3A - NOTE - Mac Users need to delete the below line from the MyFirstApp.csproj file or you will get an ERRROR on build. 

    <ImplicitUsings>disable</ImplicitUsings> - Delete this line

![ScreenShot6](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot6.png)

## Step 4 - Let's add our first line of Code & Test our Program works!
Add in a line of code below to the '**Program.cs**' file


	using System;
	using Splashkit;
	public class Program;
	{
		public static Main()
		{
			Console.WriteLine("This is My First App!!");
		}
	}
	
![ScreenShot7](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot7.png)

## Step 5 - Return to the Terminal and Build & Run the our app to test it!
Return to the Terminal. - Ensure you are still in the MyFirstApp Folder!

We first need to **'Build'** (Compile) the code to allow it to run. To **Build** the App we need to run the below commmand

`skm dotnet build`

![ScreenShot8](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot8.png)

If the code contains any errors, it will show the code line, and what the error is. This is very handy to troubleshoot when buulding applications! 
After the Successfell Build, we can then 'Run' the program. Type the below command to 'Run' the App.

`skm dotnet run`

![ScreenShot9](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot9.png)

The Console should output the below text.

`This is My First App!!` 
Congrats! You have just created your first app! - (very basic)

## Step 6 - Let's make a House with Shapes!!
Return to Visual Code, and we can start further develop our application. Below our last line of code, let's add some new code to create a 'new window' to open on our screen to display some shapes.

	using System;
	using Splashkit;
	public class Program;
	{
		public static Main()
		{
			Console.WriteLine("This is My First App!!");
			
			Window myFirstAppWindow = new Window("This is My First App Window", 800, 600);
		}
	}


We can now return to the Terminal to carry out the same command to check our new window will open. Return to the Terminal and cerry out the same commands to 'Build' the App, and then 'Run' the App.

`skm dotnet build`

`skm dotnet run`

A new window should pop up in the middle of the screen and have the heading - **This is My First App Window** (note this may flash real quickly, as we have not set the time for it to display on screen!)

## Step 7 - Let's add some shapes

To create a background color let's add the below code. (The Background Sky)


	myFirstAppWindow.Clear(Color.LightBlue);
	
Let's create some grass for the House to Sit on

    myFirstAppWindow.FillRectangle(Color.BrightGreen, 0, 500, 800, 600);

Let's add in a nice yellow Sun in the sky to set the scene. 

    myFirstAppWindow.FillCircle(Color.Yellow, 550, 100, 50);

At this point, we should build and test our app. You always want to build incrementantly and build and test regularly to find errors and fix them promptly before you have too many errors! 
Before we do that, we should add some code to ensure our Window stays open long enough for us to see it!
Our Code should now look like the below

	using System;
	using Splashkit;
	public class Program;
	{
		public static Main()
		{
			Console.WriteLine("This is My First App!!");
			
			Window myFirstAppWindow = new Window("This is My First App Window", 800, 600);
			myFirstAppWindow.Clear(Color.LightBlue);
        	myFirstAppWindow.FillRectangle(Color.BrightGreen, 0, 500, 800, 600);
        	myFirstAppWindow.FillCircle(Color.Yellow, 550, 100, 50);
        	
        	myFirstAppWindow.Refresh();
       		SplashKit.Delay(5000);
		}
	}



## Step 8 - Let's Build & Run our App

Return to the terminal and Build & Run

`skm dotnet build`

`skm dotnet run`

We should now see a Blue Background, with Green Grass and a Nice Yellow Sun on the screen! The window should stay open for 5 seconds as we set the delay to 5000 milliseconds. 

## Step 9 - Let's add some more shapes to build our house! 
Returning to Visual Code, Lets all some more lines of Code to form our House. To build the body of the house, add the below code. 

    myFirstAppWindow.FillRectangle(Color.Red, 300, 300, 200, 200);

Now let's add a Roof to the house!

    myFirstAppWindow.FillRectangle(Color.Red, 300, 300, 200, 200);
    
Now let's add some windows... 

    myFirstAppWindow.FillRectangle(Color.White, 325, 350, 50, 50);
    myFirstAppWindow.FillRectangle(Color.White, 425, 350, 50, 50);

Finally lets finish our house and add in a door! 

    myFirstAppWindow.FillTriangle(Color.DarkGray, 250, 300, 400, 150, 550, 300);

We should now have a nice little house to view with our blue sky and sun shining down on it. Let's build and run our program to see... 

The Final Code output should look like the below...

	using System;
	using Splashkit;
	public class Program;
	{
		public static Main()
		{
			Console.WriteLine("This is My First App!!");
			
			Window myFirstAppWindow = new Window("This is My First App Window", 800, 600);
			myFirstAppWindow.Clear(Color.LightBlue);
        	myFirstAppWindow.FillRectangle(Color.BrightGreen, 0, 500, 800, 600);
        	myFirstAppWindow.FillCircle(Color.Yellow, 550, 100, 50);
        	
        	myFirstAppWindow.FillRectangle(Color.Red, 300, 300, 200, 200);
       	 	myFirstAppWindow.FillRectangle(Color.White, 325, 350, 50, 50);
       	 	myFirstAppWindow.FillRectangle(Color.White, 425, 350, 50, 50);
      	  	myFirstAppWindow.FillRectangle(Color.SaddleBrown, 375, 425, 50, 75);
       	 	myFirstAppWindow.FillTriangle(Color.DarkGray, 250, 300, 400, 150, 550, 300);
        	
        	myFirstAppWindow.Refresh();
       		SplashKit.Delay(5000);
		}
	}
	
Return to the Terminal and let's test out to see what we have created!

`skm dotnet build`

`skm dotnet run`

![ScreenShot10](https://github.com/markvandenhoff/markvandenhoff/blob/main/MyFirstApp/Images/ScreenShot10.png)

## Step 10 - Congratulations! - You have created your first app using C#!
You have now created a very simple app with C#. You can now utilise some creativity to add some more shapes, or create a whole new picture! Have a play around and see what you can come up with.. Thanks for following along! Happy Coding!

--Written by Mark Vandenhoff



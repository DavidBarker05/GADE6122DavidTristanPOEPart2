using System;
using System.Windows.Forms;

namespace GADE6122DavidTristanPOE
{
    public partial class Form1 : Form
    {

        private GameEngine gameEngine; // Game engine
        // The booleans are to make sure player presses only one key once
        bool wPressed = false, dPressed = false, sPressed = false, aPressed = false; // Booleans to show if buttons are already being pressed
        private bool keyPressed = false; // Boolean for if any key is pressed

        public Form1()
        {
            // Keyboard input
            /*
             * We needed to get the moment that a user presses a key
             * so that we could get user input, Microsoft ([s.a.])
             * shows how to do this in their API with the
             * Control.KeyDown Event.
             * 
             * In order to do anything when a button is pressed a
             * method needs to be created that follows the layout
             * of the KeyEventHandler Delegate which Microsoft
             * ([s.a.]) shows how to do in their API.
             * 
             * NOTE: This is an in-text reference to see reference
             * list go to README folder.
             */
            KeyDown += Form1_KeyDown;
            /*
             * We needed to get the moment that a user releases a
             * key so that we could tell when a user has stopped
             * pressing a key and can now press again, Microsoft
             * ([s.a.]) shows how to do this in their API with the
             * Control.KeyUp Event.
             * 
             * In order to do anything when a button is released a
             * method needs to be created that follows the layout
             * of the KeyEventHandler Delegate which Microsoft
             * ([s.a.]) shows how to do in their API.
             * 
             * NOTE: This is an in-text reference to see reference
             * list go to README folder.
             */
            KeyUp += Form1_KeyUp;
            InitializeComponent();
            gameEngine = new GameEngine(10); // Make 10 max levels
            UpdateDisplay(); // Update to show level
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameEngine.Direction direction = GameEngine.Direction.None;
            switch ((char)e.KeyValue) // Check key input and make direction correspond to key
            {
                case 'W':
                    direction = GameEngine.Direction.Up;
                    wPressed = true;
                    break;
                case 'D':
                    direction = GameEngine.Direction.Right;
                    dPressed = true;
                    break;
                case 'S':
                    direction = GameEngine.Direction.Down;
                    sPressed = true;
                    break;
                case 'A':
                    direction = GameEngine.Direction.Left;
                    aPressed = true;
                    break;
            }
            if (!keyPressed) gameEngine.TriggerMovement(direction); // Move only if no movement keys are already pressed
            keyPressed = wPressed || dPressed || sPressed || aPressed; // Set key pressed to be if any key pressed, but after movement to ensure the player moves
            UpdateDisplay(); // Update display to show movement
        }

        // Reset that a key is pressed when it is release
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch ((char)e.KeyValue)
            {
                case 'W':
                    wPressed = false;
                    break;
                case 'D':
                    dPressed = false;
                    break;
                case 'S':
                    sPressed = false;
                    break;
                case 'A':
                    aPressed = false;
                    break;
            }
            keyPressed = wPressed || dPressed || sPressed || aPressed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdateDisplay()
        {
            lblDisplay.Text = gameEngine.ToString(); // Show level
            lblLevelNumber.Text = $"LEVEL {gameEngine.CurrentLevelNumber} OF {gameEngine.LevelAmt}"; // Show level number
        }

    }
}

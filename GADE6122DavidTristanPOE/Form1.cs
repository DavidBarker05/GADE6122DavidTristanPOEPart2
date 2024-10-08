using System.Windows.Forms;

namespace GADE6122DavidTristanPOE
{
    public partial class Form1 : Form
    {

        private GameEngine gameEngine; // Game engine
        // The booleans are to make sure player presses only one key once
        private bool wPressed = false, aPressed = false, sPressed = false, dPressed = false; // Booleans to show if buttons are already being pressed
        private bool movePressed = false; // Boolean for if any key is pressed
        private bool upPressed = false, leftPressed = false, downPressed = false, rightPressed = false;
        private bool attackPressed = false;

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
            GameEngine.Direction moveDirection = GameEngine.Direction.None;
            GameEngine.Direction attackDirection = GameEngine.Direction.None;
            switch (e.KeyCode) // Check key input and make direction correspond to key
            {
                case Keys.W:
                    moveDirection = GameEngine.Direction.Up;
                    wPressed = true;
                    break;
                case Keys.A:
                    moveDirection = GameEngine.Direction.Left;
                    aPressed = true;
                    break;
                case Keys.S:
                    moveDirection = GameEngine.Direction.Down;
                    sPressed = true;
                    break;
                case Keys.D:
                    moveDirection = GameEngine.Direction.Right;
                    dPressed = true;
                    break;
                case Keys.Up:
                    attackDirection = GameEngine.Direction.Up;
                    upPressed = true;
                    break;
                case Keys.Left:
                    attackDirection = GameEngine.Direction.Left;
                    leftPressed = true;
                    break;
                case Keys.Down:
                    attackDirection = GameEngine.Direction.Down;
                    downPressed = true;
                    break;
                case Keys.Right:
                    attackDirection = GameEngine.Direction.Right;
                    rightPressed = true;
                    break;
            }
            if (!movePressed && (wPressed || aPressed || sPressed || dPressed)) gameEngine.TriggerMovement(moveDirection); // Move only if no movement keys are already pressed
            movePressed = wPressed || aPressed || sPressed || dPressed; // Set key pressed to be if any key pressed, but after movement to ensure the player moves
            if (!attackPressed && (upPressed || leftPressed || downPressed || rightPressed)) gameEngine.TriggerAttack(attackDirection);
            attackPressed = upPressed || leftPressed || downPressed || rightPressed;
            UpdateDisplay(); // Update display to show movement
        }

        // Reset that a key is pressed when it is release
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
            }
            movePressed = wPressed || aPressed || sPressed || dPressed;
            attackPressed = upPressed || leftPressed || downPressed || rightPressed;
        }

        private void UpdateDisplay()
        {
            lblDisplay.Text = gameEngine.ToString(); // Show level
            lblLevelNumber.Text = $"LEVEL {gameEngine.CurrentLevelNumber} OF {gameEngine.LevelAmt}"; // Show level number
            lblHitPoints.Text = $"{gameEngine.HeroStats} HP"; // Show level number
        }

    }
}

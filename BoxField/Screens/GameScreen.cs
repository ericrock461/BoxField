using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.White);

        //create a list to hold a column of boxes        
        List<Box> boxes = new List<Box>();

        Box hero;


        
        Random randGen = new Random();

        int boxX;
        


        int boxTimer = 0;



        public GameScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            //TODO - set game start values

            hero = new Box(0, 0, 75);
            

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;           
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            boxTimer++;
            
            boxX = randGen.Next(1, 795);

            //update location of all boxes (drop down screen)
            foreach (Box b in boxes)
            {
                b.y++;
            }

            //TODO remove box if it has gone off screen          

           /* if (y >= 300) 
                    {
                        boxes.RemoveAt(0);
                    }*/


                /*foreach (Box b in boxes)
                 * if (b.y >= 300)
                {
                    boxes.Remove(b);
                }*/

                //TODO add new box if it is time
                if (boxTimer == 10)
            {
                Box b = new Box(boxX, 225, 5);
                boxes.Add(b);

                boxTimer = 0;
            }



            //move hero            
            if (leftArrowDown)
            {
                hero.Move("left");

                //adds to moveCount
            }
            if (rightArrowDown)
            {
                hero.Move("right");
            }
            if (upArrowDown)
            {
                hero.Move("up");
                moveCount++;
            }
            if (downArrowDown)
            {
                hero.Move("down");
                moveCount++;
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO - draw boxes to screen
            foreach (Box b in boxes)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

            /*Make the following changes to the BoxField game we started in class.
            Add a second list for the right side so that boxes fall to the right of the first column of boxes, (same y position).
            Create a pattern.That is have the boxes generated to the left of the one before it 
            for say 7 boxes, and then generate all boxes to the right of the previous box for 12 boxes, etc.
            Add a colour value to the box class and generate a random colour for each box that drops.
            There are multiple ways to do this.
            One way is to create an array of type SolidBrush and fill it with different coloured brushes. 
            When creating a new box generate a random number from 0 up to the number of brushes in the array.
            Send this value to the object constructor. For example:
            Box b = new Box(100, 0, 1);
            In the example above the 1 is the random colour value.Then when drawing 
            in the paint method use the brushes array at the index indicated by the colour value in the object to select the desired brush color.*/
        }
    }
}

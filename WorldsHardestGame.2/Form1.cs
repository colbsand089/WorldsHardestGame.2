//Colbey Sands 
//October 4, 2021
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldsHardestGame._2
{


    public partial class Form1 : Form
    {
        // Brushes for the objects/ shapes.
        SolidBrush CircleBrush = new SolidBrush(Color.Blue);
        SolidBrush SquareBrush = new SolidBrush(Color.Red);
        SolidBrush CenterBrush = new SolidBrush(Color.White);
        SolidBrush startBrush = new SolidBrush(Color.Green);
        SolidBrush endBrush = new SolidBrush(Color.Green);
        SolidBrush barrierBrush = new SolidBrush(Color.Gray);
        //lists
        List<Circle> circles = new List<Circle>();
        List<Rectangle> borders = new List<Rectangle>();
       
        bool leftArrowDown;
        bool rightArrowDown;
        bool upArrowDown;
        bool downArrowDown;

        bool moveOk = true;

        
       
        Circle hero;

        Circle c1;
        Circle c2;
        Circle c3;
        Circle c4;
        Circle c5;
        Circle c6;
        Circle c7;
        Circle c8;
        Circle c9;

        Rectangle r1;
        Rectangle r2;
        Rectangle r3;
        Rectangle r4;
        Rectangle r5;
        Rectangle r6;

        
        
        public Form1()
        {
            InitializeComponent();
            hero = new Circle(80, 150, 15, 3);
            
             c1 = new Circle(170, 100, 7, 5);
            circles.Add(c1);
             c2 = new Circle(200, 290, 7, 5);
            circles.Add(c2);
             c3 = new Circle(230, 100, 7, 5);
            circles.Add(c3);
            c4 = new Circle(260, 290, 7, 5);
            circles.Add(c4);
             c5 = new Circle(290, 100, 7, 5);
            circles.Add(c5);
            c6 = new Circle(320, 290, 7, 5);
            circles.Add(c6);
            c7 = new Circle(350, 100, 7, 5);
            circles.Add(c7);
            c8 = new Circle(380, 290, 7, 5);
            circles.Add(c8);
            c9 = new Circle(410, 100, 7, 5);
            circles.Add(c9);

            r1 = new Rectangle(50, 60, 390, 40);
            borders.Add(r1);
            r2 = new Rectangle(140, 300, 390, 40);
            borders.Add(r2);
            r3 = new Rectangle(50, 190, 90, 150);
            borders.Add(r3);
            r4 = new Rectangle(440, 60, 90, 150);
            borders.Add(r4);
            r5 = new Rectangle(30, 60, 20, 280);
            borders.Add(r5);
            r6 = new Rectangle(530, 60, 20, 280);
            borders.Add(r6);


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int x = hero.x;
            int y = hero.y;

            if (hero.x > 446)
            {
                gameTimer.Enabled = false;
                winLoseLabel.Visible = true;
                winLoseLabel.Text = "You Win!";
            }    

            if (rightArrowDown == true)
            {
                hero.Move("right");
            }

            if (leftArrowDown == true)
            {
                hero.Move("left");
            }

            if (upArrowDown == true)
            {
                hero.Move("up");
            }

            if (downArrowDown == true)
            {
                hero.Move("down");
            }

            Rectangle heroRec = new Rectangle(hero.x, hero.y, hero.size, hero.size);

            foreach (Rectangle r in borders)
            {
                if (heroRec.IntersectsWith(r))
                {
                    hero.x = x;
                    hero.y = y; 
                    break;
                }
            }
            // game engine code here
            //Movement inputs

           

            //Moving the circles
            foreach (Circle c in circles)
            {
                c.Move();
            }
            
            foreach (Circle c in circles)
            {
                if (c.y > 290)
                {
                    c.speed -= 5;
                }
                else if (c.y == 100)
                {
                    c.speed += 5;
                }
            }
           
            foreach (Circle c in circles)
            {
                if (hero.Collision(c))
                {
                    gameTimer.Enabled = false;
                    winLoseLabel.Visible = true;
                    winLoseLabel.Text = "You Lose!";
                }
            }

            
           

            








                //redraw the screen
                Refresh();
        }

        private void form1_Paint(object sender, PaintEventArgs e)
        {
            // Map shapes
            e.Graphics.FillRectangle(startBrush, 50, 100, 90, 100);
            e.Graphics.FillRectangle(CenterBrush, 140, 100, 300, 200);
            e.Graphics.FillRectangle(endBrush, 440, 200, 90, 100);
          
            
            //rec 1 
            e.Graphics.FillRectangle(barrierBrush, 50, 60, 390, 40);
           //rec 2 
            e.Graphics.FillRectangle(barrierBrush, 140, 300, 390, 40);
           // rec 3
            e.Graphics.FillRectangle(barrierBrush, 50, 190, 90, 150);
            //rec 4
            e.Graphics.FillRectangle(barrierBrush, 440, 60, 90, 150);
            // rec 5
            e.Graphics.FillRectangle(barrierBrush, 30, 60, 20, 280);
            //rec 6
            e.Graphics.FillRectangle(barrierBrush, 530, 60, 20, 280);
            
            
            //player Square
            e.Graphics.FillRectangle(SquareBrush, hero.x, hero.y, hero.size, hero.size);
            
            //circles
            foreach (Circle c1 in circles)
            {
                e.Graphics.FillEllipse(CircleBrush, c1.x, c1.y, c1.size, c1.size);
            }

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }

        }
    }
}
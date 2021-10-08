using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldsHardestGame._2
{
    class Circle
    {
        public int x, y, size, speed;
        
        public Circle (int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;

        }
        public void Move()
        {
            y += speed;
        }
        public void Move(string direction)
        {

            if (direction == "left")
            {
                x -= speed;
            }
            else if (direction == "right")
            {
                x += speed;
            }
            else if (direction == "up")
            {
                y -= speed;
            }
            else if (direction == "down")
            {
                y += speed;
            }

           
        }
        public bool Collision(Circle c)
        {
            Rectangle heroRec = new Rectangle(x, y, size, size);
            Rectangle circleRec = new Rectangle(c.x, c.y, c.size, c.size);

            if (heroRec.IntersectsWith(circleRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        
    }
}
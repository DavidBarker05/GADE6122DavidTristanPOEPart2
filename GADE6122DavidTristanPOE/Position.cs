namespace GADE6122DavidTristanPOE
{
    //Class Position created for storing x and y coordinates for a singular tile on the map 
    internal class Position
    {
        private int x, y; // Fields for x and y position

        //properties for x and y coordinates allowing access and modification of backing fields 
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        //constructor accepting x and y integer parameters
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

namespace MeteoService
{
    public class Point
    {
        private double x;
        private double y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Lon
        {
            get { return x; }
            set { x = value; }
        }

        public double Lat
        {
            get { return y; }
            set { y = value; }
        }
    }
}
namespace MeteoService
{
    public class Rectangle
    {
        private Point topleft;
        private Point bottomright;
        public Rectangle()
        {
        }
        public Rectangle(Point topleft, Point bottomright)
        {
            this.topleft = topleft;
            this.bottomright = bottomright;
        }

        public Point TopLeft
        {
            get { return topleft; }
            set { topleft = value; }
        }

        public Point BottomRight
        {
            get { return bottomright; }
            set { bottomright = value; }
        }
    }
}

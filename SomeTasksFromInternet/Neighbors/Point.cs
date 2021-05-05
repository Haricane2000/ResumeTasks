namespace _2nd_task
{
    public class Point
    {
        public string name;
        public double x;
        public double y;

        public Point(string name, double x, double y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
        public Point(double x, double y)
        {
            name = string.Empty;
            this.x = x;
            this.y = y;
        }

        public Point()
        {
            name = default;
            x = default;
            y = default;
        }
        public override string ToString()
        {
            return name + " " + x + " " + y;
        }
    }
}

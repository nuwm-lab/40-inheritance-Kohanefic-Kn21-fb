using System;

// Базовий клас "Трикутник"
public class Triangle
{
    protected double x1, y1, x2, y2, x3, y3;

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.x3 = x3;
        this.y3 = y3;
    }

    public void SetCoordinates(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.x3 = x3;
        this.y3 = y3;
    }

    public void PrintCoordinates()
    {
        Console.WriteLine($"Triangle vertices: ({x1}, {y1}), ({x2}, {y2}), ({x3}, {y3})");
    }

    public double CalculateArea()
    {
        return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
    }
}

// Похідний клас "Опуклий чотирикутник"
public class ConvexQuadrilateral : Triangle
{
    private double x4, y4;

    public ConvexQuadrilateral(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        : base(x1, y1, x2, y2, x3, y3)
    {
        this.x4 = x4;
        this.y4 = y4;
    }

    public void SetCoordinates(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
    {
        base.SetCoordinates(x1, y1, x2, y2, x3, y3);
        this.x4 = x4;
        this.y4 = y4;
    }

    public new void PrintCoordinates()
    {
        base.PrintCoordinates();
        Console.WriteLine($"Fourth vertex: ({x4}, {y4})");
    }

    public new double CalculateArea()
    {
        Triangle firstTriangle = new Triangle(x1, y1, x2, y2, x3, y3);
        Triangle secondTriangle = new Triangle(x1, y1, x3, y3, x4, y4);
        return firstTriangle.CalculateArea() + secondTriangle.CalculateArea();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Об'єкт класу "Трикутник"
        Triangle triangle = new Triangle(0, 0, 4, 0, 2, 3);
        triangle.PrintCoordinates();
        Console.WriteLine($"Triangle area: {triangle.CalculateArea()}\n");

        // Об'єкт класу "Опуклий чотирикутник"
        ConvexQuadrilateral quadrilateral = new ConvexQuadrilateral(0, 0, 4, 0, 4, 3, 0, 3);
        quadrilateral.PrintCoordinates();
        Console.WriteLine($"Quadrilateral area: {quadrilateral.CalculateArea()}");
    }
}

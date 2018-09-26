using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Program1
{

    public abstract class BaseShape
    {
        public abstract double Area { get; }
        public virtual void showArea()
        {
            Console.WriteLine("This is the area of a shape.");
        }
    }

    public class Square:BaseShape
    {
        double side = 0;
        public Square(double side)
        {
            this.side = side;
        }
        public override double Area
        {
            get
            {
                return side * side;
            }
        }
        public override void showArea()
        {
            Console.WriteLine("正方形的面积是：" + Area);
        }
    }

    public class Circle:BaseShape
    {
        double radius = 0;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double Area
        {
            get
            {
                return radius * radius * 3.1415926;
            }
        }
        public override void showArea()
        {
            Console.WriteLine("圆形的面积是：" + Area);
        }
    }

    public class Rectangle:BaseShape
    {
        double width = 0;
        double height = 0;
        public Rectangle(double width,double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double Area
        {
            get
            {
                return width * height;
            }
        }
        public override void showArea()
        {
            Console.WriteLine("长方形的面积是：" + Area);
        }
    }

    public class Triangle : BaseShape
    {
        private double side1 = 0;
        private double side2 = 0;
        private double side3 = 0;
        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
            
        }
        public override double Area
        {
            get
            {
                double p = (side1 + side2 + side3) / 2;
                return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
            }
        }
        public override void showArea()
        {
            Console.WriteLine("三角形的面积是：" + Area);
        }
    }


    public class ShapeFactory
    {
        public static BaseShape getShape(string type, double a=0,double b=0,double c=0)
        {
            BaseShape shape = null;

            switch (type)
            {
                case "Square":
                    shape = new Square(a);
                    break;
                case "Circle":
                    shape = new Circle(a);
                    break;
                case "Rectangle":
                    shape = new Rectangle(a,b);
                    break;
                case "Triangle":
                    shape = new Triangle(a,b,c);
                    break;


            }

            return shape;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            
            BaseShape shape;
            shape = ShapeFactory.getShape("Square", 5);
            shape.showArea();
            shape = ShapeFactory.getShape("Circle", 2);
            shape.showArea();
            shape = ShapeFactory.getShape("Rectangle", 2,3);
            shape.showArea();
            shape = ShapeFactory.getShape("Triangle", 3,4,5);
            shape.showArea();

        }
    }
}

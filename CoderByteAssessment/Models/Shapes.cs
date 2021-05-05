using System;
using System.Xml.Serialization;

namespace CoderByteAssessment.Models
{
    public class Shape
    {
        public Shape()
        {
        }
        public string Name { get; set; }
        public double Perimeter { get; set; }
        public double Area { get; set; }


    }

    [Serializable]
    public class Circle : Shape
    {
        private Circle() { }

        public Circle(string name, double radius)
        {
            Name = name;
            Area = Math.PI * radius * radius;
            Perimeter = 2 * Math.PI * radius;
        }

    }
    [Serializable]
    public class Triangle : Shape
    {
        private Triangle() { }

        public Triangle(string name, double height, double sideA, double sideB = 0, double sideC = 0)
        {
            Name = name;

            switch (name.ToLower())
            {
                case "equilateral":
                    Area = (height * sideA) / 2;
                    Perimeter = 3 * sideA;
                    return;

                case "isosceles":
                    Area = (height * sideA) / 2;
                    Perimeter = 2 * sideA + sideB;
                    return;

                case "scalene":
                    Area = (height * sideA) / 2;
                    Perimeter =  sideA + sideB + sideC;
                    return;
            }
        }

    }

    [Serializable]
    public class Square : Shape
    {
        private Square() { }
        public Square(string name, double width, double length)
        {
            Name = name;
            Area = width * length;
            Perimeter = (width + length) / 2;
        }

    }

    [Serializable]
    public class Rectangle : Shape
    {
        private Rectangle() { }

        public Rectangle 
            (string name, double width, double length)
        {
            Name = name;
            Area = width * length;
            Perimeter = (width + length) / 2;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using CoderByteAssessment.Models;

namespace CoderByteAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var testDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var testDirFolder = $"{testDir}/cache";

            Directory.CreateDirectory(testDirFolder);

            Circle circle = new Circle("Circle", 5);
            Triangle triangleEquilateral = new Triangle("equilateral", 5, 10);
            Triangle triangleIsosceles = new Triangle("isosceles", 5, 10);
            Triangle triangleScalene = new Triangle("scalene", 5, 10, 15);
            Square Square = new Square("Square", 5, 10);
            Rectangle rectangle = new Rectangle("Rectangle", 5, 10);
            List<Shape> shapesToSerialize = new List<Shape>()
            { circle, triangleEquilateral, triangleIsosceles, triangleScalene, Square, rectangle };

            try
            {
                var filePath = $"{testDirFolder}/tbd.txt";

                var serializer = new XmlSerializer(typeof(List<Shape>), new Type[] { typeof(Shape), typeof(Circle), typeof(Triangle), typeof(Square), typeof(Rectangle) });
                var textWriter = new StreamWriter(filePath, true);

                serializer.Serialize(textWriter, shapesToSerialize);
                textWriter.Close();

                var reader = new StreamReader(filePath);
                var deserialized = serializer.Deserialize(reader);
                var deserializedShapes = (List<Shape>)deserialized;

                foreach(var deserializedShape in deserializedShapes)
                {
                    Console.WriteLine($"{deserializedShape.Name} has an area of {deserializedShape.Area} and a perimeter of {deserializedShape.Perimeter}.");
                }

                Console.WriteLine($"The number of shape objects are: {deserializedShapes.Count}");
                Console.WriteLine($"The number of square objects are: {deserializedShapes.FindAll(x => x.GetType() == typeof(Square)).Count}");
                Console.WriteLine($"The number of rectangle objects are: {deserializedShapes.FindAll(x => x.GetType() == typeof(Rectangle)).Count}");
                Console.WriteLine($"The number of triangle objects are: {deserializedShapes.FindAll(x => x.GetType() == typeof(Triangle)).Count}");
                Console.WriteLine($"The number of triangle objects are: {deserializedShapes.FindAll(x => x.GetType() == typeof(Square)).Count}");

            }
            catch (Exception e)
            {
                Console.Write(e);

            }
            if (File.Exists($"{testDirFolder}/tbd.txt"))
            {
                File.Delete($"{testDirFolder}/tbd.txt");
            }

            Directory.Delete($"{testDirFolder}");

            Console.WriteLine(Directory.Exists(testDirFolder));
            Console.Read();
        }
    }
}

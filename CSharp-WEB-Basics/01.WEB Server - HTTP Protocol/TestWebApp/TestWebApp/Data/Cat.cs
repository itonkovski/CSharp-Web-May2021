using System;
namespace TestWebApp.Data
{
    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Owner Owner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }

                name = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("Invalid input!");
                }

                age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            private set
            {
                if (value != "Male" && value != "Female")
                {

                    throw new Exception("Invalid input!");
                }

                gender = value;
            }
        }

        public abstract string ProduceSound();

        protected Animal(string name, int age, string gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.Append(ProduceSound());

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        // Main program, testing sorting capability.
        static void Main(string[] args)
        {
            //list of students
            List<Student> list = new List<Student>();
            list.Add(new Student("Adnan", "Mujkic", "adnan.mujkic@hotmail.com", "Sarajevo"));
            list.Add(new Student("Suad", "Kahrminaovic", "suad.kahrimanovic@hotmail.com", "Tuzla"));
            list.Add(new Student("Samir", "Silajdzic", "samir.silajdzic@hotmail.com", "Zenica"));
            list.Add(new Student("Hasan", "Jasarevic", "hasan.jasarevic", "Visegrad"));
            list.Sort();
            foreach (Student s in list)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }

    class Person
    {
        //strings 
        protected string name;
        private string LastName;
        public static int count = 0;
        public string lastName
        {
            get { return LastName; }
            set
            {
                //Checking if last name has more than 2 characters
                if (value.Length < 2) throw new Exception("Last name has to be more than two characters long");
                foreach (Char c in value)
                {
                    //Checking if last name has only letters
                    if (!Char.IsLetter(c))
                    {
                        //throws exception if condition above is not satisfied
                        throw new Exception("Last name can contain letters only");
                    }
                }
                LastName = value;
            }
        }
        
        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            count++;
        }

        public Person()
        {
            count++;
        }

        public string getPersonInfo() { return name + ", " + lastName; }

    };


    class Student : Person, IComparable
    {
        ~Student() //Empty destructor
        {

        }

        public string email { get; set; } //Added automatic property email

        private string _location; //Added property Location 

        public string Location
        {
            set
            {
                if (value == "SA" || value == "Sarajevo" || value == "SARAJEVO") this._location = "SA";
                else
                    if (value.ToLower() == "tuzla") this._location = "TZ";
                    else
                        this._location = "NA";
            }
            get
            {
                if (this._location == "SA") return "Sarajevo";
                if (this._location == "TZ") return "Tuzla";
                return "Other";
            }
        }

        public Student(string name, string lastName, string email)
            : base(name, lastName) //Student constructor that takes in 3 string arguments name, lastname and email by calling Parent class constructor
        {
            this.email = email;
        }

        public Student(string name, string lastName, string email, string location)
            : base(name,lastName) //Student that takes in 4 string arguments name, lastname, email and location
        {
            this.Location = location;
            this.email = email;
        }
        public bool setName(string input)
        {
            //Checking if name has more than 2 characters
            if (input.Length < 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;
            }
            if (input.All(Char.IsLetter))
            {
                //Checking if Name has only letters
                Console.WriteLine("Name can only have letters");
                return false;
            }
            if (Char.IsLower(input[0]))
            {
                //Checking if Name starts with uppercase letter
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }
            this.name = input;
            return true;
        }

        public Student() : base() // Parameter-less constructor for Student
        {

        }

        public string getStudentInfo() //getStudentInfo returns name, lastname, email and location
        {
            return getPersonInfo()+", "+email+", "+Location;
        }

        public int CompareTo(object other)
        {
            //Using CompareTo to sort Students by location
            return Location.CompareTo(((Student)other).Location);
        }

        public string ToString()
        {
            return getStudentInfo();
        }
    }
}

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
            List<Student> list = new List<Student>();
            list.Add(new Student("name1", "Last", "Email", "Sarajevo"));
            list.Add(new Student("Name2", "Last", "Email", "Tuzla"));
            list.Add(new Student("Name3", "Last", "Email", "Zenica"));
            list.Add(new Student("Name4", "Last", "Email", "bezze"));
            list.Sort();
            foreach (Student s in list)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }

    class Person
    {

        protected string name;
        private string LastName;
        public static int count = 0;
        public string lastName
        {
            get { return LastName; }
            set
            {
                if (value.Length < 2) throw new Exception("Last name has to be more than two characters long");
                foreach (Char c in value)
                {
                    if (!Char.IsLetter(c))
                    {
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
        ~Student() //destructor
        {

        }

        public string email { get; set; }

        private string _location;

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
            : base(name, lastName)
        {
            this.email = email;
        }

        public Student(string name, string lastName, string email, string location)
            : base(name,lastName)
        {
            this.Location = location;
            this.email = email;
        }
        public bool setName(string input)
        {
            if (input.Length < 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;
            }
            if (input.All(Char.IsLetter))
            {
                Console.WriteLine("Name can only have letters");
                return false;
            }
            if (Char.IsLower(input[0]))
            {
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }
            this.name = input;
            return true;
        }

        public Student() : base()
        {

        }

        public string getStudentInfo()
        {
            return getPersonInfo()+", "+email+", "+Location;
        }

        public int CompareTo(object other)
        {
            return Location.CompareTo(((Student)other).Location);
        }

        public string ToString()
        {
            return getStudentInfo();
        }
    }
}

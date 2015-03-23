namespace Student
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string eMail;
        private int course;
        private Universities university;
        private Faculties faculty;
        private Specialities speciality;

        public Student(string firstName, string middleName,
                       string lastName, string ssn, string address,
                       string mobilePhone, string email, int course,
                       Universities university, Faculties faculty,
                       Specialities speciality)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = address;
            this.MobilePhone = mobilePhone;
            this.EMail = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Speciality = speciality;
        }



        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                ValidateName(value);
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                ValidateName(value);
                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                ValidateName(value);
                this.lastName = value;
            }
        }

        public string SSN
        {
            get { return this.ssn; }
            private set
            {
                // Validation for SSN, which should be in format "AAA-GG-SSSS"
                string pattern = @"^\d{3}-?\d{2}-?\d{4}$";
                if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase) || value.Length != 11)
                {
                    throw new ArgumentException("Invalid SSN number. Number should be in format AAA-GG-SSSS.");
                }
                this.ssn = value;
            }
        }

        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            set
            {
                //Some validation for address;
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                //Some validation for correct mobile phone input;
                this.mobilePhone = value;
            }

        }

        public string EMail
        {
            get { return this.eMail; }
            set
            {
                //Validation for correct e-mail input
                this.eMail = value;
            }
        }

        public int Course
        {
            get { return this.course; }
            set
            {
                //Validate course input;
                this.course = value;
            }
        }

        public Universities University
        {
            get { return this.university; }
            private set { this.university = value; }
        }

        public Faculties Faculty
        {
            get { return this.faculty; }
            private set { this.faculty = value; }
        }

        public Specialities Speciality
        {
            get { return this.speciality; }
            private set { this.speciality = value; }
        }

        public static bool operator ==(Student first, Student second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !object.Equals(first, second);
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            if (student == null)
            {
                throw new ArgumentException("Object is not Student");
            }

            if (this.FirstName == student.FirstName
                && this.MiddleName == student.MiddleName
                && this.LastName == student.LastName
                && this.SSN == student.SSN
                && this.PermanentAddress == student.PermanentAddress
                && this.Course == student.Course
                && this.University == student.University
                && this.Faculty == student.Faculty
                && this.Speciality == student.Speciality) // Or just compare SSNs
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode()
                 ^ this.MiddleName.GetHashCode()
                 ^ this.LastName.GetHashCode()
                 ^ this.SSN.GetHashCode()
                 + this.Course;

            // return this.Course + 1; // For testing purposes;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat(" {0} {1} {2}, SSN: {3}{4}",
                this.FirstName, this.MiddleName, this.LastName, this.SSN, Environment.NewLine);
            result.AppendFormat("Contacts: adrress: {0}; phone: {1}; eMail: {2}{3}",
                this.PermanentAddress, this.MobilePhone, this.EMail, Environment.NewLine);
            result.AppendFormat("Academic information: University: {0}; Faculty: {1}; Speciality: {2}; Course: {3}{4}",
                this.University, this.Faculty, this.Speciality, this.Course, Environment.NewLine);

            return result.ToString();
        }

        public object Clone()
        {
            //var result = this.MemberwiseClone(); // The Student class contains no reference type fields,
            //// so a deep copy is not necessary in this instance. However the task description requires it;

            var result = new Student(this.FirstName, this.MiddleName, this.LastName,
                                     this.SSN, this.PermanentAddress, this.MobilePhone, this.EMail,
                                     this.Course, this.University, this.Faculty, this.speciality);
            return result;
        }

        public int CompareTo(Student other)
        {
            string thisName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string otherName = other.FirstName + " " + other.MiddleName + " " + other.LastName;

            if (thisName.CompareTo(otherName) != 0)
            {
                // Comparing by name in lexicographicall order
                if (thisName.CompareTo(otherName) < 0)
                {
                    return 1;
                }
                else
                {
                    return -1;

                }              
            }
            else
            {  
                // Comparing by SSN in increasing order
                if (this.SSN.CompareTo(other.SSN) < 0)
                {
                    return 1;
                }
                else if (this.SSN.CompareTo(other.SSN) > 0)
                {
                    return -1;
                }
                else
                {
                    return this.SSN.CompareTo(other.SSN);
                }  
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can not be null or empty string.");
            }
        }

    }
}

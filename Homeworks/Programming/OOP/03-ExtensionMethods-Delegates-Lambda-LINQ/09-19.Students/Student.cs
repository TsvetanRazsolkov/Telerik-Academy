namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string facultyNumber;
        private string phoneNumber;
        private string eMail;
        private List<int> marks;
        private int groupNumber;

        public Student(string firstName, string lastName, string facultyNumber, string phoneNumber,
                       string eMail, int groupNumber, params int[] marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
            this.PhoneNumber = phoneNumber;
            this.EMail = eMail;
            this.marks = new List<int>(marks);
            this.GroupNumber = groupNumber;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                ValidateName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                ValidateName(value);
                this.lastName = value;
            }
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                ValidateFacultyNumber(value);
                this.facultyNumber = value;
            }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                ValidatePhoneNumber(value);
                this.phoneNumber = value;
            }
        }

        public string EMail
        {
            get { return this.eMail; }
            set
            {
                ValidateEMail(value);
                this.eMail = value;
            }
        }

        public List<int> Marks
        {
            get { return new List<int>(this.marks); }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Group number cannot be negative number.");
                }
                this.groupNumber = value;
            }
        }

        public void AddMark(int mark)
        {
            ValidateMarks(mark);
            this.marks.Add(mark);
        }

        public void AddMarks(params int[] marks)
        {
            ValidateMarks(marks);
            this.marks.AddRange(marks);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} - FN-{2}, Group-{6}\nPhone: {3}, Email: {4}\nMarks: {5}", 
                this.FirstName, this.LastName, this.FacultyNumber, this.PhoneNumber,
                this.EMail, string.Join(", ", this.Marks), this.GroupNumber);
        }

        private void ValidateMarks(params int[] marks)
        {
            foreach (var mark in marks)
            {
                if (mark < 2 || mark > 6)
                {
                    throw new ArgumentException("Marks should be between 2 and 6.");
                }
            }
        }

        private void ValidateEMail(string eMail)
        {
            if (string.IsNullOrEmpty(eMail))
            {
                throw new ArgumentNullException("Email cannot be null");
            }

            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (!Regex.IsMatch(eMail, pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Invalid email address.");
            }
        }

        private void ValidatePhoneNumber(string phone)
        {
            if (phone[0] == '+')
            {
                if (phone.Length < 10)
                {
                    throw new ArgumentException("Phone must be in a format +359XXXXXXXXX"); 
                }
                for (int i = 1; i < phone.Length; i++)
                {
                    if (!char.IsDigit(phone[i]))
                    {
                        throw new ArgumentException("Phone must be in a format +359XXXXXXXXX");
                    }
                }
            }
            else if (phone[0] == '0')
            {
                if (phone.Length < 7)
                {
                    throw new ArgumentException("Phone must be in a format 0XXXXXXXXX");                     
                }
                for (int i = 1; i < phone.Length; i++)
                {
                    if (!char.IsDigit(phone[i]))
                    {
                        throw new ArgumentException("Phone must be in a format 0XXXXXXXXX");
                    }
                }
            }
            else
            {
                throw new ArgumentException("Phone must be in a format 0XXXXXX or +359XXXXXX");
            }
        }

        private void ValidateFacultyNumber(string str)
        {
            if (str.Length != 6)
            {
                throw new ArgumentException("Faculty number must be 6 digits long.");
            }
            foreach (var symbol in str)
            {
                if (!char.IsDigit(symbol))
                {
                    throw new ArgumentException("Faculty number should be a number.");
                }
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be empty string.");
            }
        }

        
    }
}

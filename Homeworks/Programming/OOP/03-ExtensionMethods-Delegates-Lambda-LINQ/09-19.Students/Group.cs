namespace Students
{
    using System;

    public class Group
    {
        private int groupNumber;
        private string departmentName;

        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
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

        public string DepartmentName
        {
            get { return this.departmentName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }
                this.departmentName = value;
            }
        }
    }
}

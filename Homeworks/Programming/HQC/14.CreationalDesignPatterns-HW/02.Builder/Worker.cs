namespace _02.Builder
{
    using System.Collections.Generic;
    using System.Text;

    public class Worker
    {
        private readonly string workerSpeciality;
        private Dictionary<string, string> skills = new Dictionary<string, string>();

        public Worker(string workerSpeciality)
        {
            this.workerSpeciality = workerSpeciality;
        }

        public Dictionary<string, string> Skills 
        {
            get
            {
                return this.skills;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.workerSpeciality);

            foreach (KeyValuePair<string, string> skill in this.skills)
            {
                sb.AppendFormat("{0} - {1}\n", skill.Key, skill.Value);
            }

            return sb.ToString();
        }
    }
}

namespace StudentSystem.ConsoleClient
{
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class ConsoleClient
    {
        public static void Main()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:2583/")
            };

            GetAllStudents(client);

            PostStudent(client);

            UpdateStudent(client);

            DeleteStudent(client);
        }

        private static void GetAllStudents(HttpClient client)
        {
            throw new NotImplementedException();
        }

        private static void PostStudent(HttpClient client)
        {
            throw new NotImplementedException();
        }

        private static void UpdateStudent(HttpClient client)
        {
            throw new NotImplementedException();
        }

        private static void DeleteStudent(HttpClient client)
        {
            throw new NotImplementedException();
        }
    }
}

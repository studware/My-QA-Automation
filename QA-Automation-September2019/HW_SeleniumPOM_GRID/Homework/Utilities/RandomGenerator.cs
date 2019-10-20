namespace Homework.Utilities
{
    using AutoFixture;
    using System;
    using System.Linq;
    using System.Net.Mail;

    public static class RandomGenerator
    {
        public static string GenerateMail()
        {
            return $"{Guid.NewGuid().ToString().Substring(0, 6)}@gmail.com";
        }

        /* or:
        public static EmailClass GenerateMail()
        {

            var fixture = new Fixture();
            fixture.Customize<EmailClass>(c => c
            .With(x => x.EmailAddresses,
            fixture.CreateMany<MailAddress>()
            .Select(x => x.Address)));

            return fixture.Create<EmailClass>();
        }
        */

        /* or:
        public static string GenerateMail()
        {
            return $"{Guid.NewGuid()}@gmail.com";
        } */

        /* or:
        public static string GenerateMail()
        {
            return Convert.ToBase64String(Guid.NewGuid()
                .ToByteArray()).Substring(0, 6) + "@gmail.com";
        } */

        /* or:
         // This is best! Requires using AutoFixture Nuget package
         var fixture = new Fixture();

         var url = fixture.Create<string>();
         var domain = fixture.Create<string>();
         var domainExtension = "com";  // or .net or .bg or .eu etc.
         var mail = $"{url}@{domain}.{domainExtension}";

         var number = fixture.Create<int>();
         var user = fixture.Create<RegistrationUser>();
         var test = "FirstName" + Guid.NewGuid();
         */

        // or:
        // This is not bad too
        //List<double> doubles = new List<double>();
        //for (int i = 0; i < 100000; i++)
        //{
        //    Random random = new Random();
        //    doubles.Add(random.NextDouble());
        //}
    }
}

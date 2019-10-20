namespace Homework
{
    public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
        {
            return new RegistrationUser
            {
                FirstName = "Naomi",
                LastName = "Watts",
                Date = "8",
                Month = "12",
                Year = "1961",
                Address = "Rakovski str.",
                City = "Sofia",
                State = "California",
                Password = "myPassword",
                PostCode = "34768",
                Phone = "348201789",
                Alias = "My home"
            };
        }
    }
}

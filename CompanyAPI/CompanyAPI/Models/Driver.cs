namespace testSFD.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<LicenseCategory> LicenseCategories { get; set; }


    }

    public enum LicenseCategory
    {
        A,
        B,
        C,
        D
    }
}
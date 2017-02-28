namespace SwashbuckleSample.Models
{
    /// <summary>
    /// User model for CRUD operations
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User's full name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        public string Email { get; set; }

    }
}
using _01.Interceptors.Entities.Contract;

namespace C01.BasicSaveWithTracking.Entities
{
    public class Book : ISoftDeletable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}

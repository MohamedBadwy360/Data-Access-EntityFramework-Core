using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        //public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }

    public class Individual : Participant
    {
        public string? University { get; set; }
        public int YearOfGraduation { get; set; }
        public bool IsIntern { get; set; }
    }

    public class Coporate : Participant
    {
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
    }
}

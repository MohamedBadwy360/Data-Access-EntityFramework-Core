﻿namespace Entities
{
    public class Office : Entity
    {
        public string? OfficeName { get; set; }
        public string? OfficeLocation { get; set; }

        public virtual Instructor? Instructor { get; set; }
    }
}

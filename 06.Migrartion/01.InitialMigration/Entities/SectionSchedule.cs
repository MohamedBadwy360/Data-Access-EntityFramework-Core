﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SectionSchedule
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int ScheduleId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        // If I use this navigation => best practice => I should explicit define foreign key in configuration
        //public Section Section { get; set; } = null!;
        //public Schedule Schedule { get; set; } = null!;
    }
}

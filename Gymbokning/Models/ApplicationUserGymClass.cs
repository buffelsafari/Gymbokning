﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Models
{
    public class ApplicationUserGymClass
    {
        public Guid ApplicationUserId { get; set; }
        public int GymClassId { get; set; }
    }
}

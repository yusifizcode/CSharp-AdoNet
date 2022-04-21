﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumReservation.Models
{
    internal class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourPrice { get; set; }
        public int Capacity { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace magazinestore
{
    public class Subscriber
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<int> MagazineIds { get; set; }
    }
}

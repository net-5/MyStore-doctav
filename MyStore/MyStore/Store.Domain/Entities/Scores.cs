﻿using System;
using System.Collections.Generic;

namespace Store.Domain.Entities
{
    public partial class Scores
    {
        public string Testid { get; set; }
        public string Studentid { get; set; }
        public byte Score { get; set; }

        public virtual Tests Test { get; set; }
    }
}

﻿namespace EasterEggHuntBackend.Models
{
    public class Riddle
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Hint { get; set; }
        public int ProgressCode { get; set; }
    }
}

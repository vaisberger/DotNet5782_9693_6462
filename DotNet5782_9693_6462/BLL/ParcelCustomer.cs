﻿namespace BO
{
    public class ParcelCustomer
    {
        public int Id { get; set; }
        public Weights weight { get; set; }
        public Priorities priority { get; set; }
        public Status situation { get; set; }
        public CustomerParcel customerParcel { get; set; }

    }
}
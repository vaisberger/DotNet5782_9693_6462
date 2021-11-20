namespace IBL.BO
{
    public class ParcelCustomer
    {
        public int Id { get; set; }
        public Weights weight { get; set; }
        public Priorities priority { get; set; }
        public Situation situation { get; set; }

        public CustomerParcel customerParcel { get; set; }

    }
}
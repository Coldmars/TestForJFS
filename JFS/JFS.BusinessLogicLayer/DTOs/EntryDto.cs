namespace JFS.BusinessLogicLayer.DTOs
{
    public class EntryDto
    {
        public int AccountId { get; set; }

        public DateTimeOffset Period { get; set; }

        public double InBalance { get; set; }

        public double Calculation { get; set; }
    }
}

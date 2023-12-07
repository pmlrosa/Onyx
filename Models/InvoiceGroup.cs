namespace Models
{
    public class InvoiceGroup
    {
        public DateTime IssueDate { get; set; }
        //public List<Invoice> Invoices { get; set; }

        public List<Observation> Invoices { get; set; }
    }
}
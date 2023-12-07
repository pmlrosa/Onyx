namespace Models
{
    public class TaskOneAandB
    {
        /// <summary>
        /// Function responsible to get the guests who have more than 1 observation
        /// </summary>
        /// <returns>An IEnumerable with the guest names</returns>
        public IEnumerable<string> GetRepeatedGuests()
        {
            var invoiceGroups = new List<InvoiceGroup>();

            IEnumerable<string> repeatedGuests = invoiceGroups
                .SelectMany(q => q.Invoices)
                .GroupBy(q => q.GuestName)
                .Select(q => new
                {
                    Name = q.Key,
                    Repetitions = q.Count()
                })
                .Where(q => q.Repetitions > 1)
                .Select(q => q.Name);

            return repeatedGuests;
        }

        /// <summary>
        /// Function responsible to get the a list of travel agent and their total of nigths booked 
        /// for a specific year
        /// </summary>
        /// <param name="year">Year to get the list</param>
        /// <returns>An IEnumerable with the travel agents info</returns>
        public IEnumerable<TravelAgentInfo> GetNumberOfNightsByTravelAgent(int year = 2015)
        {
            var invoiceGroups = new List<InvoiceGroup>();

            IEnumerable<TravelAgentInfo> travelAgents = invoiceGroups
                .Where(q => q.IssueDate.Year == year)
                .SelectMany(q => q.Invoices)
                .GroupBy(q => q.TravelAgent)
                .Select(q => new TravelAgentInfo()
                {
                    TravelAgent = q.Key,
                    TotalNumberOfNights = q.Sum(o => o.NumberOfNights)
                });

            return travelAgents;
        }

    }
}

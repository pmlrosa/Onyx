namespace Models
{
    public static class TaskOneCandD
    {
        /// <summary>
        /// Function responsible to get a raw query to load the travel agents that don't have
        /// any observations
        /// </summary>
        /// <returns>The select statement</returns>
        public static string GetQueryTravelAgentsWithNoObservations()
        {
            string sql = "select * " +
                "from TravelAgent " +
                "where TravelAgent.TravelAgent NOT IN (Select Distinct TravelAgent from Observation)";
            return sql;
        }

        /// <summary>
        /// Function responsible to get a raw query to load the travel agents that have
        /// more than 2 observations
        /// </summary>
        /// <returns>The select statement</returns>
        public static string GetQueryTravelAgentsWithMoreThanTwoObservations()
        {
            string sql = "select TravelAgent.TravelAgent, Count(Observation.TravelAgent) AS TotalObservations " +
                "from TravelAgent " +
                "inner join Observation on " +
                    "Observation.TravelAgent = TravelAgent.TravelAgent " +
                "group by TravelAgent.TravelAgent " +
                "having Count(Observation.TravelAgent) > 2 " +
                "order by TravelAgent.TravelAgent";
            return sql;
        }
    }
}

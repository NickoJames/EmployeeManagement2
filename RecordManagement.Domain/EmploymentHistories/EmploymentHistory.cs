using RecordManagement.Domain.Common.Models;
using RecordManagement.Domain.EmploymentHistories.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace RecordManagement.Domain.EmploymentHistories;
    public class EmploymentHistory : Entity<EmployementHistoriesId>
    {

 
        public string Employer { get; private set; }
        public string Position { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private EmploymentHistory(
            string employer,
            string position,
            DateTime startDate, 
            DateTime endDate
          

            ) :  base (EmployementHistoriesId.CreateUnique())
        {
            Employer = employer;
            Position = position;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static  EmploymentHistory Create(
           string employer,
           string position,
           DateTime startDate,
           DateTime endDate
           )
        {
            return new EmploymentHistory(
                employer,
                position,
                startDate,
                endDate
              
                );
        }







#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private EmploymentHistory() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}

namespace RecordManagement.Contracts.EmployeeRequest;

public record AddEmploymentHistoryRequest(


     string Employer,
     string Position,
     DateTime StartDate ,
     DateTime EndDate
);
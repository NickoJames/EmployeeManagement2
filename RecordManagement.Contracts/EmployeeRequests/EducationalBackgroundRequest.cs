namespace RecordManagement.Contracts.EmployeeRequests;

public record AddEducationalBackgroundRequest(
    int Id ,
    string Degree, 
    string School, 
    int YearGraduated
);
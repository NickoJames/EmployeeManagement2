using RecordManagement.Domain.Common.Models;
using RecordManagement.Domain.Educationalbackgrounds.ValueObjects;
using RecordManagement.Domain.Employees;
using RecordManagement.Domain.Employees.ValueObjects;


namespace RecordManagement.Domain.Educationalbackgrounds;
    public sealed class EducationalBackground : Entity<EducationalBackgroundId>
    {
      
        
     
        public string Degree { get; private set; }
        public string School { get; private set;}
        public int YearGraduated { get;private set; }

        private EducationalBackground(

            string degree, 
            string school, 
            int yearGraduated   
            

            ) : base (EducationalBackgroundId.CreateUnique())
        {

           
            Degree = degree;
            School = school;
            YearGraduated = yearGraduated;
          
        }

        public static EducationalBackground Create(
             
              
                string degree,
                string school,
                int yearGraduated

            ) 
        {
            return new EducationalBackground(
          
                degree, 
                school,
                yearGraduated );
        }



        

#pragma warning disable CS8618
    public EducationalBackground() { }
#pragma warning restore CS8618 



}

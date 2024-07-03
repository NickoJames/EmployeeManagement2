    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using RecordManagement.Application.Common.Interfaces;

    using RecordManagement.Application.Employee.Commands.CreateEmployee;

    using ApplicationRequest = RecordManagement.Application.DTOs.CreateEmployeeRequest;

    using RecordManagement.Application.Employee.Commands.EducationalBackground;
    using RecordManagement.Application.Employee.Commands.SkillsAndQualification;
    using RecordManagement.Application.Employee.Commands.Reference;
    using RecordManagement.Application.Employee.Queries;
    using RecordManagement.Contracts.EmployeeRequest;
    using MapsterMapper;
    using RecordManagement.Contracts.EmployeeRequests;
using RecordManagement.Application.Employee.Commands.UploadEmployee;



namespace RecordManagement.Api.Controllers
    {
        [ApiController]
        [Route("Auth")]
        public class EmployeeController : ControllerBase
        {
   

            private readonly IMediator _mediator;
            private readonly IEmployeeRepository1 _employeeRepository;
            private readonly IMapper _mapper;
                
        
            public EmployeeController(IMediator mediator, IEmployeeRepository1 employeeRepository , IMapper mapper)
            {
          
                _mediator = mediator;
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }
      
                 [HttpPost]
                [Route("Upload")]
                    [ProducesResponseType(StatusCodes.Status200OK)]
                    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
                    public async Task<IActionResult> UploadDataFile(IFormFile file)
                    {
                        var command = new UploadEmployeeCommand(file);

                        var result = await _mediator.Send(command);

                        return Ok(result);
                       
                    }



        [HttpPost("AddEmployee")]
            public async Task<IActionResult> CreateEmployee(CreateEmployeeRequest request)
            {
                try
                {
             var uniqueId = Guid.NewGuid();
              
                
                    var command = _mapper.Map<CreateEmployeeCommand>((uniqueId, request));
                    var mployee = await _mediator.Send(command);

                    return Ok(mployee);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }

            [HttpPost("AddEducationalBackground/{employeeId}")]
            public async Task<IActionResult> CreateEducationalBackground(Guid employeeId, AddEducationalBackgroundRequest request)
            {

                //   var command = new AddEducationalBackgroundCommand(employeeId,request);
                var command = _mapper.Map<AddEducationalBackgroundCommand>((employeeId, request));
                var educationalBackground = await _mediator.Send(command);
                return Ok(educationalBackground);

            }

            [HttpPost("AddEmploymentHistory/{employeeId}")]
            public async Task<IActionResult> CreateEmploymentHistory(Guid employeeId, AddEmploymentHistoryRequest request)
            {

                //  var command = new AddEmployementHistoryCommand(employeeId, request);

                var command = _mapper.Map<AddEmployementHistoryCommand>((employeeId,request));
                var educationalBackground = await _mediator.Send(command);
                return Ok(educationalBackground);

            }

            [HttpPost("AddSkills/{employeeId}")]
            public async Task<IActionResult> CreateSkills(Guid employeeId, AddSkillRequest request)
            {
                try
                {
                   
                    var command = _mapper.Map<AddSkillCommand>((employeeId, request));
                    var skills = await _mediator.Send(command);
                    return Ok(skills);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }

            [HttpPost("AddReference/{employeeId}")]
            public async Task<IActionResult> CreateReference(Guid employeeId, AddReference request)
            {
                try
                {
                    // var command = new AddReferenceCommand(employeeId, request);
                    var command = _mapper.Map<AddReferenceCommand>((employeeId , request));
                    var reference = await _mediator.Send(command);
                    return Ok(reference);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            [HttpGet("GetAllEmployees/{employeeId}")]
            public async Task<ActionResult> EmployeeListAsync(Guid employeeId)
            {
                try
                {

                    var employees = new EmployeeListQuery(employeeId);
                    var listEmployeeResult = await _mediator.Send(employees);
                    return Ok(listEmployeeResult);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }

            [HttpDelete("{employeeId}")]
            public async Task<IActionResult> DeleteEmployee(Guid employeeId)
            {
                try
                {
                    await _employeeRepository.DeleteEmployee(employeeId);
                    return Ok($"Employee with ID {employeeId} has been deleted successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }




        }
    }

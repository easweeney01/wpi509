namespace api;

//using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using model;

[ApiController]
[Route("api/v1/[controller]/[Action]")]

public class EmployeesController : ControllerBase
{
    /*

    */

    [HttpGet]
    public IActionResult GetAllEmployeeInfo()
    {
        return this.Ok(EmployeesModel.getAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeInfoById(int id) {
        return this.Ok(EmployeesModel.getById(id));
    }

    [HttpPost("{id}/{fName}/{lName}/{addr}/{phone}/{dName}/{officeNum}/{years}")]
    public IActionResult UpdateEmployeeInfo(int id, string fName, string lName, string addr, string phone, string dName, int officeNum, int years) {
        return this.Ok(EmployeesModel.updateEmployeeInfo(id, fName,lName,addr,phone,dName,officeNum,years));
    }

    [HttpPost("{fName}/{lName}/{addr}/{phone}/{dName}/{officeNum}/{years}")]
    public IActionResult CreateEmployeeInfo(string fName, string lName, string addr, string phone, string dName, int officeNum, int years) {
        return this.Ok(EmployeesModel.createEmployeeInfo(fName,lName,addr,phone,dName,officeNum,years));
    }

    [HttpDelete("{fName}/{lName}")]
    public IActionResult DeleteEmployee(string fName, string lName) {
        return this.Ok(EmployeesModel.deleteEmployee(fName,lName));
    }
}
namespace model;

using System.Data.Common;
using dal;
using System.Data;

public class Employee {
    public string? fName {get;set;}
    public string? lName {get;set;}
    public string? address {get;set;}
    public string? phone {get;set;}
    public string? dept {get;set;}
    public int? office {get;set;}
    public int? years {get;set;}

}
public class EmployeesModel {
    public static List<Employee> getAll()
    {
        var employees = new List<Employee>();
        var dt = EmployeesDal.getAll();

        foreach (DataRow r in dt.Rows) {
            employees.Add(new Employee
            {
              fName = r.Field<string>("fName"),
              lName = r.Field<string>("lName"), 
              address = r.Field<string>("addr"),
              phone = r.Field<string>("phone"), 
              dept = r.Field<string>("dName"),
              office = r.Field<int?>("officeNum") ?? 0,
              years = r.Field<int?>("years") ?? 0,
            });
        }

        return employees;
    }

    public static List<Employee> getById(int id) {
        var employees = new List<Employee>();
        var dt = EmployeesDal.getById(id);

        foreach (DataRow r in dt.Rows) {
            employees.Add(new Employee {
              fName = r.Field<string>("fName"),
              lName = r.Field<string>("lName"), 
              address = r.Field<string>("addr"),
              phone = r.Field<string>("phone"), 
              dept = r.Field<string>("dName"),
              office = r.Field<int?>("officeNum") ?? 0,
              years = r.Field<int?>("years") ?? 0,
            });
        }

        return employees;
    }

    public static int createEmployeeInfo(string fName, string lName, string addr, string phone, string dName, int officeNum, int years) {
        return EmployeesDal.createNew(fName,lName,addr,phone,dName,officeNum,years);
    }

    public static int deleteEmployee(string fName, string lName)
    {
        return EmployeesDal.deleteEmployee(fName,lName);
    }

    public static int updateEmployeeInfo(int id, string fName, string lName, string addr, string phone, string dName, int officeNum, int years)
    {
        return EmployeesDal.updateEmployee(id,fName,lName, addr, phone, dName, officeNum, years);
    }
}

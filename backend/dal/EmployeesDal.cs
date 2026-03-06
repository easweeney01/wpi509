using System.Data;

namespace dal;

using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.InteropServices;

public class EmployeesDal {
    private const string connectionString = "server=host.docker.internal;port=3333;uid=root;pwd=a;database=wpi";

    public static DataTable getAll() {
        var dt = new DataTable();
        using (var connection = new MySqlConnection(connectionString)) {
            connection.Open();

            using (var da = new MySqlDataAdapter(@"select * from Employees;", connection)) {
                da.Fill(dt);
            }
        }

        return dt;
    }

    public static DataTable getById(int id) {
        var dt = new DataTable();
        using (var connection = new MySqlConnection(connectionString)) {
            connection.Open();

            var query = "select * from Employees where id = @id;";

            var cmd = new MySqlCommand(query,connection);
            using (cmd) {
                cmd.Parameters.AddWithValue("@id",id);
        
                using (var da = new MySqlDataAdapter(cmd)) {
                    da.Fill(dt);
                }                
            }


        }

        return dt;
    }

    public static int updateEmployee(int id, string fName, string lName, string addr, string phone, string dName, int officeNum, int years) {
        using (var connection = new MySqlConnection(connectionString)) {
            connection.Open();

            var update = @"UPDATE Employees SET fName = @fName, lName = @lName, addr = @addr, phone = @phone, dName = @dName, officeNum = @officeNum, years = @years WHERE id = @id";

            var cmd = new MySqlCommand(update,connection);
            using (cmd) {
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@fName",fName);
                cmd.Parameters.AddWithValue("@lName",lName);
                cmd.Parameters.AddWithValue("@addr",addr);
                cmd.Parameters.AddWithValue("@phone",phone);
                cmd.Parameters.AddWithValue("@dName",dName);
                cmd.Parameters.AddWithValue("@officeNum",officeNum);
                cmd.Parameters.AddWithValue("@years",years);
        
                return cmd.ExecuteNonQuery();            
            }
            
        }
    }

    public static int createNew(string fName, string lName, string addr, string phone, string dName, int officeNum, int years) {
        var dt = new DataTable();
        using (var connection = new MySqlConnection(connectionString)) {
            connection.Open();

            var insert = @"insert into Employees (fName, lName, addr, phone, dName, officeNum, years) values (@fName,@lName,@addr,@phone,@dName,@officeNum,@years)";

            var cmd = new MySqlCommand(insert,connection);
            using (cmd) {
                cmd.Parameters.AddWithValue("@fName",fName);
                cmd.Parameters.AddWithValue("@lName",lName);
                cmd.Parameters.AddWithValue("@addr",addr);
                cmd.Parameters.AddWithValue("@phone",phone);
                cmd.Parameters.AddWithValue("@dName",dName);
                cmd.Parameters.AddWithValue("@officeNum",officeNum);
                cmd.Parameters.AddWithValue("@years",years);
        
                cmd.ExecuteNonQuery();            
            }
            return (int) cmd.LastInsertedId;
        }
    }

    public static int deleteEmployee(string fName, string lName) {
        using (var connection = new MySqlConnection(connectionString)) {
            connection.Open();

            var delete = @"delete from Employees where fName = @fName and lName = @lName limit 1";

            var cmd = new MySqlCommand(delete,connection);
            using (cmd) {
                cmd.Parameters.AddWithValue("@fName",fName);
                cmd.Parameters.AddWithValue("@lName",lName);
        
                return cmd.ExecuteNonQuery();
            }

        }
    }

    public static DataTable getById2(int id) {
        var dt = new DataTable();
        using (var connection = new MySqlConnection(connectionString)) {
            connection.Open();

            var query = "select * from Employees where id = @id;";

            var cmd = new MySqlCommand(query,connection);
            using (cmd) {
                cmd.Parameters.AddWithValue("@id",id);
        
                using (var da = new MySqlDataAdapter(cmd)) {
                    da.Fill(dt);
                }                
            }


        }

        return dt;
    }
}

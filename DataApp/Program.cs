using System.Data.SqlClient;
using System;
using System.Data; // use to get diconnected arcitecture sql objects
// Show();
// AddRecord();
// Show();
AddDisconnected();
ShowDisconnect();
void ShowDisconnect()
{
    string connectionString = "User ID = sa; password=examlyMssql@123; server = localhost; Database = PankajDb;trusted_connection = false; Persist Security Info = False; Encrypt = False";
    string cmdtext = "insert into Product values(@Id,@Name,@Price,@Stock)";
    SqlConnection connection = null;
    SqlDataAdapter adapter = null;
    DataSet ds = null;
    DataTable prodTable = null;
    try
    {
        ds = new DataSet();
        connection = new SqlConnection(connectionString);
        adapter = new SqlDataAdapter("Select * from Product",connection);
        adapter.Fill(ds,"Prods");
        prodTable = ds.Tables["Prods"];
        Console.WriteLine($"Rows = {prodTable.Rows.Count}");
        Console.WriteLine($"Columns = {prodTable.Columns.Count}");
        foreach(DataRow row in prodTable.Rows)
        {
            Console.WriteLine($"{row["Id"]} --- {row["Name"]} --- {row["Price"]} --- {row["Stock"]}");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
void AddDisconnected()
{
    string connectionString = "User ID = sa; password = examlyMssql@123; server = localhost; Database = PankajDb; trusted_connection = false; Persist Security Info = False; Encrypt = False";
    Console.WriteLine("Enter ID:");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Name:");
    string name = Console.ReadLine();
    Console.WriteLine("Enter Price:");
    int price = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter stock:");
    int stock = Convert.ToInt32(Console.ReadLine());
    SqlConnection connection = null;
    SqlDataAdapter adapter = null;
    DataSet ds = null;
    DataTable prodTable = null;
    try
    {
        ds = new DataSet();
        connection = new SqlConnection(connectionString);
        adapter = new SqlDataAdapter("Select * from Product",connection);
        adapter.Fill(ds,"Prods");
        prodTable = ds.Tables["Prods"];
        DataRow prodrow = prodTable.NewRow();
        prodrow["id"] = id;
        prodrow["name"] = name;
        prodrow["price"] = price;
        prodrow["stock"] = stock;
        prodTable.Rows.Add(prodrow);
        SqlCommandBuilder scb = new SqlCommandBuilder(adapter);
        Console.WriteLine(scb.GetInsertCommand().CommandText);
        adapter.Update(prodTable);
        Console.WriteLine("Row added");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
void AddRecord()
{
   string connectionString = "User ID = sa; password = examlyMssql@123; server = localhost; Database = PankajDb; trusted_connection = false; Persist Security Info = False; Encrypt = False";
   string cmdtext = "insert into Product values(@id,@name,@price,@stock)";
   Console.WriteLine("Enter ID:");
   int id = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("Enter Name:");
   string name = Console.ReadLine();
   Console.WriteLine("Enter Price:");
   int price = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter stock:");
    int stock = Convert.ToInt32(Console.ReadLine());
    SqlConnection con = null;
    SqlCommand command = null;

    try{
        con = new SqlConnection(connectionString);
        command.Parameters.AddWithValue("@id",id);
        command.Parameters.AddWithValue("@Name",name);
        command.Parameters.AddWithValue("@Price",price);
        command.Parameters.AddWithValue("@Stock",stock);
        con.Open();
        command.ExecuteNonQuery(); // to execute query on database
        Console.WriteLine("Record Added");

    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally{
        con.Close();
    }
}
void Show()
{
string connectionString = "User ID = sa; password = examlyMssql@123; server = localhost; Database =PankajDb; trusted_connection=false;Persist Security Info=False;Encrypt = False";
string cmdtext = "select * from product";
try
{
    SqlConnection con = new SqlConnection(connectionString);
    con.Open();
    Console.WriteLine("Connection Opened Successfully");
    SqlCommand command = new SqlCommand(cmdtext,con);
    SqlDataReader reader =command.ExecuteReader();
    while(reader.Read())
    {
        Console.WriteLine($"{reader["id"]} --- {reader["Name"]} ---{reader["Price"]} --- {reader["Stock"]}");
    }
    con.Close();
    reader.Close();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
}
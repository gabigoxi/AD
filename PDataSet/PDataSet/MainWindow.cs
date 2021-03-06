using System;
using Npgsql;
using System.Data;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected void OnExecuteActionActivated (object sender, System.EventArgs e)
	{
		
		string connectionString = "Server=localhost;Database=aula;User Id=aula;Password=clase" ;
		
		IDbConnection dbConnection = new NpgsqlConnection(connectionString);
		IDbCommand selectCommand = dbConnection.CreateCommand();
		selectCommand.CommandText = "select * from articulo where id=4";
		IDbDataAdapter dbDataAdapter = new NpgsqlDataAdapter();
		dbDataAdapter.SelectCommand = selectCommand;
		
		
		DataSet dataSet = new DataSet();
		
		dbDataAdapter.Fill (dataSet);
		
		Console.WriteLine("Tables.Count={0}", dataSet.Tables.Count);
		foreach (DataTable dataTable in dataSet.Tables)
			show (dataTable);
		
		DataRow dataRow = dataSet.Tables[0].Rows[0];
		dataRow["nombre"] = DateTime.Now.ToString ();
		Console.WriteLine("Tabla con los cambios");
		show (dataSet.Tables[0]);
		
		dbDataAdapter.Update (dataSet);
	}
	
	private void show (DataTable dataTable) {
		//foreach (DataColumn dataColumn in dataTable.Columns)
		//	Console.WriteLine("Column.Name={0}", dataColumn.ColumnName);
		
		foreach (DataRow dataRow in dataTable.Rows) {
			foreach (DataColumn dataColumn in dataTable.Columns)
				Console.Write("[{0}={1}]", dataColumn.ColumnName, dataRow[dataColumn]);
		Console.WriteLine ();
		
	}
		
}
	
}


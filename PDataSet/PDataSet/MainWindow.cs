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
		selectCommand.CommandText = "select * from articulo";
		IDbDataAdapter dbDataAdapter = new NpgsqlDataAdapter();
		dbDataAdapter.SelectCommand = selectCommand;
		
		
		DataSet dataSet = new DataSet();
		
		dbDataAdapter.Fill (dataSet);
		
		Console.WriteLine("Tables.Count={0}", dataSet.Tables.Count);
		
	}
}

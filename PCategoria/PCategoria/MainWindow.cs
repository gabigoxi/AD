using Gtk;
using Npgsql;
using System;
using System.Data;
using System.Collections.Generic; 

public partial class MainWindow: Gtk.Window
{	
		private ListStore listStore;		

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		fillComboBox();	

	}
		private void fillComboBox(){


		CellRenderer  cellRenderer2 = new CellRendererText();
		comboBox.PackStart(cellRenderer2, false); 
		comboBox.AddAttribute(cellRenderer2, "text", 1);


		listStore = new ListStore(typeof(string), typeof(string));
		comboBox.Model = listStore;

		
		String connectionString = "Server=localhost;Database=aula;User Id=aula;Password=clase";
		IDbConnection dbConnection = new NpgsqlConnection(connectionString);
		dbConnection.Open();

		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText="select * from categoria";
		IDataReader dataReader = dbCommand.ExecuteReader();


		while(dataReader.Read())
			listStore.AppendValues(dataReader["id"].ToString(), dataReader["nombre"].ToString());



		dataReader.Close();
		dbConnection.Close();

	}

}

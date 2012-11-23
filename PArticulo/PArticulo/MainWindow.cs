using System;
using Gtk;
using Npgsql;
using System.Data;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		///Movemos esto abajo para coger directamente la informacion del dataReader:
		/*treeView.AppendColumn("Identificador", new CellRendererText(), "text", 0);
		treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);
		treeView.AppendColumn("Precio", new CellRendererText(), "text", 2);
		treeView.AppendColumn("Categoría", new CellRendererText(), "text", 3);


		ListStore listStore = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
		treeView.Model = listStore;
		*/

		string connectionString = "Server=localhost;Database=aula;User Id=aula;Password=clase";
		IDbConnection dbConnection = new NpgsqlConnection(connectionString);
		dbConnection.Open();
		
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText="select * from articulo";
		
		IDataReader dataReader = dbCommand.ExecuteReader();
		
		/*Lo pegamos aqui*/
		//treeView.AppendColumn("Identificador", new CellRendererText(), "text", 0);
		//treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);
		//treeView.AppendColumn("Precio", new CellRendererText(), "text", 2);
		//treeView.AppendColumn("Categoría", new CellRendererText(), "text", 3);
		
		List<Type> types = new List<Type>();
		
		for (int index =0; index < dataReader.FieldCount; index++)
			treeView.AppendColumn(dataReader.GetName(index), new CellRendererText(), "text", index);
		types.Add (typeof(string));
		//types[index] = typeof(string);
		
		
		
		ListStore listStore = new ListStore(types.ToArray());
		
		//ListStore listStore = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
		treeView.Model = listStore;
		///////////////////////////////////////////////
		
		while(dataReader.Read())
			listStore.AppendValues(dataReader[0].ToString(), dataReader[1].ToString(),
			                       	dataReader[2].ToString(), dataReader[3].ToString());
		//Funciona igual si  pones dataReader["id"].ToString(), etc, etc.
		
		dataReader.Close();
		dbConnection.Close();
		
		//listStore.AppendValues("1", "Nombre 1", "1.5", "1");
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
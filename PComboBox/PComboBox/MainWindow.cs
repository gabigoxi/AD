using System;
using Gtk;

//public delegate int MyFunction (int a, int b);

public partial class MainWindow: Gtk.Window
{	
	private ListStore listStore;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
//		MyFunction f;
//		
//		MyFunction[] funtions = new MyFunction[]{suma, resta, multiplica};
//		
//		int random = new Random().Next (3);
//		f = funtions [ random ];
//		
//		Console.WriteLine ("f=(0)", f(5,3));
		
		//comboBox.Active = 0;
		
		CellRenderer cellRenderer = new CellRendererText();
		ComboBox.PackStart(cellRenderer, false); //expand=false
		ComboBox.AddAttribute (cellRenderer, "text", 1);
		
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		
	ComboBox.Model = listStore;
		
		listStore.AppendValues ("1", "Uno");
		listStore.AppendValues ("2", "Dos");
		
//		ComboBox.Changed += delegate {
//			Console.WriteLine ("comboBox.Changed value=(0)",value);
//			TreeIter treeIter;
//			if (comboBox.GetActiveIter (out treeIter) ) { //item selecccionado
//				object value = listStore.GetValue (treeIter, 0);
//			Console.WriteLine ("comboBox.Changed value={0}", value);
//				
//			}
//		};
		
		ComboBox.Changed += comboBoxChanged;
		
			
	}
	
//	private int suma (int a, int b) {
//		return a + b;
//		    
//		    }
//	
//	private int resta (int a, int b) {
//		return a - b;
//		    
//		    }
//	
//	private int multiplica (int a, int b) {
//		return a * b;
//		    
//		    }
	
	private void comboBoxChanged(object obj, EventArgs args){
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

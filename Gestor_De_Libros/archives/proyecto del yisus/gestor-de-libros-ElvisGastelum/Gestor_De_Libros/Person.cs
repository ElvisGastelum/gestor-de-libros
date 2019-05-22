using System;
using System.IO;

namespace Gestor_De_Libros
{
	/// <summary>
	/// Description of Person.
	/// </summary>
	public class Person
	{
		public Person()
		{
		}
		
		
		public void Register(string path, string name, string lastName, string age, string ocupation, string phone, string mail){
			Utilities Function = new Utilities();
			
			string Ruta= path + @"\" + name + @" " + lastName + @".txt";
			
			
			
			try{
				Function.OverwriteInFile(name,Ruta);
				Function.WriteLineInFile(lastName,Ruta);
				Function.WriteLineInFile(age,Ruta);
				Function.WriteLineInFile(ocupation,Ruta);
				Function.WriteLineInFile(phone,Ruta);
				Function.WriteInFile(mail,Ruta);
				
				
				
				
			}catch(Exception e){
				
				Console.WriteLine("Error" + e.Message);
				
			}
		
			
		}// End of Register()
		
		
		
		
	} // End of Person
}

using System;
using System.IO;

namespace Gestor_De_Libros
{
	/// <summary>
	/// Description of Utilities.
	/// </summary>
	public class Utilities
	{
		Program program = new Program();
		string pathDataProject = null;
		
		public Utilities()
		{
			pathDataProject = program.PathDataProject;
		}// End of Utilities()
		
		public void Login(){
			string username = null,password = null, userIn = null, passIn = null;
			string pathLogin = pathDataProject + @"\Users\Users.txt";
			while(true){
				Console.Clear();
				
				using (StreamReader ReadLogin = new StreamReader(File.Open(pathLogin, FileMode.Open))) {
				username = ReadLogin.ReadLine();
				password = ReadLogin.ReadLine();
				ReadLogin.Close();
				}
				Console.Write("Nombre: ");
				userIn = Console.ReadLine();
				Console.Write("Contraseña: ");
				passIn = Console.ReadLine();
				if (userIn != username){
					Console.WriteLine("Nombre de usuario incorrecto");
				} 
				if (passIn != password){
					Console.WriteLine("Contraseña incorrecta");
				}
				if (username == userIn && password == passIn) {
					Console.Write("LOGIN EXITOSO"); 
					Console.ReadKey();
					break;
				}
				Console.Write("LOGIN FALLIDO"); 
				Console.ReadKey(true);
			}	
		}// End of Login()
		public void CreateDirectory(string path){
			try 
	        {
	            // Determine whether the directory exists.
	            if (Directory.Exists(path)) 
	            {
	                return;
	            }
	
	            // Try to create the directory.
	            DirectoryInfo di = Directory.CreateDirectory(path);
	

	        } 
	        catch (Exception e) 
	        {
	            Console.WriteLine("The process failed: {0}", e.ToString());
	        } 
		}
		public void DeleteDirectory(string path){
			Directory.Delete(path, true);
		}// End of CreateDirectory()
		public void WriteLineInFile(string message , string path){
			// Create a file to write to.
			using (StreamWriter sw = new StreamWriter(path, true)){
		    	sw.WriteLine(message);
		    }
		}// End of WriteInFile()
		
		public void WriteInFile(string message , string path){
			// Create a file to write to.
			using (StreamWriter sw = new StreamWriter(path, true)){
		    	sw.Write(message);
		    }
		}// End of WriteInFile()
		
		public void OverwriteInFile(string message , string path){
			// Create a file to write to.
			using (StreamWriter sw = new StreamWriter(path)){
		        sw.WriteLine(message);
		    }
		    
		}// End of OverwriteInFile()
		
		public string ReadFile(string path){
			string lines = null;
			using (StreamReader sr = File.OpenText(path)){
				lines = sr.ReadToEnd();
		    }
			return lines;
		}
		

		public void ListOfBooks(string path){
			DirectoryInfo dir = new DirectoryInfo(path + @"\");
			int i=0;
     	 	foreach (var fi in dir.GetFiles()){
        		i++;
        		Console.WriteLine(i+".- "+fi.Name);
      		}
	  	} // End of ListOfBooks()
    
    
    
	} // End of Utilies
}

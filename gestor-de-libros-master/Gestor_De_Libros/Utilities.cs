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
		}
		
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
		}
		public void Register(){
			
		}
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
		}
		
		public void ListOfBooks(){
			DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Yisus\Desktop\gestor-de-libros-master\Gestor_De_Libros\archives\Libros");
			int i=0;
            foreach (var fi in dir.GetFiles())
            {
            	i++;
                Console.WriteLine(i+".- "+fi.Name);
            }
		}
	}
}

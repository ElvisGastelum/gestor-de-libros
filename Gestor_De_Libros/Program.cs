using System;
using System.IO;
using System.Security.AccessControl;

namespace Gestor_De_Libros
{
	
	class Program
	{
		readonly public string pathDataProject = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\dataProject";

		public string PathDataProject {
			get {
				return pathDataProject;
			}
			
		}
		public static void Main(string[] args)
		{
			Utilities Function = new Utilities();
			Console.Title = "Login";
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();
			int op=0;
			
			CreateDataForDefault();
			
			
			
			Function.Login();
			Console.Clear();
			
			
			
			
			while(true){
				Console.Title= "Menú";
				Console.Clear();
				Console.WriteLine("Bienvenido\n");
				Console.WriteLine("¿Qué desea realizar?");
				Console.WriteLine("1. Buscar Libro");
				Console.WriteLine("2. Registrar prestamo");
				Console.WriteLine("3. Consultar prestamos");
				Console.WriteLine("4. Salir\n");
				Console.Write("Opción: ");
				
				try{
					op = Convert.ToInt32(Console.ReadLine());
					
				}catch(Exception e){
					Console.WriteLine(e.Message);
				}
				
				switch(op){
						
					case 1:
						Console.Clear();
						Console.Title = "Biblioteca";
						Console.WriteLine("A continuación, se muestran los libros disponibles:\n");
						Function.ListOfBooks();
						
						Console.WriteLine("\n¿Qué libro desea elegir?");
						Console.Write("\nRespuesta: ");
						
						int BookSelected = 0;
						try{
						BookSelected = Convert.ToInt32(Console.ReadLine());
						}catch(Exception e){
							Console.WriteLine(e.Message);
						}
						
							if(BookSelected == 1){
							Console.Clear();
							string Ruta= File.ReadAllText(@"C:\Users\Yisus\Desktop\gestor-de-libros-master\Gestor_De_Libros\archives\Libros\Caperucita Roja.txt");
							Console.WriteLine(Ruta);
							Console.ReadKey();
							}
						
						if(BookSelected == 2){
							Console.Clear();
							string Ruta= File.ReadAllText(@"C:\Users\Yisus\Desktop\gestor-de-libros-master\Gestor_De_Libros\archives\Libros\La Biblia de CSharp - Anaya.txt");
							Console.WriteLine(Ruta);
							Console.ReadKey();
							}
						
							if(BookSelected == 3){
							Console.Clear();
							string Ruta = File.ReadAllText(@"C:\Users\Yisus\Desktop\gestor-de-libros-master\Gestor_De_Libros\archives\Libros\Libros\Los 3 Cochinitos.txt");
							Console.WriteLine(Ruta);
							Console.ReadKey();
						}else{
							continue;
						}
		
						break;
						
						
						
					case 2:
						
						Console.WriteLine("");
						int op2 = 0;
						try{
						op2 = Convert.ToInt32(Console.ReadLine());
						}catch(Exception e){
							Console.WriteLine(e.Message);
						}
						break;
						
					case 4:
						DateTime now = DateTime.Now;
						Console.WriteLine(now);
						Console.ReadKey(true);
						Environment.Exit(0);
						break;
			
			
				}
			}
		} // End of Main()
		
		static void CreateDataForDefault(){
			Program program = new Program();
			Utilities Function = new Utilities();
			string pathUsers = program.PathDataProject + @"\Users";
			string pathUsersLog = pathUsers + @"\Users.txt";
			string pathRegistry = program.PathDataProject + @"\Registry";
			string pathBooks = pathRegistry + @"\Books";
			
			if (!Directory.Exists(pathUsers)) {
				Function.CreateDirectory(pathUsers);
				
				if (!File.Exists(pathUsersLog))
		        {
					
					Function.WriteInFile("admin", pathUsersLog);
		            Function.WriteInFile("admin", pathUsersLog);
		        }
		
		        
			}else{
				if (!File.Exists(pathUsersLog))
		        {
					Function.WriteInFile("admin", pathUsersLog);
		            Function.WriteInFile("admin", pathUsersLog);
		        }
			}
			
			if (!Directory.Exists(pathRegistry)) {
				Function.CreateDirectory(program.PathDataProject +  @"\Registry\Books");
				
				CreateBook(program.PathDataProject +  @"\Registry\Books\", "1. La Biblia de CSharp - Anaya");
			}
			
		} // End of CreateDataForDefault()
		
		public static void CreateBook( string pathBook, string name){
			Utilities Function = new Utilities();
			string pathComplete = pathBook + name + @".txt";
			if (!File.Exists(pathComplete))
			{
				// Create a file to write to.
				Function.WriteInFile(name, pathComplete);
			}
		}// End of CreateBook()
		
	}// End of Program
}
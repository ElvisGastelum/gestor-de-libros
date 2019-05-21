using System;
using System.IO;


namespace Gestor_De_Libros
{
	
	class Program
	{
		readonly string pathDataProject = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\dataProject";
		string pathUsers = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\dataProject\Users";
		string pathBooks = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\dataProject\Registry\Books";
		string pathlogs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\dataProject\Logs";

		public string Pathlogs {
			get {
				return pathlogs;
			}
		}
		public string PathDataProject {
			get {
				return pathDataProject;
			}
			
		}
		public string PathUsers {
			get {
				return pathUsers;
			}
		}
		public string PathBooks {
			get {
				return pathBooks;
			}
		}

		public static void Main(string[] args)
		{
			Utilities Function = new Utilities();
			Program program = new Program();
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
				Console.WriteLine("1. Buscar Libro en estanteria");
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
							string Ruta= Function.ReadFile(string.Format(@"{0}\bookshelves\Caperucita Roja.txt", program.PathBooks));
							detallesDelLibro(Ruta);
							Console.ReadKey();
							}
						
						if(BookSelected == 2){
							Console.Clear();
							string Ruta = Function.ReadFile(string.Format(@"{0}\bookshelves\La Biblia de CSharp - Anaya.txt", program.PathBooks));
							
							detallesDelLibro(Ruta);
							Console.ReadKey();
							}
						
							if(BookSelected == 3){
							Console.Clear();
							string Ruta = Function.ReadFile(string.Format(@"{0}\bookshelves\Los Tres Cochinitos.txt", program.PathBooks));
							detallesDelLibro(Ruta);
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
						string logDate = now.ToString();
			
						Function.WriteLineInFile("Salida >> Log: " + logDate + " >> User: admin", program.Pathlogs + @"\logs.txt");
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Opcion no valida! :(");
						Console.ReadKey();
						break;
			
				}
			}
		} // End of Main()
		
		static void CreateDataForDefault(){
			Program program = new Program();
			Utilities Function = new Utilities();
			string pathUsers = program.PathDataProject + @"\Users";
			string pathUsersLog = pathUsers + @"\Users.txt";
			string pathBooks = program.PathDataProject + @"\Registry\Books";
			DateTime now = DateTime.Now;
			string logDate = now.ToString();
			
			
			
			if (!Directory.Exists(program.Pathlogs)) {
				Function.CreateDirectory(program.Pathlogs);
			}
			Function.WriteLineInFile("Entrada >> Log: " + logDate + " >> User: admin", program.Pathlogs + @"\logs.txt");
			if (!Directory.Exists(pathUsers)) {
				Function.CreateDirectory(pathUsers);
				
				if (!File.Exists(pathUsersLog))
		        {
					
					Function.WriteLineInFile("admin", pathUsersLog);
		            Function.WriteLineInFile("admin", pathUsersLog);
		        }
		
		        
			}else{
				if (!File.Exists(pathUsersLog))
		        {
					Function.WriteLineInFile("admin", pathUsersLog);
		            Function.WriteLineInFile("admin", pathUsersLog);
		        }
			}
			
			if (!Directory.Exists(program.PathDataProject + @"\Registry")) {
				string pathBooksIn = program.PathBooks +  @"\bookshelves\";
				Function.CreateDirectory(program.PathBooks  +  @"\bookshelves");
				
				CreateBook(pathBooksIn, "La Biblia de CSharp - Anaya", "Jason Jeff Brian Beres", "2003", "978-844-151-484-3", "861");
				CreateBook(pathBooksIn, "Caperucita Roja", "Wilhelm i Jacob Grimm", "1697, 1812", "978-84-7864-851-1", "24");
				CreateBook(pathBooksIn, "Los Tres Cochinitos", "Roberto Bravo Meritxell Marti", "1900", "978-84-7864-765-1", "24");
				
			}
			
		} // End of CreateDataForDefault()
		
		public static void CreateBook( string pathBook, string name, string autor, string AImpresion, string isbn, string NumPag){
			Utilities Function = new Utilities();
			string pathComplete = pathBook + name + @".txt";
			if (!File.Exists(pathComplete))
			{
				// Create a file to write to.
				Function.WriteLineInFile(name, pathComplete);
				Function.WriteLineInFile(autor, pathComplete);
				Function.WriteLineInFile(AImpresion, pathComplete);
				Function.WriteLineInFile(isbn, pathComplete);
				Function.WriteInFile(NumPag, pathComplete);
			}
		}// End of CreateBook()
		
		static void detallesDelLibro(string Ruta){
			string[] _path = Ruta.Split('\n');
			int i = 0;
			string[] option = {
				"Nombre del libro: ",
				"Autor: ",
				"Año de impresión: ",
				"ISBN: ",
				"No. Páginas: "
			};
			foreach (string line in _path) {
				Console.WriteLine(option[i] + line);
				i++;
			}
		}// End of detallesDelLibro()
		
	}// End of Program
}
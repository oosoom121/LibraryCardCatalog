using System;
using System.IO;

namespace CardCatalog
{
	class Program
	{
		static void Main(string[] args)
		{
			LibraryCardCatalog catalog = new LibraryCardCatalog();
			char selection = '\0';

			string fullFilePath = ManageTheFile();

			while (selection != '3')
			{
				// Clears the screen and creates the menu.  Prompts for a selection and calls 
				// the appropriate method
				Console.Clear();
				Console.Write("\n\n\t\t\t\tCard Catalog\n\n");
				Console.Write("\n\n\t\t\t\t1. List all books ");
				Console.Write("\n\n\t\t\t\t2. Add a book ");
				Console.Write("\n\n\t\t\t\t3. Save and Exit \n");
				Console.Write("\n\n\t\t\t\tPease enter a selection: ");

				selection = Console.ReadKey().KeyChar;

				if (selection == '1')
				{
					// call list all books method
					catalog.listBooks();
				}
				else if (selection == '2')
				{
					// call add a book method
					catalog.addBook(fullFilePath);
				}
				else if (selection == '3')
				{
					// Save and exit
					// Create write to file script.
					Environment.Exit(0);
				}
				else
				{
					Console.Write("\n\t\t\t\tInvalid Selection");
					Console.ReadLine();
				}
			}

			Console.ReadLine();
		}

		static string ManageTheFile()
		{
			string filePath = @"C:\Card Catalog\";

			// Prompt for a file name and join it with the path.
			Console.Write("\n\n\t\t\t\tEnter your card catalogs filename: ");
			string cardCatalogName = filePath + Console.ReadLine() + ".txt";

			// This try catch block is protecting against someone imputting a file name that can't be recognized
			// For instance, since the path is already formatted, if the user imputs the path along with the
			// file name they'll receive a message and the program will end.  
			try
			{
				// Check to see if the file and path exist.  If not, prompt the user to create.
				if (!File.Exists(cardCatalogName))
				{
					Console.Write("\t\t\t\tFile does not exist. Would you like to create it? (Y or N)");
					char create = Convert.ToChar(Console.ReadLine());

					if (create.ToString().ToUpper() == "N")
					{
						Environment.Exit(0);  // Exit program.  We may want to change this to accommodate multiple book files.
					}
					else
					{
						Directory.CreateDirectory(filePath);

						File.Create(cardCatalogName).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				Console.Write("\n\n\t\t\t\t\tFile name not valid! Enter only a file name.\n\t\t\t\t\t" + ex.Message 
					+ "\n\n\t\t\t\tDo you want to try again? Enter 'Y' or any other key to Exit");
				if (((ConsoleKeyInfo)Console.ReadKey()).Key == ConsoleKey.Y)
				{
					Console.Clear();
					ManageTheFile();
				}
				Environment.Exit(0);
			}
			return cardCatalogName;
		}
	}

	public class LibraryCardCatalog
	{
		public void listBooks()
		{
			Console.Clear();
			Console.Write("\n\n\t\t\t\tYou're in the List All Books method");
			Console.ReadLine();
		}

		public void addBook(string cardFilePath)
		{
			Console.Clear();
			Console.Write("\n\n\t\t\t\tEnter a book title: ");
			string bookName = Console.ReadLine();
			Console.Write("\n\n\t\t\t\tEnter a book author: ");
			string authorName = Console.ReadLine();

			try
			{
				//Pass the filepath and filename to the StreamWriter Constructor
				StreamWriter sw = new StreamWriter(cardFilePath);

				//Write a line of text
				sw.WriteLine(bookName + "; " + authorName);

				//Close the file
				sw.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}

			Console.ReadLine();
		}
	}
}

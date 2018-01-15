using System;

namespace LibraryCardCatalog
{
	class Program
	{
		static void Main(string[] args)
		{
            //this is a test from Khristine's mac..
			CardCatalog Catalog = new CardCatalog();
			char selection = '\0';

			Catalog.ManageTheFile();

			while ((selection != '3') || (selection != '4'))
			{
				// Clears the screen and creates the menu.  Prompts for a selection and calls 
				// the appropriate method
				Console.Clear();
				Console.Write("\n\n\t\t\t\tCard Catalog\n\n");
				Console.Write("\n\n\t\t\t\t1. List all books ");
				Console.Write("\n\n\t\t\t\t2. Add a book ");
				Console.Write("\n\n\t\t\t\t3. Save and Exit");
				Console.Write("\n\n\t\t\t\t4. Exit without saving \n");
				Console.Write("\n\n\t\t\t\tPease enter a selection: ");

				selection = Console.ReadKey().KeyChar;

				if (selection == '1')
				{
					// call list all books method
					Catalog.listBooks();
				}
				else if (selection == '2')
				{
					// call add a book method
					Catalog.addBook();
				}
				else if (selection == '3')
				{
					// call Save and exit method
					Catalog.SaveAndExit();
				}
				else if (selection == '4')
				{
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


	}
}

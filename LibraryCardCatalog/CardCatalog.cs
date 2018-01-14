using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LibraryCardCatalog
{
	public class CardCatalog
	{
		private string _fileName;

		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}
		static List<Book> bookList = new List<Book>();
		public CardCatalog()
		{
		}

		public CardCatalog(string filename)
		{
		}

		public string ManageTheFile()
		{
			string filePath = @"C:\Card Catalog\";

			// Prompt for a file name and join it with the path.
			Console.Write("\n\n\t\t\t\tEnter your card catalogs filename: ");
			FileName = filePath + Console.ReadLine() + ".xml";

			return FileName;
		}

		public void listBooks()
		{
			Book LibraryBook = new Book();
			XmlSerializer readBooksFile = new XmlSerializer(typeof(List<Book>));

			Console.Clear();
			using (FileStream readBookStream = File.OpenRead(FileName))
			{
				bookList = (List<Book>)readBooksFile.Deserialize(readBookStream);
			}

			foreach (Book allBooks in bookList)
			{
				Console.WriteLine("\n\n" + allBooks.ToString());
			}

			Console.ReadLine();
		}

		public void addBook()
		{
			XmlSerializer booksFile = new XmlSerializer(typeof(Book));
			
			Console.Clear();
			Console.Write("\n\n\t\t\t\tEnter a book title: ");
			string bookName = Console.ReadLine();
			Console.Write("\n\n\t\t\t\tEnter the book's author: ");
			string authorName = Console.ReadLine();
			Console.Write("\n\n\t\t\t\tEnter the book's publisher: ");
			string publisher = Console.ReadLine();
			Console.Write("\n\n\t\t\t\tEnter the book's ISBN number: ");
			string isbn = Console.ReadLine();

			Book LibraryBook = new Book(bookName, authorName, publisher, isbn);

			try
			{				
				bookList.Add(LibraryBook);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
		}
		public void SaveAndExit()
		{
			if (!File.Exists(FileName))
			{
				using (Stream bookStream = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.None))
				{
					XmlSerializer serialBooks = new XmlSerializer(typeof(List<Book>));
					serialBooks.Serialize(bookStream, bookList);
				}
			}
			else
			{
				using (FileStream bookStream = File.OpenWrite(FileName))
				{
					XmlSerializer serialBooks = new XmlSerializer(typeof(List<Book>));
					serialBooks.Serialize(bookStream, bookList);
				}
			}
			
			Environment.Exit(0);
		}
	}
}

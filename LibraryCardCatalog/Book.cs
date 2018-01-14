using System;
using System.Runtime.Serialization;

namespace LibraryCardCatalog
{
	[Serializable()]
	public class Book : ISerializable
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public string Publisher { get; set; }
		public string ISBN { get; set; }

		public Book()
		{
		}

		public Book(string title, string author, string publisher, string isbn)
		{
			Title = title;
			Author = author;
			Publisher = publisher;
			ISBN = isbn;
		}
		public override string ToString()  // Display to the screen 
		{
			return string.Format("\t\tBook Title: {0}, \n\t\tAuthor:  {1}, \n\t\tPublisher: {2}, \n\t\tISBN number: {3}", Title, Author, Publisher, ISBN);

		}
		public void GetObjectData(SerializationInfo bookData, StreamingContext context)
		{
			bookData.AddValue("Title", Title);
			bookData.AddValue("Author", Author);
			bookData.AddValue("Publisher", Publisher);
			bookData.AddValue("ISBN", ISBN);
		}

		public Book(SerializationInfo bookData, StreamingContext context)
		{
			Title = (string)bookData.GetValue("Title", typeof(string));
			Author = (string)bookData.GetValue("Author", typeof(string));
			Publisher = (string)bookData.GetValue("Publisher", typeof(string));
			ISBN = (string)bookData.GetValue("ISBN", typeof(string));
		}
	}
}

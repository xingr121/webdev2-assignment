using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));

            log.Info("Application started.");

            List<Book> books = ReadBooksFromCsv("books.csv");

            // Read book information from the user
            while (true)
            {
                Console.Write("Name: ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    break; // End reading process
                }

                Console.Write("Pages: ");
                int pages;
                if (!int.TryParse(Console.ReadLine(), out pages))
                {
                    Console.WriteLine("Invalid input for pages. Please enter a valid integer.");
                    continue;
                }

                Console.Write("Publication year: ");
                int publicationYear;
                if (!int.TryParse(Console.ReadLine(), out publicationYear))
                {
                    Console.WriteLine("Invalid input for publication year. Please enter a valid integer.");
                    continue;
                }

                // Create new Book object and add it to the list
                books.Add(new Book(title, pages, publicationYear));
            }

            // Ask the user what information to print
            Console.Write("What information will be printed? ");
            string input = Console.ReadLine();

            if (input.Equals("everything", StringComparison.OrdinalIgnoreCase))
            {
                // Print all book details
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}, {book.Pages} pages, {book.PublicationYear}");
                }
            }
            else if (input.Equals("title", StringComparison.OrdinalIgnoreCase))
            {
                // Print only book titles
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {
                // Print nothing if input is neither "everything" nor "title"
                Console.WriteLine("No information to print.");
            }

            WriteBooksToCsv(books, "books.csv");
        }

        static void WriteBooksToCsv(List<Book> books, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var book in books)
                    {
                        writer.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
                    }
                }

           
                log.Info($"Books successfully written to CSV file: {filePath}");
            }
            catch (Exception ex)
            {
              
                log.Error($"Error writing books to CSV file: {ex.Message}");
            }
        }

        static List<Book> ReadBooksFromCsv(string filePath)
        {
            List<Book> books = new List<Book>();
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 3 && int.TryParse(parts[1], out int pages) && int.TryParse(parts[2], out int publicationYear))
                            {
                                books.Add(new Book(parts[0], pages, publicationYear));
                            }
                        }
                    }
                }

               
                log.Info($"Books successfully read from CSV file: {filePath}");
            }
            catch (Exception ex)
            {
               
                log.Error($"Error reading books from CSV file: {ex.Message}");
            }

            return books;
        }
    }

    
}

using lab2WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2WEB.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloThay(string university)
        {
            return "Hé Lô Thầy -Hutech:"+university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 và CSS3 the complete");
            books.Add("sách HTML5 và CSS Responsive web");
            books.Add("chuyên gia Professional ASP.NET MVC5");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 và CSS the complete","Author Name Book 1", "/Content/Images/image2cover.png"));
            books.Add(new Book(2, "HTML &CSS", "Author Name 2", "/Content/Images/image3cover.png"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name 3", "/Content/Images/image1cover.jpg"));

            return View(books);
        }
        
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/image2cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/images/image3cover.png")); //Khai baos sahcs
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/images/image1cover.jpg"));
            Book book = new Book();

            foreach (Book b in books) //duyệt từng thằng trong list sách được khai báo
            {
                if (b.Id == id) // nếu thằng sách này có Id= id(id được truyền vào)
                {
                    book = b; // gán thằng book này = biến b (book = sách mới || b = book trong list sách
                    break;
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book); // trả về thằng book đc tìm thấy
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string Title,string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 và CSS the complete", "Author Name Book 1", "/Content/Images/image2cover.png"));
            books.Add(new Book(2, "HTML &CSS", "Author Name 2", "/Content/Images/image3cover.png"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name 3", "/Content/Images/image1cover.jpg"));
            if(id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            
            return View("ListBookModel",books);
        }
        
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,ImageCover")] Book book)
        {
            var books = new List<Book>();
            //sách mặc định
            books.Add(new Book(1, "HTML5 và CSS the complete", "Author Name Book 1", "/Content/Images/image2cover.png"));
            books.Add(new Book(2, "HTML &CSS", "Author Name 2", "/Content/Images/image3cover.png"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name 3", "/Content/Images/image1cover.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (Exception /*dex*/)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("listBookModel", books);
        }

        public ActionResult DeleteBook(int id)
        {
            
            

            return View(); // trả về thằng book đc tìm thấy
        }

        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 và CSS the complete", "Author Name Book 1", "/Content/Images/image2cover.png"));
            books.Add(new Book(2, "HTML &CSS", "Author Name 2", "/Content/Images/image3cover.png"));
            books.Add(new Book(3, "Professional ASP.NET", "Author Name 3", "/Content/Images/image1cover.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    books.Remove(b);
                    break;
                }
            }

            return View("ListBookModel", books);
        }
    }
}
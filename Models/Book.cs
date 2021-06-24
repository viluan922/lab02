using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace lab2WEB.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;
        public Book()
        {

        }
        public Book(int id ,string title,string author,string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
        }
        public int Id
        {
            get { return id;}
            set { id = value ; }
        }
        [Required(ErrorMessage ="Tiêu đề ko được trống Man")]
        [StringLength(250,ErrorMessage ="Tiêu đề sách ko được quá 250 ký tự Man")]
        [Display(Name ="Tiêu Đề")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        } 
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string ImageCover
        {
            get { return image_cover; }
            set { image_cover = value; }
        }
        
    }
}
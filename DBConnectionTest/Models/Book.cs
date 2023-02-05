using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DBConnectionTest.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Publish Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PublishDate { get; set; }

        public Author? Author { get; set; }
    }
}

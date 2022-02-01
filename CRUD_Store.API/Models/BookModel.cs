using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Store.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public String Title { get; set; }

        public String Descrption { get; set; }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace VocabularyProject.Models
{   
	public  class BookRepository : EFRepository<Book>, IBookRepository
	{
        public Book Find(int ID)
        {
            return this.All().Where(p => p.ID == ID).Single();
        }
	}

	public  interface IBookRepository : IRepository<Book>
	{

	}
    
}
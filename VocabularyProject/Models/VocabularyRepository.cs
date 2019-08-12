using System;
using System.Linq;
using System.Collections.Generic;
	
namespace VocabularyProject.Models
{   
	public  class VocabularyRepository : EFRepository<Vocabulary>, IVocabularyRepository
	{
        public Vocabulary Find(int id)
        {
            return All().Where(v => v.ID == id).Single();
        }
    }

	public  interface IVocabularyRepository : IRepository<Vocabulary>
	{

	}
}
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


        public IQueryable<object> WithJSON(int? [] unitID)
        {
            return All().Where(v => unitID.Contains(v.UnitID)).Select(a=>new {
                vID = a.ID,
                word = a.Word,
                chinese =a.Chinese,
                bookName= a.Unit.Book.Name,
                unitID =a.UnitID,
                unitNumber=a.Unit.Number,
                unitTopic=a.Unit.Topic
            });
        }
            
    }

	public  interface IVocabularyRepository : IRepository<Vocabulary>
	{

	}
}
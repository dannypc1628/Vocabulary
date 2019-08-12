using System;
using System.Linq;
using System.Collections.Generic;

	
namespace VocabularyProject.Models
{
    public class UnitRepository : EFRepository<Unit>, IUnitRepository
    {
        public Unit Find(int id)
        {
            return All().Where(u => u.ID == id).Single();
        }
    }

	public  interface IUnitRepository : IRepository<Unit>
	{

	}
}
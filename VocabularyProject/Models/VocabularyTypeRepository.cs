using System;
using System.Linq;
using System.Collections.Generic;
	
namespace VocabularyProject.Models
{   
	public  class VocabularyTypeRepository : EFRepository<VocabularyType>, IVocabularyTypeRepository
	{
        
	}

	public  interface IVocabularyTypeRepository : IRepository<VocabularyType>
	{

	}
}
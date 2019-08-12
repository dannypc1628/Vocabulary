namespace VocabularyProject.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static BookRepository GetBookRepository()
		{
			var repository = new BookRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static BookRepository GetBookRepository(IUnitOfWork unitOfWork)
		{
			var repository = new BookRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static UnitRepository GetUnitRepository()
		{
			var repository = new UnitRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static UnitRepository GetUnitRepository(IUnitOfWork unitOfWork)
		{
			var repository = new UnitRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static VocabularyRepository GetVocabularyRepository()
		{
			var repository = new VocabularyRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static VocabularyRepository GetVocabularyRepository(IUnitOfWork unitOfWork)
		{
			var repository = new VocabularyRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static VocabularyTypeRepository GetVocabularyTypeRepository()
		{
			var repository = new VocabularyTypeRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static VocabularyTypeRepository GetVocabularyTypeRepository(IUnitOfWork unitOfWork)
		{
			var repository = new VocabularyTypeRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}
using System.Collections.Generic;

namespace MaxTracker.Domain.Shared
{
	public interface IRepository<T>
	{
		void Create(T entity);

		IEnumerable<T> GetAll();
	}
}

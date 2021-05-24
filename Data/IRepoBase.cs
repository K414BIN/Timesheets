using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timesheets.Data
{

    /// <summary> Базовый интерфейс.    /// </summary>
    public interface IRepoBase<T>
    {
        Task<T> GetItem(Guid ID) ;
        Task<IEnumerable<T>> GetItems();
        Task  Add(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}

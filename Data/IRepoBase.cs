using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Data
{

    /// <summary>
    /// Базовый интерфейс. Содержит следующие методы:
    /// добавления - Add()
    /// обновления - Update()
    /// получения - GetItems()
    /// </summary>
    public interface IRepoBase<T>
    {
        T GetItem(Guid ID) ;
        IEnumerable<T> GetItems();
        void Add(T item);
        void Update();
    }
}

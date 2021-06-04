using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Services.Aggregates.SheetAggregate
{
    public interface ISheetAggregateRepo
    {
        Task<SheetAggregate> GetItem(Guid id);
        Task<IEnumerable<SheetAggregate>> GetItems();
        Task<Guid> Add(SheetAggregate item);
        Task Update(SheetAggregate item);
    }
}

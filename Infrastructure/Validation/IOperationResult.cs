using System.Collections.Generic;

namespace Timesheets.Infrastructure.Validation
{
   public interface IOperationResult<TResult>
	{
    	TResult Result { get; }
 
        IReadOnlyList<IOperationFailure> Failures { get; }
 
    	bool Succeed { get; }
	}
}
using Monitor.Domain.ViewModel;
using System;

namespace Monitor.Presentation.Contract
{
    public interface ITransactionPresentation
    {
        TransactionVm FindByGuid(Guid guid);
    }
}
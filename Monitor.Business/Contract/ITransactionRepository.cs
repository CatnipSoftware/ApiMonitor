using Monitor.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface ITransactionRepository
    {
        List<TransactionVm> List();
        TransactionVm FindByGuid(Guid guid);
        TransactionVm Create(TransactionVm transactionVm);
    }
}
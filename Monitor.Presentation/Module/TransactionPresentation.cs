using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;
using System;

namespace Monitor.Presentation.Module
{
    public class TransactionPresentation : ITransactionPresentation
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionPresentation(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public TransactionVm FindByGuid(Guid guid)
        {
            var transactionVm = _transactionRepository.FindByGuid(guid);

            if (transactionVm == null)
            {
                transactionVm = _transactionRepository.Create(new TransactionVm
                {
                    TransactionId = guid
                });
            }

            return transactionVm;
        }
    }
}
using Monitor.Business.Contract;
using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Business.Module
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MonitorContext _context;

        public TransactionRepository(MonitorContext context)
        {
            _context = context;
        }

        public List<TransactionVm> List()
        {
            return _context.Set<Transaction>()
                .Select(x => new TransactionVm
                {
                    Id = x.Id,
                    TransactionId = x.TransactionId
                })
                .ToList();
        }

        public TransactionVm FindByGuid(Guid guid)
        {
            return _context.Set<Transaction>()
                .Where(x => x.TransactionId == guid)
                .Select(x => new TransactionVm
                {
                    Id = x.Id,
                    TransactionId = x.TransactionId
                })
                .FirstOrDefault();
        }

        public TransactionVm Create(TransactionVm transactionVm)
        {
            var transaction = new Transaction
            {
                TransactionId = transactionVm.TransactionId
            };

            _context.Set<Transaction>().Add(transaction);
            _context.SaveChanges();

            transactionVm.Id = transaction.Id;

            return transactionVm;
        }
    }
}
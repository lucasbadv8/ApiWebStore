using System;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUsername(string username);
        Customer GetByUserId(Guid id);
        GetCustomerCommandResult Get(string username);
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);        
    }
}

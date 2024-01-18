using Eshop.Domain.SeedWork;
using Eshop.Domain.Shared;

namespace Eshop.Domain.Customers.Rules
{
    public class CustomerNameNotEmptyRule : IBusinessRule
    {
        private readonly String _name;

        public CustomerNameNotEmptyRule(String name)
        {
            _name = name;
        }

        public bool IsBroken() => _name.Length == 0;

        public string Message => "Customer name cannot be empty";
    }
}
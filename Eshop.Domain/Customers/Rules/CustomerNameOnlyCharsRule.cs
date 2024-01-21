using Eshop.Domain.SeedWork;
using Eshop.Domain.Shared;

namespace Eshop.Domain.Customers.Rules
{
    public class CustomerNameOnlyCharsRule : IBusinessRule
    {
        private readonly String _name;

        public CustomerNameOnlyCharsRule(String name)
        {
            _name = name;
        }

        public bool IsBroken() => _name.All(char.IsLetter);

        public string Message => "Customer name not only chars";
    }
}
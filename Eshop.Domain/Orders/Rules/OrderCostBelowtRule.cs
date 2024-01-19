using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Rules
{
    public class OrderCostBelowRule : IBusinessRule
    {
        private readonly List<OrderProduct> _orderProducts;

        public OrderCostBelowRule(List<OrderProduct> orderProducts)
        {
            _orderProducts = orderProducts;
        }

        public bool IsBroken() => _orderProducts.Sum(product => product.TotalCost) > 15000;

        public string Message => "Order must cost below 15000";
    }
}
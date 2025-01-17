﻿using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.CheckoutCart.Commands
{
    public class CreateCheckoutCartCommand : CommandBase<Guid>
    {
        public CheckoutCartDto CheckoutCart { get; }

        public CreateCheckoutCartCommand(
            CheckoutCartDto checkoutCartDto)
        {
            CheckoutCart = checkoutCartDto;
        }
    }
}

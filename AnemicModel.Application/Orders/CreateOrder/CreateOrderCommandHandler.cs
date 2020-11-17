using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AnemicModel.Application.Products;
using AnemicModel.Domain.Orders;
using MediatR;

namespace AnemicModel.Application.Orders.CreateOrder
{
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IProductsRepository _productsRepository;

        public CreateOrderCommandHandler(IOrdersRepository ordersRepository,
            IProductsRepository productsRepository)
        {
            _ordersRepository = ordersRepository;
            _productsRepository = productsRepository;
        }

        public async Task<Unit> Handle(CreateOrderCommand createOrderRequest, CancellationToken cancellationToken)
        {
            var productsToOrder = await _productsRepository.GetAsync(createOrderRequest.ProductsIds, cancellationToken);
            var order = new Order();
            var orderItems =
                productsToOrder.Select(product => new OrderItem {Product = product, Order = order});

            if (!orderItems.Any())
                throw new InvalidOperationException("Order cant be empty");

            var orderTotalPrice = orderItems.Select(x => x.Product.Price).Sum();
            if (orderTotalPrice > 1000)
                orderTotalPrice *= 0.75m;

            order.TotalPrice = orderTotalPrice;
            order.Status = OrderStatus.Pending;

            return Unit.Value;
        }
    }
}
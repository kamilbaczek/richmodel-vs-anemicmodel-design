using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RichModel.Domain.Orders;
using RichModel.Domain.Products;

namespace RichModel.Application.Orders.Commands.CreateOrder
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
            var order = Order.Create(productsToOrder);
            await _ordersRepository.CreateAsync(order, cancellationToken);

            return Unit.Value;
        }
    }
}
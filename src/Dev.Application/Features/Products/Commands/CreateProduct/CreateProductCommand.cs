using Dev.Application.Abstraction.Messaging.Commands;
using Dev.Domain.Entities.Products.DTOs;
using Dev.Application.Features.Products;

namespace Dev.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDto Dto) : ICommand<ProductResponse>;

    


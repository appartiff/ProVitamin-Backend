﻿using MediatR;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
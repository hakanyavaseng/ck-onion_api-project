﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionAPI.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

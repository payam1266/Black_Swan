using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.ProductCategories.Requests.Commands
{
    public class DeleteProductCategoryCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Cities.Requests.Commands
{
    public class DeleteCityCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}

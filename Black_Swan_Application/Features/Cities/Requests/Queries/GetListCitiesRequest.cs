using Black_Swan_Application.DTOs.City;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Cities.Requests.Queries
{
    public class GetListCitiesRequest:IRequest<List<CityDto>>
    {
    }
}

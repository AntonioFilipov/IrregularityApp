using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcTemplate.Data.Models;

namespace MvcTemplate.Services.Data
{
    public interface IPositionService
    {
        Position GetPositionByLatitudeAndLongitude(string latitude, string longitude);

        void Post(Position position);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using QUEMENARRASANGULAR.Dto;

namespace QUEMENARRASANGULAR
{
    public interface IFoolService : IApplicationService
    {

        InformationDto GetInformation(double longitude, double latitude, int zoomLevel);
    }
}

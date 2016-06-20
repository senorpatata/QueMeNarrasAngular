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
        bool Foolazo();

        string[] GetDatosMain();


        IList<InformationTuitDto> GetTuits(double latitude, double longitude, int zoomLevel);



    }
}

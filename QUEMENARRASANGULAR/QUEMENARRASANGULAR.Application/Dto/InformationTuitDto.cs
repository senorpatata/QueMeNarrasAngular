using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUEMENARRASANGULAR.Dto
{
    public class InformationTuitDto
    {

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string TweetUrl { get; set; }
        public string TweetCabecera { get; set; }
        public long Id { get; set; }
    }
    

    public class InformationDto
    {

        public IList<InformationTuitDto> Tuits = new List<InformationTuitDto>();
        public IList<string> HashTags = new List<string>();
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUEMENARRASANGULAR.Dto
{
    public class TuitInfo
    {

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string TweetUrl { get; set; }
        public string TweetCabecera { get; set; }
        public long Id { get; set; }
    }

    public class InformationDto
    {

        public IList<TuitInfo> Tuits = new List<TuitInfo>();
        public IList<HashInfo> HashTags = new List<HashInfo>();
        public IList<PlaceInfo> Places = new List<PlaceInfo>();
    }

    public class HashInfo
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
    }
    public class PlaceInfo
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
    }

}

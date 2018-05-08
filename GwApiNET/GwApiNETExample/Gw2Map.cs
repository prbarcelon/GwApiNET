using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GwApiNET;

namespace GwApiNETExample
{

    public class Gw2Map : GMapProvider
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Gw2Map()
        {
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = GwMapsHelper.GetTileUrl(1, 1, zoom, new Gw2Point { X = pos.X, Y = pos.Y });
            string log = "Fetchings: @" + zoom + " - " + url + "\n";
            //File.AppendAllText("url_ouput.txt", log);
            return GetTileImageUsingHttp(url);
        }


        private static Guid id = new Guid("909F035A-094F-46ED-B135-15456DF21A70");
        public override Guid Id
        {
            get { return id; }
        }

        public override string Name
        {
            get { return "Gw2Map"; }
        }

        private readonly PureProjection projection = MercatorProjection.Instance;
        public override PureProjection Projection
        {
            get { return projection; }
        }

        private GMapProvider[] _overlays;
        public override GMapProvider[] Overlays
        {
            get { return _overlays ?? (_overlays = new GMapProvider[] { this }); }
        }
    }
}

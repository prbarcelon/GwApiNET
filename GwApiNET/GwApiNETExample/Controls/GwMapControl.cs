using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.Projections;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GwApiNET;
using GwApiNET.Gw2PositionReader;
using GwApiNET.ResponseObjects;

namespace GwApiNETExample.Controls
{

    public class GwMapControl : GMapControl, IUpdateStatus
    {
        GMapOverlay members = new GMapOverlay("Markers");
        private GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(30.5, 30.5), GMarkerGoogleType.blue);
        System.Timers.Timer _updateTimer = new System.Timers.Timer(500);

        public double UpdateRate { get { return _updateTimer.Interval; } set { _updateTimer.Interval = value; } }

        public void UpdatePosition(int mapId, Gw2Point point, Player player)
        {
            Gw2Point pixel = GwMapsHelper.WorldPosToPixel(mapId, point, (int)Zoom);
            var latlng = MercatorProjection.Instance.FromPixelToLatLng((long)pixel.X, (long)pixel.Y, (int)Zoom);
            marker.ToolTipText =
                String.Format(
                "Point: {0}\n" +
                "Pixel: {1}\n" +
                "Lat/Long: {2}\n" +
                "Player Name: {3}\n" +
                "Profession: {4}\n" +
                "Team Color: {5}\n",
                point.ToString(),
                pixel.ToString(),
                latlng.ToString(),
                player.CharacterName,
                player.Profession,
                player.TeamColor
                );
            Debug.WriteLine(marker.ToolTipText);
            UpdatePosition(latlng);
        }

        private int counter = 0;

        public void UpdatePosition(PointLatLng point)
        {
            marker.Position = point;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public GwMapControl()
        {
            ResponseCache.Cache.Save();
            this.Dock = DockStyle.Fill;

            {   // Initialize the map
                //control.SetCurrentPositionByKeywords("USA");
                this.MapProvider = new Gw2Map();
                //control.MapProvider = GMapProviders.BingMap;
                this.MinZoom = 0;
                this.MaxZoom = 7;
                this.Zoom = 4;
                this.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;
                this.Overlays.Add(members);
                members.Markers.Add(marker);
            }
            //_addMarkers3();

            _updateTimer.Elapsed += _updateTimer_Elapsed;
            _updateTimer.Start();
        }

        Player player = null;

        void _updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //_addMarkers3();
                if (player == null)
                {
                    player = Gw2PositionReaderApi.GetPlayerDataInstance();
                }
                Vector3 pos = player.AvatarPosition.MetersToInches();
                var gwpoint = new Gw2Point(pos.X, pos.Z);
                Debug.WriteLine("MapType: " + player.MapType);

                UpdatePosition((int)player.MapId, gwpoint, player);
                //Console.WriteLine("Map: {0}, Point:{1}", player.MapId, gwpoint);
                UpdateMarkerLocalPosition(marker);
                Status = string.Format("X:{0:0} Y:{1:0} Z:{2:0}", pos.X, pos.Y, pos.Z);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public event StatusChangeEvent StatusChanged;
        public string Status { get; private set; }
        public string Description { get; private set; }
    }
}

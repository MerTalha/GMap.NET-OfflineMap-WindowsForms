using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using GMapMarker = GMap.NET.WindowsForms.GMapMarker;
using GMapRoute = GMap.NET.WindowsForms.GMapRoute;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        GMapOverlay markers = new GMapOverlay("markers");

        List<PointLatLng> markerKoordinatlari = new List<PointLatLng>();

        GMarkerGoogle marker;

        private GMapOverlay routeOverlay = new GMapOverlay("routeOverlay"); // Route overlay'i


        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.Position = new PointLatLng(39.92390734605342, 32.826400220064734);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 1;
            gMapControl1.IgnoreMarkerOnMouseWheel = true;

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            RectLatLng area = gMapControl1.SelectedArea;

            if (!area.IsEmpty)
            {
                for (int i = (int)gMapControl1.Zoom; i <= 16; i++)
                {
                    GMap.NET.TilePrefetcher obj = new GMap.NET.TilePrefetcher();
                    obj.Icon = this.Icon;
                    obj.Owner = this;
                    obj.ShowCompleteMessage = false;
                    obj.Start(area, i, gMapControl1.MapProvider, 100, 1);
                }

                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("No Area Chosen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // Sadece sol tuş tıklamasını kontrol ediyoruz
            {
                double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;

                marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.green);

                // Yeni marker eklendikten sonra koordinatları temizle
                markerKoordinatlari.Clear();

                // Markers koleksiyonunu güncellediğiniz için Overlay'ı güncelleyin
                gMapControl1.Overlays.Clear();
                gMapControl1.Overlays.Add(markers);
                markers.Markers.Add(marker);

                // Tüm markerları tekrar ekleyerek koordinatları güncelle
                foreach (GMapMarker existingMarker in markers.Markers)
                {
                    markerKoordinatlari.Add(existingMarker.Position);
                }

                // Marker koordinatlarını yazdır
                foreach (PointLatLng koordinat in markerKoordinatlari)
                {
                    Console.WriteLine("Latitude: " + koordinat.Lat + ", Longitude: " + koordinat.Lng);
                }
                Console.WriteLine("-----------------------------");


                // Eklenen markerlar arasında polyline çiz
                routeOverlay.Clear();
                if (markerKoordinatlari.Count >= 2)
                {
                    List<PointLatLng> tempKoordinatlari = new List<PointLatLng>(markerKoordinatlari);
                    GMapRoute newRoute = new GMapRoute(tempKoordinatlari, "Route");
                    routeOverlay.Routes.Add(newRoute);
                }

                // routeOverlay'i güncelleyin
                gMapControl1.Overlays.Add(routeOverlay);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (markers.Markers.Count > 0)
            {
                markers.Markers.RemoveAt(markers.Markers.Count - 1); // Son markerı kaldırın

                markerKoordinatlari.RemoveAt(markerKoordinatlari.Count - 1); // Koordinatları güncelleyin

                gMapControl1.Overlays.Clear();
                gMapControl1.Overlays.Add(markers);

                routeOverlay.Clear(); // Polyline'ları temizleyin

                if (markerKoordinatlari.Count >= 2)
                {
                    GMapRoute newRoute = new GMapRoute(markerKoordinatlari, "Route");
                    routeOverlay.Routes.Add(newRoute);
                }

                gMapControl1.Overlays.Add(routeOverlay); // Overlay'i güncelleyin
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            markers.Markers.Clear(); // Tüm markerları temizleyin
            markerKoordinatlari.Clear(); // Koordinatları temizleyin

            gMapControl1.Overlays.Clear(); // Tüm overlay'ları temizleyin

            routeOverlay.Routes.Clear(); // Tüm polyline'ları temizleyin

            gMapControl1.Refresh(); // Haritayı yenileyin
        }
    }
}

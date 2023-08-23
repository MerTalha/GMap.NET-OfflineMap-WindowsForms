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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        GMapOverlay markers = new GMapOverlay("markers");

        List<PointLatLng> markerKoordinatlari = new List<PointLatLng>();

        GMarkerGoogle marker;

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.Dock= DockStyle.Fill;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.Position = new PointLatLng(39.92390734605342, 32.826400220064734);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 1;
            gMapControl1.IgnoreMarkerOnMouseWheel = true;

            
        }



        private void button1_Click(object sender, EventArgs e)
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
                markers.Markers.Add(marker);

                // Yeni marker eklendikten sonra koordinatları temizle
                markerKoordinatlari.Clear();

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

                // Markers koleksiyonunu güncellediğiniz için Overlay'ı güncelleyin
                gMapControl1.Overlays.Clear();
                gMapControl1.Overlays.Add(markers);
            }
        }



    }
}

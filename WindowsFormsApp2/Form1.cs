using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using GMapMarker = GMap.NET.WindowsForms.GMapMarker;
using GMapRoute = GMap.NET.WindowsForms.GMapRoute;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        GMapOverlay markers = new GMapOverlay("markers");

        List<PointLatLng> markerCoordinates = new List<PointLatLng>();

        GMarkerGoogle marker;

        private GMapOverlay routeOverlay = new GMapOverlay("routeOverlay");

        private GMapMarker draggedMarker = null;
        private PointLatLng dragStartPoint;
        private bool isDragging = false;

        private bool isMarker = true;

        private DateTime mouseDownTime;
        private const int dragThreshold = 200;




        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.Dock = DockStyle.Fill;
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
                for (int i = (int)gMapControl1.Zoom; i <= 15; i++)
                {
                    GMap.NET.TilePrefetcher obj = new GMap.NET.TilePrefetcher();
                    obj.Icon = this.Icon;
                    obj.Owner = this;
                    obj.ShowCompleteMessage = false;
                    obj.Start(area, i, gMapControl1.MapProvider, 100, 1);
                }

                //Close();
            }
            else
            {
                System.Windows.MessageBox.Show("No Area Chosen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMarker)
            {
                if (e.Button == MouseButtons.Left)
                {
                    double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                    double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;

                    marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.green);

                    // Clear coordinates after adding a new marker
                    markerCoordinates.Clear();

                    // Clear overlays and add markers collection
                    gMapControl1.Overlays.Clear();
                    gMapControl1.Overlays.Add(markers);
                    markers.Markers.Add(marker);

                    // Update marker coordinates
                    foreach (GMapMarker existingMarker in markers.Markers)
                    {
                        markerCoordinates.Add(existingMarker.Position);
                    }

                    foreach (PointLatLng koordinat in markerCoordinates)
                    {
                        Console.WriteLine("Latitude: " + koordinat.Lat + ", Longitude: " + koordinat.Lng);
                    }
                    Console.WriteLine("-----------------------------");


                    // Draw polyline between added markers
                    routeOverlay.Clear();
                    if (markerCoordinates.Count >= 2)
                    {
                        List<PointLatLng> tempKoordinatlari = new List<PointLatLng>(markerCoordinates);
                        GMapRoute newRoute = new GMapRoute(tempKoordinatlari, "Route");
                        routeOverlay.Routes.Add(newRoute);
                    }
                    mouseDownTime = DateTime.Now;
                    dragStartPoint = marker.Position;
                    isDragging = true;
                    draggedMarker = marker;

                    gMapControl1.Overlays.Add(routeOverlay);
                }

            }



        }

        GMapMarker gMapMarker = null;
        private void GMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (!isDragging && (DateTime.Now - mouseDownTime).TotalMilliseconds > dragThreshold)
            {
                gMapMarker = item;
                isDragging = true;
                draggedMarker = item;
                dragStartPoint = item.Position;
                Cursor = Cursors.SizeAll;
                //PointLatLng pointLatLng = new PointLatLng(40,40);
                //item.Position = (pointLatLng);
                //MessageBox.Show("a" + item.Position);

            }
        }

        private void GMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedMarker != null)
            {
                PointLatLng newLatLng = gMapControl1.FromLocalToLatLng(e.X, e.Y);

                double deltaX = newLatLng.Lng - dragStartPoint.Lng;
                double deltaY = newLatLng.Lat - dragStartPoint.Lat;

                draggedMarker.Position = new PointLatLng(draggedMarker.Position.Lat + deltaY, draggedMarker.Position.Lng + deltaX);

                dragStartPoint = newLatLng;

                UpdateRoute();
            }

            /*if (isDragging && gMapMarker != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                    double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;

                    isDragging = false;
                    draggedMarker = gMapMarker;
                    dragStartPoint = gMapMarker.Position;
                    Cursor = Cursors.SizeAll;
                    PointLatLng pointLatLng = new PointLatLng(X, Y);
                    gMapMarker.Position = (pointLatLng);

                    gMapMarker.Position = (pointLatLng);

                }
            }*/
        }

        private void GMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Reset drag related variables
                isDragging = false;
                draggedMarker = null;
            }
        }

        private void GMapControl1_OnMarkerEnter(GMapMarker item)
        {
            if (!isDragging)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void GMapControl1_OnMarkerLeave(GMapMarker item)
        {
            Cursor = Cursors.Default;
        }


        private void UpdateRoute()
        {
            routeOverlay.Clear();

            if (markerCoordinates.Count >= 2)
            {
                GMapRoute newRoute = new GMapRoute(markerCoordinates, "Route");
                routeOverlay.Routes.Add(newRoute);
            }

            gMapControl1.Refresh();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            if (markers.Markers.Count > 0)
            {
                markers.Markers.RemoveAt(markers.Markers.Count - 1); // Remove the last marker

                markerCoordinates.RemoveAt(markerCoordinates.Count - 1); // Update coordinates

                gMapControl1.Overlays.Clear();
                gMapControl1.Overlays.Add(markers);

                routeOverlay.Clear(); // Clear polylines

                if (markerCoordinates.Count >= 2)
                {
                    GMapRoute newRoute = new GMapRoute(markerCoordinates, "Route");
                    routeOverlay.Routes.Add(newRoute);
                }

                gMapControl1.Overlays.Add(routeOverlay);
            }
        }

        //Clear All Markers And Polylines
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            markers.Markers.Clear();
            markerCoordinates.Clear();
            gMapControl1.Overlays.Clear();

            routeOverlay.Routes.Clear();

            gMapControl1.Refresh();
        }

        private void btnGoogleMap_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            isMarker = false;
        }

        private void btnBingMap_Click(object sender, EventArgs e)
        {
            //gMapControl1.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
            isMarker = true;
        }
    }
}
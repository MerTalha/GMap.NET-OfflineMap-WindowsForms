﻿using GMap.NET;
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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        GMapOverlay markers = new GMapOverlay("markers");

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
            double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;

            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.green);
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);
        }
    }
}

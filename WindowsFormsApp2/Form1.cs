using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gmap.Dock = DockStyle.Fill;
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.ShowCenter = false;
            gmap.MinZoom = 1;
            gmap.MaxZoom = 20;*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.Dock= DockStyle.Fill;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.Position = new PointLatLng(39.92390734605342, 32.826400220064734);
            gMapControl1.Zoom = 15;

            gMapControl1.MouseDown += GMapControl1_MouseDown;


        }

        private void GMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Sol tık
            {
                gMapControl1.Zoom += 1; // Zoom seviyesini arttır
            }
            else if (e.Button == MouseButtons.Right) // Sağ tık
            {
                gMapControl1.Zoom -= 1; // Zoom seviyesini azalt
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RectLatLng area = gMapControl1.SelectedArea;

            if (!area.IsEmpty)
            {
                for (int i = (int)gMapControl1.Zoom; i <= gMapControl1.MaxZoom; i++)
                {
                    TilePrefetcher obj = new TilePrefetcher();
                    obj.Owner = this;
                    obj.ShowCompleteMessage = false;
                    obj.Start(area, i, gMapControl1.MapProvider, 100,5);
                }

                Close();
            }
        }
    }
}

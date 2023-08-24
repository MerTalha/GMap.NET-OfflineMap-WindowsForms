namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnGoogleMap = new System.Windows.Forms.Button();
            this.btnBingMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(250, 61);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1397, 700);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GMapControl1_MouseDown);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDownload.ForeColor = System.Drawing.Color.Silver;
            this.btnDownload.Location = new System.Drawing.Point(35, 61);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(150, 50);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.ForeColor = System.Drawing.Color.Silver;
            this.btnClear.Location = new System.Drawing.Point(35, 131);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 50);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClearAll.ForeColor = System.Drawing.Color.Silver;
            this.btnClearAll.Location = new System.Drawing.Point(35, 201);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(150, 50);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnGoogleMap
            // 
            this.btnGoogleMap.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGoogleMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGoogleMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoogleMap.ForeColor = System.Drawing.Color.Silver;
            this.btnGoogleMap.Location = new System.Drawing.Point(35, 278);
            this.btnGoogleMap.Name = "btnGoogleMap";
            this.btnGoogleMap.Size = new System.Drawing.Size(150, 50);
            this.btnGoogleMap.TabIndex = 4;
            this.btnGoogleMap.Text = "Google Map";
            this.btnGoogleMap.UseVisualStyleBackColor = false;
            this.btnGoogleMap.Click += new System.EventHandler(this.btnGoogleMap_Click);
            // 
            // btnBingMap
            // 
            this.btnBingMap.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBingMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBingMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBingMap.ForeColor = System.Drawing.Color.Silver;
            this.btnBingMap.Location = new System.Drawing.Point(35, 351);
            this.btnBingMap.Name = "btnBingMap";
            this.btnBingMap.Size = new System.Drawing.Size(150, 50);
            this.btnBingMap.TabIndex = 5;
            this.btnBingMap.Text = "Bing Hybrid";
            this.btnBingMap.UseVisualStyleBackColor = false;
            this.btnBingMap.Click += new System.EventHandler(this.btnBingMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 903);
            this.Controls.Add(this.btnBingMap);
            this.Controls.Add(this.btnGoogleMap);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.gMapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnGoogleMap;
        private System.Windows.Forms.Button btnBingMap;
    }
}


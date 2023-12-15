namespace ClientGUI_v3
{
    partial class Plot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zgcPlot = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zgcPlot
            // 
            this.zgcPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zgcPlot.Location = new System.Drawing.Point(13, 12);
            this.zgcPlot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.zgcPlot.Name = "zgcPlot";
            this.zgcPlot.ScrollGrace = 0D;
            this.zgcPlot.ScrollMaxX = 0D;
            this.zgcPlot.ScrollMaxY = 0D;
            this.zgcPlot.ScrollMaxY2 = 0D;
            this.zgcPlot.ScrollMinX = 0D;
            this.zgcPlot.ScrollMinY = 0D;
            this.zgcPlot.ScrollMinY2 = 0D;
            this.zgcPlot.Size = new System.Drawing.Size(784, 480);
            this.zgcPlot.TabIndex = 0;
            // 
            // Plot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 504);
            this.Controls.Add(this.zgcPlot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Plot";
            this.Text = "Plot";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zgcPlot;
    }
}
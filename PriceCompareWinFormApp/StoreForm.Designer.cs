namespace PriceCompareWinFormApp
{
    partial class StoreForm
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
            this.chainLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.storeLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.min3Box = new System.Windows.Forms.ListBox();
            this.max3box = new System.Windows.Forms.ListBox();
            this.itemsBox = new System.Windows.Forms.ListBox();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chainLabel
            // 
            this.chainLabel.AutoSize = true;
            this.chainLabel.Location = new System.Drawing.Point(16, 9);
            this.chainLabel.Name = "chainLabel";
            this.chainLabel.Size = new System.Drawing.Size(0, 13);
            this.chainLabel.TabIndex = 0;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(201, 46);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(0, 13);
            this.cityLabel.TabIndex = 4;
            // 
            // storeLabel
            // 
            this.storeLabel.AutoSize = true;
            this.storeLabel.Location = new System.Drawing.Point(16, 46);
            this.storeLabel.Name = "storeLabel";
            this.storeLabel.Size = new System.Drawing.Size(0, 13);
            this.storeLabel.TabIndex = 2;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(201, 9);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(0, 13);
            this.addressLabel.TabIndex = 3;
            // 
            // min3Box
            // 
            this.min3Box.FormattingEnabled = true;
            this.min3Box.Location = new System.Drawing.Point(19, 94);
            this.min3Box.Name = "min3Box";
            this.min3Box.Size = new System.Drawing.Size(120, 95);
            this.min3Box.TabIndex = 5;
            // 
            // max3box
            // 
            this.max3box.FormattingEnabled = true;
            this.max3box.Location = new System.Drawing.Point(19, 209);
            this.max3box.Name = "max3box";
            this.max3box.Size = new System.Drawing.Size(120, 95);
            this.max3box.TabIndex = 6;
            // 
            // itemsBox
            // 
            this.itemsBox.FormattingEnabled = true;
            this.itemsBox.Location = new System.Drawing.Point(194, 94);
            this.itemsBox.Name = "itemsBox";
            this.itemsBox.Size = new System.Drawing.Size(238, 212);
            this.itemsBox.TabIndex = 7;
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(19, 75);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(0, 13);
            this.minLabel.TabIndex = 8;
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(21, 193);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(35, 13);
            this.maxLabel.TabIndex = 9;
            this.maxLabel.Text = "label2";
            // 
            // itemsLabel
            // 
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Location = new System.Drawing.Point(194, 75);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(0, 13);
            this.itemsLabel.TabIndex = 10;
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 330);
            this.Controls.Add(this.itemsLabel);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.itemsBox);
            this.Controls.Add(this.max3box);
            this.Controls.Add(this.min3Box);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.storeLabel);
            this.Controls.Add(this.chainLabel);
            this.Name = "StoreForm";
            this.Text = "StoreForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chainLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label storeLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.ListBox min3Box;
        private System.Windows.Forms.ListBox max3box;
        private System.Windows.Forms.ListBox itemsBox;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label itemsLabel;
    }
}
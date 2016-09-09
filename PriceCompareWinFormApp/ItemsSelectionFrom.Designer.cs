namespace PriceCompareWinFormApp
{
    sealed partial class ItemsSelectionFrom
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
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.MenuItemsWorker = new System.ComponentModel.BackgroundWorker();
            this.itemsGrid = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selectItemsButton = new System.Windows.Forms.Button();
            this.AddItemsWorker = new System.ComponentModel.BackgroundWorker();
            this.storesGrid = new System.Windows.Forms.DataGridView();
            this.storeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storeInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.priceImage = new System.Windows.Forms.PictureBox();
            this.citiesCB = new System.Windows.Forms.ComboBox();
            this.ChainCB = new System.Windows.Forms.ComboBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.UpdateWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceImage)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(13, 13);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(0, 13);
            this.UserNameLabel.TabIndex = 0;
            // 
            // MenuItemsWorker
            // 
            this.MenuItemsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MenuItemsWorker_DoWork);
            this.MenuItemsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MenuItemsWorker_RunWorkerCompleted);
            // 
            // itemsGrid
            // 
            this.itemsGrid.AllowUserToAddRows = false;
            this.itemsGrid.AllowUserToDeleteRows = false;
            this.itemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.itemName,
            this.units,
            this.qty,
            this.selectItem});
            this.itemsGrid.Location = new System.Drawing.Point(12, 52);
            this.itemsGrid.Name = "itemsGrid";
            this.itemsGrid.Size = new System.Drawing.Size(445, 315);
            this.itemsGrid.TabIndex = 1;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.No.Width = 50;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "Item Name";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 200;
            // 
            // units
            // 
            this.units.HeaderText = "Unit Qty";
            this.units.Name = "units";
            this.units.ReadOnly = true;
            this.units.Width = 50;
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.Width = 50;
            // 
            // selectItem
            // 
            this.selectItem.HeaderText = "Select Item";
            this.selectItem.Name = "selectItem";
            this.selectItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectItem.Width = 50;
            // 
            // selectItemsButton
            // 
            this.selectItemsButton.Location = new System.Drawing.Point(335, 384);
            this.selectItemsButton.Name = "selectItemsButton";
            this.selectItemsButton.Size = new System.Drawing.Size(122, 23);
            this.selectItemsButton.TabIndex = 2;
            this.selectItemsButton.UseVisualStyleBackColor = true;
            this.selectItemsButton.Click += new System.EventHandler(this.selectItems_Click);
            // 
            // AddItemsWorker
            // 
            this.AddItemsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AddItemsWorker_DoWork);
            this.AddItemsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AddItemsWorker_RunWorkerCompleted);
            // 
            // storesGrid
            // 
            this.storesGrid.AllowUserToAddRows = false;
            this.storesGrid.AllowUserToDeleteRows = false;
            this.storesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.storeName,
            this.total,
            this.storeInfo});
            this.storesGrid.Location = new System.Drawing.Point(476, 87);
            this.storesGrid.Name = "storesGrid";
            this.storesGrid.Size = new System.Drawing.Size(340, 150);
            this.storesGrid.TabIndex = 3;
            this.storesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StoresGrid_CellClick);
            // 
            // storeName
            // 
            this.storeName.HeaderText = "Store info";
            this.storeName.Name = "storeName";
            this.storeName.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // storeInfo
            // 
            this.storeInfo.HeaderText = "Store info";
            this.storeInfo.Name = "storeInfo";
            this.storeInfo.ReadOnly = true;
            // 
            // priceImage
            // 
            this.priceImage.Location = new System.Drawing.Point(487, 87);
            this.priceImage.Name = "priceImage";
            this.priceImage.Size = new System.Drawing.Size(315, 267);
            this.priceImage.TabIndex = 4;
            this.priceImage.TabStop = false;
            // 
            // citiesCB
            // 
            this.citiesCB.FormattingEnabled = true;
            this.citiesCB.Location = new System.Drawing.Point(477, 52);
            this.citiesCB.Name = "citiesCB";
            this.citiesCB.Size = new System.Drawing.Size(121, 21);
            this.citiesCB.TabIndex = 5;
            // 
            // ChainCB
            // 
            this.ChainCB.FormattingEnabled = true;
            this.ChainCB.Location = new System.Drawing.Point(610, 52);
            this.ChainCB.Name = "ChainCB";
            this.ChainCB.Size = new System.Drawing.Size(121, 21);
            this.ChainCB.TabIndex = 6;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(742, 52);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 7;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // UpdateWorker
            // 
            this.UpdateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateWorker_DoWork);
            this.UpdateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UpdateWorker_RunWorkerCompleted);
            // 
            // ItemsSelectionFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 427);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.ChainCB);
            this.Controls.Add(this.citiesCB);
            this.Controls.Add(this.priceImage);
            this.Controls.Add(this.storesGrid);
            this.Controls.Add(this.selectItemsButton);
            this.Controls.Add(this.itemsGrid);
            this.Controls.Add(this.UserNameLabel);
            this.Name = "ItemsSelectionFrom";
            this.Text = "ItemsSelectionFrom";
            ((System.ComponentModel.ISupportInitialize)(this.itemsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.ComponentModel.BackgroundWorker MenuItemsWorker;
        private System.Windows.Forms.DataGridView itemsGrid;
        private System.Windows.Forms.Button selectItemsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn units;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectItem;
        private System.ComponentModel.BackgroundWorker AddItemsWorker;
        private System.Windows.Forms.DataGridView storesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewButtonColumn storeInfo;
        private System.Windows.Forms.PictureBox priceImage;
        private System.Windows.Forms.ComboBox citiesCB;
        private System.Windows.Forms.ComboBox ChainCB;
        private System.Windows.Forms.Button updateButton;
        private System.ComponentModel.BackgroundWorker UpdateWorker;
    }
}
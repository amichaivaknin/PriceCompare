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
            this.storesGB = new System.Windows.Forms.GroupBox();
            this.exelButton = new System.Windows.Forms.Button();
            this.saveShoppingListButton = new System.Windows.Forms.Button();
            this.ExelWorker = new System.ComponentModel.BackgroundWorker();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.SaveShoppingWorker = new System.ComponentModel.BackgroundWorker();
            this.WatchPreviusWorker = new System.ComponentModel.BackgroundWorker();
            this.signOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceImage)).BeginInit();
            this.storesGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.Location = new System.Drawing.Point(13, 13);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(0, 34);
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
            this.storesGrid.Location = new System.Drawing.Point(6, 58);
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
            this.storeName.Width = 150;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 56;
            // 
            // storeInfo
            // 
            this.storeInfo.FillWeight = 70F;
            this.storeInfo.HeaderText = "Store info";
            this.storeInfo.Name = "storeInfo";
            this.storeInfo.ReadOnly = true;
            this.storeInfo.Width = 70;
            // 
            // priceImage
            // 
            this.priceImage.Location = new System.Drawing.Point(483, 87);
            this.priceImage.Name = "priceImage";
            this.priceImage.Size = new System.Drawing.Size(315, 267);
            this.priceImage.TabIndex = 4;
            this.priceImage.TabStop = false;
            // 
            // citiesCB
            // 
            this.citiesCB.FormattingEnabled = true;
            this.citiesCB.Location = new System.Drawing.Point(6, 19);
            this.citiesCB.Name = "citiesCB";
            this.citiesCB.Size = new System.Drawing.Size(121, 21);
            this.citiesCB.TabIndex = 5;
            // 
            // ChainCB
            // 
            this.ChainCB.FormattingEnabled = true;
            this.ChainCB.Location = new System.Drawing.Point(147, 19);
            this.ChainCB.Name = "ChainCB";
            this.ChainCB.Size = new System.Drawing.Size(121, 21);
            this.ChainCB.TabIndex = 6;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(278, 19);
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
            // storesGB
            // 
            this.storesGB.Controls.Add(this.exelButton);
            this.storesGB.Controls.Add(this.saveShoppingListButton);
            this.storesGB.Controls.Add(this.storesGrid);
            this.storesGB.Controls.Add(this.updateButton);
            this.storesGB.Controls.Add(this.citiesCB);
            this.storesGB.Controls.Add(this.ChainCB);
            this.storesGB.Location = new System.Drawing.Point(463, 52);
            this.storesGB.Name = "storesGB";
            this.storesGB.Size = new System.Drawing.Size(372, 315);
            this.storesGB.TabIndex = 8;
            this.storesGB.TabStop = false;
            // 
            // exelButton
            // 
            this.exelButton.Location = new System.Drawing.Point(228, 235);
            this.exelButton.Name = "exelButton";
            this.exelButton.Size = new System.Drawing.Size(118, 23);
            this.exelButton.TabIndex = 8;
            this.exelButton.UseVisualStyleBackColor = true;
            this.exelButton.Click += new System.EventHandler(this.exelButton_Click);
            // 
            // saveShoppingListButton
            // 
            this.saveShoppingListButton.Location = new System.Drawing.Point(7, 235);
            this.saveShoppingListButton.Name = "saveShoppingListButton";
            this.saveShoppingListButton.Size = new System.Drawing.Size(201, 23);
            this.saveShoppingListButton.TabIndex = 9;
            this.saveShoppingListButton.UseVisualStyleBackColor = true;
            this.saveShoppingListButton.Click += new System.EventHandler(this.saveShoppingListButton_Click);
            // 
            // ExelWorker
            // 
            this.ExelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ExelWorker_DoWork);
            this.ExelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ExelWorker_RunWorkerCompleted);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(12, 384);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(220, 23);
            this.PreviousButton.TabIndex = 10;
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // SaveShoppingWorker
            // 
            this.SaveShoppingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SaveShoppingWorker_DoWork);
            this.SaveShoppingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SaveShoppingWorker_RunWorkerCompleted);
            // 
            // WatchPreviusWorker
            // 
            this.WatchPreviusWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WatchPreviusWorker_DoWork);
            this.WatchPreviusWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WatchPreviusWorker_RunWorkerCompleted);
            // 
            // signOut
            // 
            this.signOut.Location = new System.Drawing.Point(741, 12);
            this.signOut.Name = "signOut";
            this.signOut.Size = new System.Drawing.Size(75, 23);
            this.signOut.TabIndex = 11;
            this.signOut.Text = "Sign out";
            this.signOut.UseVisualStyleBackColor = true;
            this.signOut.Click += new System.EventHandler(this.signOut_Click);
            // 
            // ItemsSelectionFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 427);
            this.Controls.Add(this.signOut);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.storesGB);
            this.Controls.Add(this.priceImage);
            this.Controls.Add(this.selectItemsButton);
            this.Controls.Add(this.itemsGrid);
            this.Controls.Add(this.UserNameLabel);
            this.Name = "ItemsSelectionFrom";
            this.Text = "ItemsSelectionFrom";
            ((System.ComponentModel.ISupportInitialize)(this.itemsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceImage)).EndInit();
            this.storesGB.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox priceImage;
        private System.Windows.Forms.ComboBox citiesCB;
        private System.Windows.Forms.ComboBox ChainCB;
        private System.Windows.Forms.Button updateButton;
        private System.ComponentModel.BackgroundWorker UpdateWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewButtonColumn storeInfo;
        private System.Windows.Forms.GroupBox storesGB;
        private System.Windows.Forms.Button exelButton;
        private System.ComponentModel.BackgroundWorker ExelWorker;
        private System.Windows.Forms.Button saveShoppingListButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.ComponentModel.BackgroundWorker SaveShoppingWorker;
        private System.ComponentModel.BackgroundWorker WatchPreviusWorker;
        private System.Windows.Forms.Button signOut;
    }
}
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
            this.ShoppingCartsWorker = new System.ComponentModel.BackgroundWorker();
            this.SaveShoppingListByUser = new System.ComponentModel.BackgroundWorker();
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
            // 
            // ShoppingCartsWorker
            // 
            this.ShoppingCartsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ShoppingCartsWorker_DoWork);
            // 
            // SaveShoppingListByUser
            // 
            this.SaveShoppingListByUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SaveShoppingListByUser_DoWork);
            // 
            // ItemsSelectionFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 490);
            this.Controls.Add(this.UserNameLabel);
            this.Name = "ItemsSelectionFrom";
            this.Text = "ItemsSelectionFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.ComponentModel.BackgroundWorker MenuItemsWorker;
        private System.ComponentModel.BackgroundWorker ShoppingCartsWorker;
        private System.ComponentModel.BackgroundWorker SaveShoppingListByUser;
    }
}
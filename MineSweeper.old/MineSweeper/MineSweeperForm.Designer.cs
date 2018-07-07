namespace MineSweeper {
    partial class MineSweeperForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.minefieldPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.minefieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // minefieldPictureBox
            // 
            this.minefieldPictureBox.Location = new System.Drawing.Point(12, 40);
            this.minefieldPictureBox.Name = "minefieldPictureBox";
            this.minefieldPictureBox.Size = new System.Drawing.Size(460, 409);
            this.minefieldPictureBox.TabIndex = 0;
            this.minefieldPictureBox.TabStop = false;
            this.minefieldPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.minefieldPictureBox_Paint);
            // 
            // MineSweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.minefieldPictureBox);
            this.Name = "MineSweeperForm";
            this.Text = "Mine Sweeper";
            ((System.ComponentModel.ISupportInitialize)(this.minefieldPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox minefieldPictureBox;
    }
}


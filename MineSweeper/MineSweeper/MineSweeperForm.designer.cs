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
            this.components = new System.ComponentModel.Container();
            this.minefieldPictureBox = new System.Windows.Forms.PictureBox();
            this.timeSpentLabel = new System.Windows.Forms.Label();
            this.secondTimer = new System.Windows.Forms.Timer(this.components);
            this.bombsLeftLabel = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minefieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // minefieldPictureBox
            // 
            this.minefieldPictureBox.Location = new System.Drawing.Point(12, 40);
            this.minefieldPictureBox.Name = "minefieldPictureBox";
            this.minefieldPictureBox.Size = new System.Drawing.Size(215, 215);
            this.minefieldPictureBox.TabIndex = 0;
            this.minefieldPictureBox.TabStop = false;
            this.minefieldPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.minefieldPictureBox_Paint);
            this.minefieldPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.minefieldPictureBox_MouseDown);
            this.minefieldPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.minefieldPictureBox_MouseUp);
            // 
            // timeSpentLabel
            // 
            this.timeSpentLabel.AutoSize = true;
            this.timeSpentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeSpentLabel.Location = new System.Drawing.Point(7, 9);
            this.timeSpentLabel.Name = "timeSpentLabel";
            this.timeSpentLabel.Size = new System.Drawing.Size(64, 25);
            this.timeSpentLabel.TabIndex = 1;
            this.timeSpentLabel.Text = "label1";
            // 
            // secondTimer
            // 
            this.secondTimer.Tick += new System.EventHandler(this.secondTimer_Tick);
            // 
            // bombsLeftLabel
            // 
            this.bombsLeftLabel.AutoSize = true;
            this.bombsLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bombsLeftLabel.Location = new System.Drawing.Point(160, 9);
            this.bombsLeftLabel.Name = "bombsLeftLabel";
            this.bombsLeftLabel.Size = new System.Drawing.Size(64, 25);
            this.bombsLeftLabel.TabIndex = 2;
            this.bombsLeftLabel.Text = "label1";
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(82, 11);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 3;
            this.newGameButton.Text = "New";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // MineSweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 267);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.bombsLeftLabel);
            this.Controls.Add(this.timeSpentLabel);
            this.Controls.Add(this.minefieldPictureBox);
            this.KeyPreview = true;
            this.Name = "MineSweeperForm";
            this.Text = "Mine Sweeper";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MineSweeperForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MineSweeperForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.minefieldPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox minefieldPictureBox;
        private System.Windows.Forms.Label timeSpentLabel;
        private System.Windows.Forms.Timer secondTimer;
        private System.Windows.Forms.Label bombsLeftLabel;
        private System.Windows.Forms.Button newGameButton;
    }
}


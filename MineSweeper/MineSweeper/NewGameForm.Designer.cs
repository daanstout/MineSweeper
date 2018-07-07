namespace MineSweeper {
    partial class NewGameForm {
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
            this.widthNumeric = new System.Windows.Forms.NumericUpDown();
            this.heightNumeric = new System.Windows.Forms.NumericUpDown();
            this.bombsNumeric = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.bombsLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // widthNumeric
            // 
            this.widthNumeric.Location = new System.Drawing.Point(94, 12);
            this.widthNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.widthNumeric.Name = "widthNumeric";
            this.widthNumeric.Size = new System.Drawing.Size(120, 20);
            this.widthNumeric.TabIndex = 0;
            this.widthNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.widthNumeric.ValueChanged += new System.EventHandler(this.widthNumeric_ValueChanged);
            // 
            // heightNumeric
            // 
            this.heightNumeric.Location = new System.Drawing.Point(94, 38);
            this.heightNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.heightNumeric.Name = "heightNumeric";
            this.heightNumeric.Size = new System.Drawing.Size(120, 20);
            this.heightNumeric.TabIndex = 1;
            this.heightNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.heightNumeric.ValueChanged += new System.EventHandler(this.heightNumeric_ValueChanged);
            // 
            // bombsNumeric
            // 
            this.bombsNumeric.Location = new System.Drawing.Point(94, 64);
            this.bombsNumeric.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.bombsNumeric.Name = "bombsNumeric";
            this.bombsNumeric.Size = new System.Drawing.Size(120, 20);
            this.bombsNumeric.TabIndex = 2;
            this.bombsNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.bombsNumeric.ValueChanged += new System.EventHandler(this.bombsNumeric_ValueChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widthLabel.Location = new System.Drawing.Point(12, 12);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(44, 17);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Width";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heightLabel.Location = new System.Drawing.Point(12, 38);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(49, 17);
            this.heightLabel.TabIndex = 4;
            this.heightLabel.Text = "Height";
            // 
            // bombsLabel
            // 
            this.bombsLabel.AutoSize = true;
            this.bombsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bombsLabel.Location = new System.Drawing.Point(12, 64);
            this.bombsLabel.Name = "bombsLabel";
            this.bombsLabel.Size = new System.Drawing.Size(51, 17);
            this.bombsLabel.TabIndex = 5;
            this.bombsLabel.Text = "Bombs";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(139, 90);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(12, 90);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 7;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 118);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.bombsLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.bombsNumeric);
            this.Controls.Add(this.heightNumeric);
            this.Controls.Add(this.widthNumeric);
            this.Name = "NewGameForm";
            this.Text = "NewGameForm";
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown widthNumeric;
        private System.Windows.Forms.NumericUpDown heightNumeric;
        private System.Windows.Forms.NumericUpDown bombsNumeric;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label bombsLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button newGameButton;
    }
}
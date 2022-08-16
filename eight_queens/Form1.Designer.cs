namespace eight_queens
{
    partial class Form1
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
            this.comboBoxAlgorithms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.solveBtn = new System.Windows.Forms.Button();
            this.saveResultBtn = new System.Windows.Forms.Button();
            this.statsData = new System.Windows.Forms.Button();
            this.boardPnl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // comboBoxAlgorithms
            // 
            this.comboBoxAlgorithms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAlgorithms.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgorithms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAlgorithms.FormattingEnabled = true;
            this.comboBoxAlgorithms.Items.AddRange(new object[] {
            "LDFS",
            "BFS",
            "IDS"});
            this.comboBoxAlgorithms.Location = new System.Drawing.Point(808, 160);
            this.comboBoxAlgorithms.MaxDropDownItems = 3;
            this.comboBoxAlgorithms.Name = "comboBoxAlgorithms";
            this.comboBoxAlgorithms.Size = new System.Drawing.Size(107, 33);
            this.comboBoxAlgorithms.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(808, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Алгоритм";
            // 
            // solveBtn
            // 
            this.solveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.solveBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.solveBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.solveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solveBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.solveBtn.Location = new System.Drawing.Point(781, 233);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(160, 44);
            this.solveBtn.TabIndex = 2;
            this.solveBtn.Text = "Розв\'язання";
            this.solveBtn.UseVisualStyleBackColor = false;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // saveResultBtn
            // 
            this.saveResultBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveResultBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.saveResultBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveResultBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveResultBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveResultBtn.Location = new System.Drawing.Point(775, 563);
            this.saveResultBtn.Name = "saveResultBtn";
            this.saveResultBtn.Size = new System.Drawing.Size(173, 55);
            this.saveResultBtn.TabIndex = 3;
            this.saveResultBtn.Text = "Записати результат у файл";
            this.saveResultBtn.UseVisualStyleBackColor = false;
            this.saveResultBtn.Click += new System.EventHandler(this.saveResultBtn_Click);
            // 
            // statsData
            // 
            this.statsData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statsData.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.statsData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statsData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsData.Location = new System.Drawing.Point(775, 494);
            this.statsData.Name = "statsData";
            this.statsData.Size = new System.Drawing.Size(173, 43);
            this.statsData.TabIndex = 4;
            this.statsData.Text = "Статистичні дані";
            this.statsData.UseVisualStyleBackColor = false;
            this.statsData.Click += new System.EventHandler(this.statsData_Click);
            // 
            // boardPnl
            // 
            this.boardPnl.Location = new System.Drawing.Point(5, 5);
            this.boardPnl.Name = "boardPnl";
            this.boardPnl.Size = new System.Drawing.Size(700, 700);
            this.boardPnl.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1016, 663);
            this.Controls.Add(this.boardPnl);
            this.Controls.Add(this.statsData);
            this.Controls.Add(this.saveResultBtn);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAlgorithms);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlgorithms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button solveBtn;
        private System.Windows.Forms.Button saveResultBtn;
        private System.Windows.Forms.Button statsData;
        private System.Windows.Forms.Panel boardPnl;
    }
}
﻿namespace CarReportSystem {
    partial class fmVersion {
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
            button1 = new Button();
            label1 = new Label();
            lbVersion = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(265, 178);
            button1.Name = "button1";
            button1.Size = new Size(79, 31);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("HGP創英角ｺﾞｼｯｸUB", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(22, 19);
            label1.Name = "label1";
            label1.Size = new Size(208, 19);
            label1.TabIndex = 1;
            label1.Text = "試乗ポート管理システム";
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Location = new Point(254, 89);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(47, 15);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Ver0.0.1";
           
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 221);
            Controls.Add(lbVersion);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label lbVersion;
    }
}
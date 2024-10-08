﻿namespace GADE6122DavidTristanPOE
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
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblLevelNumber = new System.Windows.Forms.Label();
            this.lblObjective = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblControls = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.Color.LightGreen;
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblDisplay.Location = new System.Drawing.Point(255, 111);
            this.lblDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(210, 362);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "label1";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLevelNumber
            // 
            this.lblLevelNumber.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelNumber.ForeColor = System.Drawing.Color.Gold;
            this.lblLevelNumber.Location = new System.Drawing.Point(251, 85);
            this.lblLevelNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLevelNumber.Name = "lblLevelNumber";
            this.lblLevelNumber.Size = new System.Drawing.Size(212, 24);
            this.lblLevelNumber.TabIndex = 1;
            this.lblLevelNumber.Text = "label1";
            this.lblLevelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblObjective
            // 
            this.lblObjective.AutoSize = true;
            this.lblObjective.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjective.Location = new System.Drawing.Point(63, 111);
            this.lblObjective.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObjective.Name = "lblObjective";
            this.lblObjective.Size = new System.Drawing.Size(188, 162);
            this.lblObjective.TabIndex = 2;
            this.lblObjective.Text = "Objective:\r\nGet the Hero to\r\nthe Level Exit by\r\nmoving through the\r\nEmpty Spaces " +
    "and\r\ndefeating Enemies.\r\nUse Health Pickup\r\nto heal lost hit\r\npoints.";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(469, 111);
            this.lblKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(238, 144);
            this.lblKey.TabIndex = 3;
            this.lblKey.Text = "Key:\r\n█ = Wall\r\n. = Empty Space\r\n▼ = Hero (Alive)\r\n▒ = Level Exit\r\n+ = Health Pic" +
    "kup\r\nϪ = Enemy Grunt (Alive)\r\nx = Enemy Grunt (Dead)";
            // 
            // lblControls
            // 
            this.lblControls.AutoSize = true;
            this.lblControls.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControls.Location = new System.Drawing.Point(63, 311);
            this.lblControls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblControls.Name = "lblControls";
            this.lblControls.Size = new System.Drawing.Size(168, 162);
            this.lblControls.TabIndex = 4;
            this.lblControls.Text = "Controls:\r\nW = Move Up\r\nA = Move Left\r\nS = Move Down\r\nD = Move Right\r\n↑ = Attack " +
    "Up\r\n← = Attack Left\r\n↓ = Attack Down\r\n→ = Attack Right";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHitPoints.ForeColor = System.Drawing.Color.Red;
            this.lblHitPoints.Location = new System.Drawing.Point(253, 473);
            this.lblHitPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(212, 24);
            this.lblHitPoints.TabIndex = 5;
            this.lblHitPoints.Text = "label1";
            this.lblHitPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(706, 547);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.lblControls);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblObjective);
            this.Controls.Add(this.lblLevelNumber);
            this.Controls.Add(this.lblDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dungeon Escape";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblLevelNumber;
        private System.Windows.Forms.Label lblObjective;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblControls;
        private System.Windows.Forms.Label lblHitPoints;
    }
}



namespace TLC_Scheduler
{
    partial class LaunchMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchMenu));
            this.titleLbl = new System.Windows.Forms.Label();
            this.scheduleBtn = new System.Windows.Forms.Button();
            this.addStudentsBtn = new System.Windows.Forms.Button();
            this.editStudentsBtn = new System.Windows.Forms.Button();
            this.editDeptBtn = new System.Windows.Forms.Button();
            this.delDeptBtn = new System.Windows.Forms.Button();
            this.openSchedule = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(12, 9);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(294, 37);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "{Department} Menu";
            this.titleLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // scheduleBtn
            // 
            this.scheduleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleBtn.Location = new System.Drawing.Point(143, 68);
            this.scheduleBtn.Name = "scheduleBtn";
            this.scheduleBtn.Size = new System.Drawing.Size(267, 80);
            this.scheduleBtn.TabIndex = 1;
            this.scheduleBtn.Text = "Create New Schedule";
            this.scheduleBtn.UseVisualStyleBackColor = true;
            this.scheduleBtn.Click += new System.EventHandler(this.scheduleBtn_Click);
            // 
            // addStudentsBtn
            // 
            this.addStudentsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudentsBtn.Location = new System.Drawing.Point(12, 68);
            this.addStudentsBtn.Name = "addStudentsBtn";
            this.addStudentsBtn.Size = new System.Drawing.Size(125, 80);
            this.addStudentsBtn.TabIndex = 2;
            this.addStudentsBtn.Text = "Add Students";
            this.addStudentsBtn.UseVisualStyleBackColor = true;
            this.addStudentsBtn.Click += new System.EventHandler(this.addStudentsBtn_Click);
            // 
            // editStudentsBtn
            // 
            this.editStudentsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editStudentsBtn.Location = new System.Drawing.Point(12, 154);
            this.editStudentsBtn.Name = "editStudentsBtn";
            this.editStudentsBtn.Size = new System.Drawing.Size(125, 80);
            this.editStudentsBtn.TabIndex = 3;
            this.editStudentsBtn.Text = "View/Edit Students";
            this.editStudentsBtn.UseVisualStyleBackColor = true;
            this.editStudentsBtn.Click += new System.EventHandler(this.editStudentsBtn_Click);
            // 
            // editDeptBtn
            // 
            this.editDeptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDeptBtn.Location = new System.Drawing.Point(416, 68);
            this.editDeptBtn.Name = "editDeptBtn";
            this.editDeptBtn.Size = new System.Drawing.Size(129, 80);
            this.editDeptBtn.TabIndex = 4;
            this.editDeptBtn.Text = "Edit Dept";
            this.editDeptBtn.UseVisualStyleBackColor = true;
            this.editDeptBtn.Click += new System.EventHandler(this.editDeptBtn_Click);
            // 
            // delDeptBtn
            // 
            this.delDeptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delDeptBtn.Location = new System.Drawing.Point(417, 154);
            this.delDeptBtn.Name = "delDeptBtn";
            this.delDeptBtn.Size = new System.Drawing.Size(129, 80);
            this.delDeptBtn.TabIndex = 5;
            this.delDeptBtn.Text = "Delete Dept";
            this.delDeptBtn.UseVisualStyleBackColor = true;
            this.delDeptBtn.Click += new System.EventHandler(this.delDeptBtn_Click);
            // 
            // openSchedule
            // 
            this.openSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openSchedule.Location = new System.Drawing.Point(144, 154);
            this.openSchedule.Name = "openSchedule";
            this.openSchedule.Size = new System.Drawing.Size(267, 80);
            this.openSchedule.TabIndex = 6;
            this.openSchedule.Text = "Open Schedule";
            this.openSchedule.UseVisualStyleBackColor = true;
            this.openSchedule.Click += new System.EventHandler(this.openSchedule_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.Location = new System.Drawing.Point(12, 240);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(533, 80);
            this.homeBtn.TabIndex = 7;
            this.homeBtn.Text = "Go Home";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // LaunchMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 325);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.openSchedule);
            this.Controls.Add(this.delDeptBtn);
            this.Controls.Add(this.editDeptBtn);
            this.Controls.Add(this.editStudentsBtn);
            this.Controls.Add(this.addStudentsBtn);
            this.Controls.Add(this.scheduleBtn);
            this.Controls.Add(this.titleLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LaunchMenu";
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaunchMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Button scheduleBtn;
        private System.Windows.Forms.Button addStudentsBtn;
        private System.Windows.Forms.Button editStudentsBtn;
        private System.Windows.Forms.Button editDeptBtn;
        private System.Windows.Forms.Button delDeptBtn;
        private System.Windows.Forms.Button openSchedule;
        private System.Windows.Forms.Button homeBtn;
    }
}
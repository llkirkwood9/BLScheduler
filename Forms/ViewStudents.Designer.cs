
namespace TLC_Scheduler
{
    partial class ViewStudents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewStudents));
            this.studentList = new System.Windows.Forms.ListBox();
            this.editBtn = new System.Windows.Forms.Button();
            this.deptLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // studentList
            // 
            this.studentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentList.FormattingEnabled = true;
            this.studentList.ItemHeight = 29;
            this.studentList.Location = new System.Drawing.Point(6, 64);
            this.studentList.Margin = new System.Windows.Forms.Padding(2);
            this.studentList.Name = "studentList";
            this.studentList.Size = new System.Drawing.Size(536, 323);
            this.studentList.TabIndex = 0;
            this.studentList.DoubleClick += new System.EventHandler(this.editBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(6, 421);
            this.editBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(534, 96);
            this.editBtn.TabIndex = 1;
            this.editBtn.Text = "Edit Student";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deptLbl
            // 
            this.deptLbl.AutoSize = true;
            this.deptLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptLbl.Location = new System.Drawing.Point(6, 12);
            this.deptLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deptLbl.Name = "deptLbl";
            this.deptLbl.Size = new System.Drawing.Size(341, 37);
            this.deptLbl.TabIndex = 2;
            this.deptLbl.Text = "{Department} Students";
            // 
            // ViewStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 552);
            this.Controls.Add(this.deptLbl);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.studentList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewStudents";
            this.Text = "View Students";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox studentList;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label deptLbl;
    }
}
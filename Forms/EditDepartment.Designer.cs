
namespace TLC_Scheduler.Forms
{
    partial class EditDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDepartment));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startTime2 = new System.Windows.Forms.RadioButton();
            this.startTime1 = new System.Windows.Forms.RadioButton();
            this.createDeptBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startTime2);
            this.groupBox1.Controls.Add(this.startTime1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 164);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Start Time";
            // 
            // startTime2
            // 
            this.startTime2.AutoSize = true;
            this.startTime2.Location = new System.Drawing.Point(7, 67);
            this.startTime2.Name = "startTime2";
            this.startTime2.Size = new System.Drawing.Size(107, 29);
            this.startTime2.TabIndex = 1;
            this.startTime2.TabStop = true;
            this.startTime2.Text = "8:00 am";
            this.startTime2.UseVisualStyleBackColor = true;
            // 
            // startTime1
            // 
            this.startTime1.AutoSize = true;
            this.startTime1.Location = new System.Drawing.Point(7, 31);
            this.startTime1.Name = "startTime1";
            this.startTime1.Size = new System.Drawing.Size(107, 29);
            this.startTime1.TabIndex = 0;
            this.startTime1.TabStop = true;
            this.startTime1.Text = "7:30 am";
            this.startTime1.UseVisualStyleBackColor = true;
            // 
            // createDeptBtn
            // 
            this.createDeptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDeptBtn.Location = new System.Drawing.Point(19, 281);
            this.createDeptBtn.Name = "createDeptBtn";
            this.createDeptBtn.Size = new System.Drawing.Size(501, 57);
            this.createDeptBtn.TabIndex = 9;
            this.createDeptBtn.Text = "Edit Department";
            this.createDeptBtn.UseVisualStyleBackColor = true;
            this.createDeptBtn.Click += new System.EventHandler(this.createDeptBtn_Click);
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.Location = new System.Drawing.Point(211, 63);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(309, 31);
            this.nameBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Department Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "Edit Deparment";
            // 
            // EditDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 354);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.createDeptBtn);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditDepartment";
            this.Text = "Edit Department";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton startTime2;
        private System.Windows.Forms.RadioButton startTime1;
        private System.Windows.Forms.Button createDeptBtn;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
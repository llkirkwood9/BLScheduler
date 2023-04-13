
namespace TLC_Scheduler.Forms
{
    partial class EditStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditStudent));
            this.deptLbl = new System.Windows.Forms.Label();
            this.editStudentBtn = new System.Windows.Forms.Button();
            this.pathLbl = new System.Windows.Forms.Label();
            this.fileSelectBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delStudentBtn = new System.Windows.Forms.Button();
            this.currentColorLbl = new System.Windows.Forms.Label();
            this.chooseColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deptLbl
            // 
            this.deptLbl.AutoSize = true;
            this.deptLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptLbl.Location = new System.Drawing.Point(19, 352);
            this.deptLbl.Name = "deptLbl";
            this.deptLbl.Size = new System.Drawing.Size(102, 20);
            this.deptLbl.TabIndex = 21;
            this.deptLbl.Text = "Department: ";
            // 
            // editStudentBtn
            // 
            this.editStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editStudentBtn.Location = new System.Drawing.Point(19, 254);
            this.editStudentBtn.Name = "editStudentBtn";
            this.editStudentBtn.Size = new System.Drawing.Size(531, 85);
            this.editStudentBtn.TabIndex = 20;
            this.editStudentBtn.Text = "Edit Student";
            this.editStudentBtn.UseVisualStyleBackColor = true;
            this.editStudentBtn.Click += new System.EventHandler(this.editStudentBtn_Click);
            // 
            // pathLbl
            // 
            this.pathLbl.AutoSize = true;
            this.pathLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLbl.Location = new System.Drawing.Point(134, 205);
            this.pathLbl.Name = "pathLbl";
            this.pathLbl.Size = new System.Drawing.Size(167, 20);
            this.pathLbl.TabIndex = 19;
            this.pathLbl.Text = "No Schedule Selected";
            // 
            // fileSelectBtn
            // 
            this.fileSelectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSelectBtn.Location = new System.Drawing.Point(17, 188);
            this.fileSelectBtn.Name = "fileSelectBtn";
            this.fileSelectBtn.Size = new System.Drawing.Size(111, 59);
            this.fileSelectBtn.TabIndex = 18;
            this.fileSelectBtn.Text = "Choose Schedule";
            this.fileSelectBtn.UseVisualStyleBackColor = true;
            this.fileSelectBtn.Click += new System.EventHandler(this.fileSelectBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Email";
            // 
            // emailBox
            // 
            this.emailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailBox.Location = new System.Drawing.Point(134, 145);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(416, 31);
            this.emailBox.TabIndex = 16;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameBox.Location = new System.Drawing.Point(134, 107);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(416, 31);
            this.lastNameBox.TabIndex = 15;
            // 
            // firstNameBox
            // 
            this.firstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameBox.Location = new System.Drawing.Point(134, 69);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(416, 31);
            this.firstNameBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 42);
            this.label1.TabIndex = 11;
            this.label1.Text = "Edit Student";
            // 
            // delStudentBtn
            // 
            this.delStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delStudentBtn.Location = new System.Drawing.Point(556, 254);
            this.delStudentBtn.Name = "delStudentBtn";
            this.delStudentBtn.Size = new System.Drawing.Size(209, 85);
            this.delStudentBtn.TabIndex = 22;
            this.delStudentBtn.Text = "Delete Student";
            this.delStudentBtn.UseVisualStyleBackColor = true;
            this.delStudentBtn.Click += new System.EventHandler(this.delStudentBtn_Click);
            // 
            // currentColorLbl
            // 
            this.currentColorLbl.AutoSize = true;
            this.currentColorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentColorLbl.Location = new System.Drawing.Point(556, 145);
            this.currentColorLbl.Name = "currentColorLbl";
            this.currentColorLbl.Size = new System.Drawing.Size(140, 25);
            this.currentColorLbl.TabIndex = 24;
            this.currentColorLbl.Text = "Current Color";
            // 
            // chooseColor
            // 
            this.chooseColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseColor.Location = new System.Drawing.Point(556, 69);
            this.chooseColor.Name = "chooseColor";
            this.chooseColor.Size = new System.Drawing.Size(132, 69);
            this.chooseColor.TabIndex = 23;
            this.chooseColor.Text = "Choose Color";
            this.chooseColor.UseVisualStyleBackColor = true;
            this.chooseColor.Click += new System.EventHandler(this.chooseColor_Click);
            // 
            // EditStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 394);
            this.Controls.Add(this.currentColorLbl);
            this.Controls.Add(this.chooseColor);
            this.Controls.Add(this.delStudentBtn);
            this.Controls.Add(this.deptLbl);
            this.Controls.Add(this.editStudentBtn);
            this.Controls.Add(this.pathLbl);
            this.Controls.Add(this.fileSelectBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditStudent";
            this.Text = "Edit Student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deptLbl;
        private System.Windows.Forms.Button editStudentBtn;
        private System.Windows.Forms.Label pathLbl;
        private System.Windows.Forms.Button fileSelectBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delStudentBtn;
        private System.Windows.Forms.Label currentColorLbl;
        private System.Windows.Forms.Button chooseColor;
    }
}
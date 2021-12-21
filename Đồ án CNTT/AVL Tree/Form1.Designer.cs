namespace AVL_Tree
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
            this.components = new System.ComponentModel.Container();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.Find = new System.Windows.Forms.Button();
            this.InOrder = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PostOrder = new System.Windows.Forms.Button();
            this.PreOrder = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(4, 58);
            this.valueBox.Margin = new System.Windows.Forms.Padding(4);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(164, 22);
            this.valueBox.TabIndex = 0;
            // 
            // Find
            // 
            this.Find.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Find.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Find.Image = global::AVL_Tree.Properties.Resources.find;
            this.Find.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Find.Location = new System.Drawing.Point(392, 23);
            this.Find.Margin = new System.Windows.Forms.Padding(4);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(100, 92);
            this.Find.TabIndex = 3;
            this.Find.Text = "Find";
            this.Find.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // InOrder
            // 
            this.InOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.InOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InOrder.Image = global::AVL_Tree.Properties.Resources.InOrder;
            this.InOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InOrder.Location = new System.Drawing.Point(4, 22);
            this.InOrder.Margin = new System.Windows.Forms.Padding(4);
            this.InOrder.Name = "InOrder";
            this.InOrder.Size = new System.Drawing.Size(128, 93);
            this.InOrder.TabIndex = 4;
            this.InOrder.Text = "InOrder";
            this.InOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InOrder.UseVisualStyleBackColor = true;
            this.InOrder.Click += new System.EventHandler(this.InOrder_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(941, 778);
            this.Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(85, 29);
            this.Status.TabIndex = 6;
            this.Status.Text = "Status";
            this.Status.TextChanged += new System.EventHandler(this.Status_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 7000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(3, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(244, 24);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quay về màn hình chính ";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(3, 77);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(190, 24);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Binary Search Tree";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aqua;
            this.panel1.Controls.Add(this.valueBox);
            this.panel1.Controls.Add(this.InsertBtn);
            this.panel1.Controls.Add(this.deleteBtn);
            this.panel1.Controls.Add(this.Find);
            this.panel1.Location = new System.Drawing.Point(16, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 136);
            this.panel1.TabIndex = 22;
            // 
            // InsertBtn
            // 
            this.InsertBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.InsertBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertBtn.Image = global::AVL_Tree.Properties.Resources.insert;
            this.InsertBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InsertBtn.Location = new System.Drawing.Point(176, 22);
            this.InsertBtn.Margin = new System.Windows.Forms.Padding(4);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(100, 93);
            this.InsertBtn.TabIndex = 1;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::AVL_Tree.Properties.Resources.delete;
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteBtn.Location = new System.Drawing.Point(284, 22);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(100, 93);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(16, 155);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1821, 723);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Fuchsia;
            this.panel2.Controls.Add(this.PostOrder);
            this.panel2.Controls.Add(this.PreOrder);
            this.panel2.Controls.Add(this.InOrder);
            this.panel2.Location = new System.Drawing.Point(529, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 134);
            this.panel2.TabIndex = 23;
            // 
            // PostOrder
            // 
            this.PostOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.PostOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PostOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostOrder.Image = global::AVL_Tree.Properties.Resources.PostOrder;
            this.PostOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PostOrder.Location = new System.Drawing.Point(281, 22);
            this.PostOrder.Margin = new System.Windows.Forms.Padding(4);
            this.PostOrder.Name = "PostOrder";
            this.PostOrder.Size = new System.Drawing.Size(139, 94);
            this.PostOrder.TabIndex = 6;
            this.PostOrder.Text = "PostOrder";
            this.PostOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PostOrder.UseVisualStyleBackColor = true;
            this.PostOrder.Click += new System.EventHandler(this.PostOrder_Click);
            // 
            // PreOrder
            // 
            this.PreOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.PreOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreOrder.Image = global::AVL_Tree.Properties.Resources.PreOrder;
            this.PreOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PreOrder.Location = new System.Drawing.Point(140, 22);
            this.PreOrder.Margin = new System.Windows.Forms.Padding(4);
            this.PreOrder.Name = "PreOrder";
            this.PreOrder.Size = new System.Drawing.Size(133, 94);
            this.PreOrder.TabIndex = 5;
            this.PreOrder.Text = "PreOrder";
            this.PreOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreOrder.UseVisualStyleBackColor = true;
            this.PreOrder.Click += new System.EventHandler(this.PreOrder_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.linkLabel2);
            this.panel3.Location = new System.Drawing.Point(956, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 134);
            this.panel3.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1305, 880);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AVL Tree";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox valueBox;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Button InOrder;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label Status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PostOrder;
        private System.Windows.Forms.Button PreOrder;
        private System.Windows.Forms.Panel panel3;
    }
}


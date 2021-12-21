using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using DoAnCK_BinTree;
using AVL_Tree;

namespace DoAnCNTT_BST
{
    public partial class Form2 : Form
    {

        Binary_Search_Tree Btree = new Binary_Search_Tree(); //tạo cây mới
        Pen line = new Pen(Brushes.Black, (float)3.5); //tạo bút
        private const int nodeSize = 40; //kích cỡ node
        private string info = string.Empty; //thông tin project
        int[] NUM = new int[1000]; //mảng chứa data đã có trong cây
        int nNum = 0;
        Random random = new Random();
        public int NodeSize
        {
            get { return nodeSize; }
        }
        public Form2()
        {
            InitializeComponent();
            info += "--------=====||_Binary_Search_Tree_Demo_Project_||=====--------";
            info += "\n - 19110314 Doan Quoc Viet";
            info += "\n - 19110019 Nguyen Le Bao Thanh";
            info += "\n\n|| Nodes: The total number of nodes in the tree";
            info += "\n|| Max, Min: Range for each Node's value";
            Addtxt.Focus();
            line.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AddBt.Focus();
        }
        #region Button_Interact
        private void InfoLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show(info, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async void AddBt_Click(object sender, EventArgs e)
        {
            try
            {
                int data = Int32.Parse(Addtxt.Text);

                Tree_Node tmp = new Tree_Node();
                tmp = Btree.Root; //lấy tmp vì ref không dùng với propertise

                int canAdd = 0;
                tmp.themPhanTu(ref tmp, data, ref canAdd);

                if (canAdd == 1) //data không có trong cây
                {
                    NUM[nNum++] = data; //lưu data để khi add random ko bị lặp

                    Btree.TotalNodes++;
                    totalNodesLbl.Text = $"Total nodes: {Btree.TotalNodes}";

                    int xCoor = 0;
                    SetToaDoNode(tmp, ref xCoor);

                    treeArea.Controls.Clear(); //xóa label
                    treeArea.Invalidate(); //xóa và vẽ lại arrow

                    VeCay(tmp);
                }

            }
            catch (FormatException)
            {
                Addtxt.Clear();
                Addtxt.BackColor = System.Drawing.Color.Red;
                await Task.Delay(50);
                Addtxt.BackColor = System.Drawing.Color.DarkGreen;
                Addtxt.Focus();
            }
            catch (Exception) //bắt lỗi để không bị out chương trình
            {
                clearBt.PerformClick();
                MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Addtxt.Clear();
            Addtxt.Focus();
        }
        private void RandAddBt_Click(object sender, EventArgs e)
        {
            try
            {
                int max = Convert.ToInt32(Math.Round(Maxtxt.Value, 0)) + 1;
                int min = Convert.ToInt32(Math.Round(Mintxt.Value, 0));

                //tạo data ko lặp
                int data = random.Next(min, max);
                while (NUM.Contains(data)) //khi data đã có rồi thì random lại
                {
                    if (min > max - 1)
                    {
                        MessageBox.Show("Min is bigger than Max!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Btree.TotalNodes >= max - min)
                    {
                        MessageBox.Show("Increase Max value to perform random add!", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    data = random.Next(min, max);
                }
                NUM[nNum++] = data; //thêm data để lần sau xét random ko bị lặp

                Tree_Node tmp = new Tree_Node();
                tmp = Btree.Root;

                int canAdd = 0;
                tmp.themPhanTu(ref tmp, data, ref canAdd);

                if (canAdd == 1)
                {
                    Btree.TotalNodes++;
                    totalNodesLbl.Text = $"Total nodes: {Btree.TotalNodes}";

                    int xCoor = 0;
                    SetToaDoNode(tmp, ref xCoor);

                    treeArea.Controls.Clear();
                    treeArea.Invalidate();

                    VeCay(tmp);
                }
            }
            catch (Exception) //bắt lỗi để không bị out chương trình
            {
                clearBt.PerformClick();
                MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void clearBt_Click(object sender, EventArgs e)
        {
            treeArea.Controls.Clear();
            treeArea.Invalidate();
            Btree = new Binary_Search_Tree();
            NUM = new int[1000];
            nNum = 0;
            totalNodesLbl.Text = $"Total nodes: {Btree.TotalNodes}";
            Resulttxt.Clear();
        }
        private async void DelBt_Click(object sender, EventArgs e)
        {
            if (Btree.TotalNodes == 0)
            {
                MessageBox.Show("Tree is empty!", "Invalid delele.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int data = Int32.Parse(Deltxt.Text);

                    Tree_Node tmp = new Tree_Node();
                    tmp = Btree.Root;

                    int canDel = 0;
                    tmp.xoaPhanTu(ref tmp, ref canDel, data);

                    Btree.Root = tmp;

                    if (canDel > 0)
                    {
                        Btree.TotalNodes--;
                        totalNodesLbl.Text = $"Total nodes: {Btree.TotalNodes}";

                        treeArea.Controls.Clear();
                        treeArea.Invalidate();

                        if (canDel != 2) //nút cần xóa không phải root
                        {
                            for(int i = 0; i < nNum; i++)
                            {
                                if (NUM[i] == data)
                                {
                                    for(int j = i; j < nNum - 1; j++)//Xóa các phần tử đã có trong NUM[]
                                    {
                                        NUM[j] = NUM[j+1];
                                    }
                                    nNum--;
                                    break;
                                }
                            }
                            int xCoor = 0;
                            SetToaDoNode(tmp, ref xCoor);
                            VeCay(tmp);
                        }
                        else
                        {
                            //nút cần xóa là gốc và chỉ còn nút đó nên tạo mới cây
                            Btree = new Binary_Search_Tree();
                            NUM = new int[1000];
                            nNum = 0;
                        }
                    }
                }
                catch (FormatException)
                {
                    Deltxt.Clear();
                    Deltxt.BackColor = System.Drawing.Color.Red;
                    await Task.Delay(50);
                    Deltxt.BackColor = System.Drawing.Color.DarkGreen;
                    Deltxt.Focus();
                }
                catch (Exception) //bắt lỗi để không bị out chương trình
                {
                    clearBt.PerformClick();
                    MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Deltxt.Clear();
            Deltxt.Focus();
        }
        private async void FindBt_Click(object sender, EventArgs e)
        {
            if (Btree.TotalNodes == 0)
            {
                MessageBox.Show("Tree is empty!", "Invalid find.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int data = Int32.Parse(Findtxt.Text); //nếu chuyển thành công thì thực hiện refresh cây

                    Btree.Root.timKiem(Btree.Root, data, this);
                }
                catch (FormatException)
                {
                    Findtxt.Clear();
                    Findtxt.BackColor = System.Drawing.Color.Red;
                    await Task.Delay(50);
                    Findtxt.BackColor = System.Drawing.Color.DarkGreen;
                    Findtxt.Focus();
                }
                catch (Exception) //bắt lỗi để không bị out chương trình
                {
                    clearBt.PerformClick();
                    MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Findtxt.Clear();
            Findtxt.Focus();
        }
        private void RandTreeBt_Click(object sender, EventArgs e)
        {
            try
            {
                int nodes = Convert.ToInt32(Math.Round(Nodetxt.Value, 0));
                int max = Convert.ToInt32(Math.Round(Maxtxt.Value, 0)) + 1;
                int min = Convert.ToInt32(Math.Round(Mintxt.Value, 0));

                if (min > max - 1)
                {
                    MessageBox.Show("Min is bigger than Max!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nodes >= max - min + 1) //số lượng node vượt quá phạm vi max min
                {
                    MessageBox.Show("Number of nodes is over min-max range!", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Btree = new Binary_Search_Tree();

                treeArea.Controls.Clear();
                treeArea.Invalidate();

                Tree_Node tmp = new Tree_Node();
                tmp = Btree.Root;

                NUM = new int[1000];
                nNum = 0;

                for (int i = 0; i < nodes; i++)
                {
                    int data = random.Next(min, max);
                    while (NUM.Contains(data))
                    {
                        data = random.Next(min, max);
                    }
                    NUM[nNum++] = data;

                    tmp.themPhanTu(ref tmp, data);
                    Btree.TotalNodes++;
                }

                totalNodesLbl.Text = $"Total nodes: {Btree.TotalNodes}";

                int xCoor = 0;
                SetToaDoNode(tmp, ref xCoor);
                VeCay(tmp);
            }
            catch (Exception) //bắt lỗi để không bị out chương trình
            {
                clearBt.PerformClick();
                MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreSBt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btree.TotalNodes != 0) //cây không rỗng
                {
                    Resulttxt.Clear();
                    int delay; //tốc độ animation
                    if (Btree.TotalNodes >= 20)
                        delay = 100;
                    else
                        delay = 400;
                    Btree.Root.PreOrderS(Btree.Root, this, delay);
                    Resulttxt.Text = Btree.Root.ResultText;
                    Btree.Root.ResultText = "";
                    treeArea.Invalidate();
                }
                else
                {
                    MessageBox.Show("Tree is empty!", "Invalid search.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) //bắt lỗi để không bị out chương trình
            {
                clearBt.PerformClick();
                MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PosSBt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btree.TotalNodes != 0) // cây không rỗng
                {
                    Resulttxt.Clear();
                    int delay; //tốc độ animation
                    if (Btree.TotalNodes >= 20)
                        delay = 100;
                    else
                        delay = 400;
                    Btree.Root.PostOrderS(Btree.Root, this, delay);
                    Resulttxt.Text = Btree.Root.ResultText;
                    Btree.Root.ResultText = "";
                    treeArea.Invalidate();
                }
                else
                {
                    MessageBox.Show("Tree is empty!", "Invalid delele.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) //bắt lỗi để không bị out chương trình
            {
                clearBt.PerformClick();
                MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InSBt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btree.TotalNodes != 0) //cây không rỗng
                {
                    Resulttxt.Clear();
                    int delay; //tốc độ animation
                    if (Btree.TotalNodes >= 20)
                        delay = 100;
                    else
                        delay = 400;
                    Btree.Root.InOrderS(Btree.Root, this, delay);
                    Resulttxt.Text = Btree.Root.ResultText;
                    Btree.Root.ResultText = "";
                    treeArea.Invalidate();
                }
                else
                {
                    MessageBox.Show("Tree is empty!", "Invalid delele.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) //bắt lỗi để không bị out chương trình
            {
                clearBt.PerformClick();
                MessageBox.Show("Something wrong just happenned!\nThe application has been refreshed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TextBox_Interact
        private void Addtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddBt.PerformClick();
            }
        }
        private void Deltxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DelBt.PerformClick();
            }
        }
        private void Findtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindBt.PerformClick();
            }
        }
        private void Addtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(Addtxt.Text);
                if (x <= 0)
                    Addtxt.Text = "1";
                else if (x >= 1000)
                    Addtxt.Text = "999";
            }
            catch (FormatException)
            {
            }
        }
        #endregion

        #region Draw_Node
        private void VeArrow(Tree_Node tree)
        {
            if (tree != null)
            {
                if (tree.Level != 0)
                {
                    //set toa do khi scroll
                    int x1 = (tree.ToaDoX + nodeSize / 2) - treeArea.HorizontalScroll.Value;
                    int y1 = tree.ToaDoY - treeArea.VerticalScroll.Value;
                    int x2 = (tree.Dad.ToaDoX + nodeSize / 2) - treeArea.HorizontalScroll.Value;
                    int y2 = (tree.Dad.ToaDoY + nodeSize - 1) - treeArea.VerticalScroll.Value;
                    Graphics g = treeArea.CreateGraphics();
                    g.DrawLine(line, x1, y1, x2, y2);
                }

                if (tree.Left != null)
                {
                    VeArrow(tree.Left);
                }
                if (tree.Right != null)
                {
                    VeArrow(tree.Right);
                }
            }
        }
        private void VeCay(Tree_Node tree)
        {
            Label lbl = TaoHinhAnhNode(tree);
            treeArea.Controls.Add(lbl);

            if (tree.Left != null)
            {
                VeCay(tree.Left);
            }
            if (tree.Right != null)
            {
                VeCay(tree.Right);
            }

        }
        private Label TaoHinhAnhNode(Tree_Node tmp)
        {
            Label lbl = new Label();
            lbl.Text = tmp.Data.ToString();
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = System.Drawing.Color.Black;
            lbl.Location = new System.Drawing.Point(tmp.ToaDoX, tmp.ToaDoY);
            lbl.BackColor = System.Drawing.Color.Cyan;
            lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl.Font = new System.Drawing.Font("Unispace", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.Size = new System.Drawing.Size(nodeSize, nodeSize);
            return lbl;
        }
        private void SetToaDoNode(Tree_Node tree, ref int xCoor)
        {
            if (tree.Left != null)
                SetToaDoNode(tree.Left, ref xCoor);

            tree.ToaDoX = Btree.RootTreeX + xCoor * (nodeSize + 15);
            tree.ToaDoY = Btree.RootTreeY + tree.Level * (nodeSize + 20);
            xCoor++;

            if (tree.Right != null)
                SetToaDoNode(tree.Right, ref xCoor);

        }
        private void treeArea_Paint(object sender, PaintEventArgs e)
        {
            VeArrow(Btree.Root);
        }
        private void treeArea_Scroll(object sender, ScrollEventArgs e)
        {
            treeArea.Invalidate();
        }
        #endregion

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainform f = new mainform();
            f.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}

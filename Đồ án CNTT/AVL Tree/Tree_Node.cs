using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace DoAnCNTT_BST
{
    class Tree_Node
    {

        int data;  // giá trị của node hiện tại
        int level; // bậc của node hiện tại
        Tree_Node left; // node con trái của node hiện tại
        Tree_Node right;// node con phải của node hiện tại
        Tree_Node dad; // node cha của node hiện tại

        // vị trí của node hiện tại để biểu diễn
        int toaDoX;
        int toaDoY;
        string resultText = "";

        #region Properties
        public Tree_Node Left
        {
            get { return left; }
            set { left = value; }
        }
        public Tree_Node Right
        {
            get { return right; }
            set { right = value; }
        }
        public Tree_Node Dad
        {
            get { return dad; }
            set { dad = value; }
        }
        public int Data
        {
            get { return data; }
            set { this.data = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int ToaDoX
        {
            get { return toaDoX; }
            set { toaDoX = value; }
        }
        public int ToaDoY
        {
            get { return toaDoY; }
            set { toaDoY = value; }
        }
        public string ResultText
        {
            get { return resultText; }
            set { resultText = value; }
        }
        #endregion
        public Tree_Node()
        {
        }
        public Tree_Node(Tree_Node tree)
        {
            data = 0; // giá trị của node hiện tại là 0
            dad = tree; // gán node cha của node đó = tree
            level = tree.level + 1; // tăng bậc của node hiện tại lên 1
        }
        public void themPhanTu(ref Tree_Node tree, int data, ref int canAdd)
        {
            if (tree.data == 0)
            {
                tree.data = data;
                canAdd = 1;
            }
            else  //data của tree đã có giá trị nên duyệt xuống các cây con
            {
                if (data < tree.data)  //đi qua trái
                {
                    if (tree.left == null) //khởi tạo node con trái
                    {
                        Tree_Node tmp = new Tree_Node(tree);
                        tree.left = tmp;
                    }
                    themPhanTu(ref tree.left, data, ref canAdd);
                }
                else if (data > tree.data)  //đi qua phải
                {
                    if (tree.right == null) //khởi tạo node con phải
                    {
                        Tree_Node tmp = new Tree_Node(tree);
                        tree.right = tmp;
                    }
                    themPhanTu(ref tree.right, data, ref canAdd);
                }
                else  //data == tree.data
                {
                    canAdd = 0;
                    MessageBox.Show($"Node { data } already in tree!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        } //của add button
        public void themPhanTu(ref Tree_Node tree, int data)
        {
            if (tree.data == 0)
            {
                tree.data = data;
            }
            else  //data của tree đã có giá trị nên duyệt xuống các cây con
            {
                if (data < tree.data)  //đi qua trái
                {
                    if (tree.left == null) //khởi tạo node con trái
                    {
                        Tree_Node tmp = new Tree_Node(tree);
                        tree.left = tmp;
                    }
                    themPhanTu(ref tree.left, data);
                }
                else if (data > tree.data)  //đi qua phải
                {
                    if (tree.right == null) //khởi tạo node con phải
                    {
                        Tree_Node tmp = new Tree_Node(tree);
                        tree.right = tmp;
                    }
                    themPhanTu(ref tree.right, data);
                }
            }
        } //của random new tree button
        public async void timKiem(Tree_Node tree, int data, Form2 form1)
        {
            if (tree == null) // không tìm thấy
            {
                MessageBox.Show($"Tree don't have node { data }", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (tree.data != data) // chưa tìm thấy
                {
                    TaoKhungNode(tree, Color.Red, form1);
                    //form1.treeArea.Controls.Add(lbl);
                    await Task.Delay(500);
                }
                else // tìm thấy
                {
                    TaoKhungNode(tree, Color.Green, form1);
                    //form1.treeArea.Controls.Add(lbl);
                    var result = MessageBox.Show($"Found node {data}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(result == DialogResult.OK)
                    {
                        form1.treeArea.Invalidate();
                    }
                }
                if (data < tree.data) // nếu dữ liệu cần tìm nhỏ hơn dữ liệu nút đang xét
                {
                    timKiem(tree.left, data, form1);
                }

                else if (data > tree.data) // nếu dữ liệu cần tìm lớn hơn dữ liệu nút đang xét
                {
                    timKiem(tree.right, data, form1);
                }
            }
        }
        public void xoaPhanTu(ref Tree_Node tree, ref int canDel, int data)
        {
            if (tree == null)
            {
                MessageBox.Show($"Tree don't have node { data } to delete!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (data < tree.data) // đi tìm nút cần xóa
                {
                    xoaPhanTu(ref tree.left, ref canDel, data);
                }

                else if (data > tree.data) // đi tìm nút cần xóa
                {
                    xoaPhanTu(ref tree.right, ref canDel, data);
                }

                else  // tìm thấy nút cần xóa
                {
                    if (tree.left == null && tree.right == null) //nút cần xóa là lá
                    {
                        if (tree.level != 0) //không phải root
                        {
                            if (tree.dad.left != null && tree.dad.left.data == tree.data) //kiểm tra tree là con phải hay con trái của tree.dad
                                tree.dad.left = null;
                            else
                                tree.dad.right = null;
                        }
                        else //là root
                        {
                            canDel = 2;
                            return;
                        }
                        canDel = 1;
                    }
                    else if (tree.left == null)  // nút cần xóa chỉ có nút phải
                    {
                        if (tree.level != 0) //không phải root
                        {
                            tree.right.dad = tree.dad; //chuyển cha của nút phải thành cha của nút hiện tại

                            if (tree.dad.left != null && tree.dad.left.data == tree.data) //kiểm tra tree là con phải hay con trái của tree.dad
                                tree.dad.left = tree.right;
                            else
                                tree.dad.right = tree.right;
                        }
                        else //là root
                        {
                            tree = tree.right;
                            tree.dad = null; //tree mới là root nên không có dad
                            tree.level = 0;
                        }

                        correctLevel(ref tree);
                        canDel = 1;
                    }
                    else if (tree.right == null)  // nút cần xóa chỉ có nút trái
                    {
                        if (tree.level != 0) //không phải root
                        {
                            tree.left.dad = tree.dad; //phải làm trước if dưới

                            if (tree.dad.left != null && tree.dad.left.data == tree.data) //kiểm tra tree là con phải hay con trái của tree.dad
                                tree.dad.left = tree.left;
                            else
                                tree.dad.right = tree.left;
                        }
                        else
                        {
                            tree = tree.left;
                            tree.dad = null; //tree mới là root nên không có dad
                            tree.level = 0;
                        }

                        correctLevel(ref tree);
                        canDel = 1;
                    }
                    else  // nút cần xóa có cả nút con trái và phải thì thay nút cần xóa bằng nút trái nhất bên phải
                    {
                        Tree_Node tmp = tree.right; // sang phải 1 lần

                        if (tmp.left == null)
                        {
                            tree.data = tmp.data;

                            if (tmp.right == null)
                                tree.right = null;
                            else
                            {
                                tmp.right.dad = tree;
                                tree.right = tmp.right;
                            }

                            correctLevel(ref tree);
                        }
                        else
                        {
                            while (tmp.left != null) // đi tiếp tục sang trái
                            {
                                tmp = tmp.left;
                            }
                            tree.data = tmp.data;

                            if (tmp.right != null) // nút trái nhất có nút phải
                            {
                                tmp.right.dad = tmp.dad;
                                tmp.dad.left = tmp.right;
                                correctLevel(ref tmp.right);
                            }
                            else // nút trái nhất không có nút phải
                            {
                                tmp.dad.left = null;
                            }
                        }
                        canDel = 1;
                    }
                }
            }
        }
        public void PreOrderS(Tree_Node tree, Form2 form1, int delay) // duyệt trước
        {
            if (tree != null)
            {
                TaoKhungNode(tree, Color.Green, form1);
                resultText += resultText.Equals("") ? tree.data.ToString() : $", {tree.data}";
                //form1.Resulttxt.Text = resultText;
                Thread.Sleep(delay);
                PreOrderS(tree.left, form1, delay);
                PreOrderS(tree.right, form1, delay);

            }
        }
        public void PostOrderS(Tree_Node tree, Form2 form1, int delay) // duyệt giữa
        {
            if (tree != null)
            {
                PostOrderS(tree.left, form1, delay);
                PostOrderS(tree.right, form1, delay);
                TaoKhungNode(tree, Color.Green, form1);
                resultText += resultText.Equals("") ? tree.data.ToString() : $", {tree.data}";
                //form1.Resulttxt.Text = resultText;
                Thread.Sleep(delay);
            }
        }
        public void InOrderS(Tree_Node tree, Form2 form1, int delay) // duyệt sau
        {
            if (tree != null)
            {
                InOrderS(tree.left, form1, delay);
                TaoKhungNode(tree, Color.Green, form1);
                resultText += resultText.Equals("") ? tree.data.ToString() : $", {tree.data}";
                //form1.Resulttxt.Text = resultText;
                Thread.Sleep(delay);
                InOrderS(tree.right, form1, delay);
            }
        }
        private void correctLevel(ref Tree_Node tree) // so sánh và xác định node thêm vào sẽ sang trái hay sang phải của node đang xét
        {
            if (tree.level != 0)
                tree.level = tree.dad.level + 1;

            if (tree.left != null)
                correctLevel(ref tree.left);
            if (tree.right != null)
                correctLevel(ref tree.right);
        }
        private void TaoKhungNode(Tree_Node tmp, Color color, Form2 form1) // tạo khung cho node
        {
            SolidBrush mybrush = new SolidBrush(color);
            Pen mypen = new Pen(mybrush, 7);
            Graphics g = form1.treeArea.CreateGraphics();
            g.DrawRectangle(mypen, tmp.toaDoX - 1, tmp.toaDoY - 1, form1.NodeSize + 2, form1.NodeSize + 2);
        }
    }
}

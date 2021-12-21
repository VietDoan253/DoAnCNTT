using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace AVL_Tree
{
    public class AVLTree
    {
        // khai báo các biến
        public Node root;
        public string inOrderResult;
        public string preOrderResult;
        public string postOrderResult;
        // lấy chiều cao của cây
        public Dictionary<string, Value> Viet = new Dictionary<string, Value>();
        public Dictionary<string, Extra> Thanh = new Dictionary<string, Extra>();

        Form1 form;
        int ctrThanh = 1;
        int ctrViet = 1;


        public AVLTree(Form1 form) 
        {
            this.form = form;
            root = null;
        }


        int height(Node N) // chiều cao của cây
        {
            if (N == null)
                return 0;
            return N.height;
        }

        // Hàm tìm số lớn nhất trong 2 số
        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // xoay phải cây con từ y
        Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;
  
            x.right = y;
            y.left = T2;

            // cập nhật chiều cao
            y.height = max(height(y.left), height(y.right)) + 1;
            x.height = max(height(x.left), height(x.right)) + 1;

            // trả về root mới
            return x;
        }

        // xoay trái cây con từ x
        Node leftRotate(Node x)
        {
            //y= root mới 
            //T2= gốc mới bên trái
            Node y = x.right;
            Node T2 = y.left;

            // Thực hiện xoay
            y.left = x;
            x.right = T2;

            // cập nhật chiều cao  
            x.height = max(height(x.left), height(x.right)) + 1;
            y.height = max(height(y.left), height(y.right)) + 1;

            // Return new root  
            return y;
        }

        // Lấy hệ số cân bằng của nút N
        public void delay() //hiệu ứng độ trễ
        {
            form.pictureBox1.Invalidate();
            Application.DoEvents();
            Thread.Sleep(300);

        }
        int getBalance(Node N) // điều chỉnh cân bằng lại
        {
            if (N == null)
                return 0;
            return height(N.left) - height(N.right);
        }
        public Node InsertHelper(Node node, int key) // chèn node
        {
            return insert(node, key, 1, 1, 34);
        }
        public Node insert(Node node, int key, int kali, int bagi, int tinggi) // các status diễn biến khi chèn
        {
            if (node == null)
            {
                form.Status.Text = "Current is null";
                delay();
                form.Status.Text = "Inserting node";
                delay();

                Viet.Add("Viet" + ctrViet, new Value(484 / bagi * kali + 1, tinggi, key.ToString()));
                ctrViet++;
                form.pictureBox1.Invalidate();
                return (new Node(key, "Viet" + (ctrViet - 1)));

            }

            if (key < node.key)
            {
                form.Status.Text = key + " is lesser than " + node.key;
                Viet[node.idViet].brush = new SolidBrush(Color.Yellow);
                delay();
                form.Status.Text = " Current go to left";
                Viet[node.idViet].brush = new SolidBrush(Color.Black);
                delay();

                node.left = insert(node.left, key, (kali * 2) - 1, bagi * 2, tinggi + 100);
            }
            else if (key > node.key)
            {
                form.Status.Text = key + " is greater than " + node.key;
                Viet[node.idViet].brush = new SolidBrush(Color.Yellow);
                delay();
                form.Status.Text = " Current go to right";
                Viet[node.idViet].brush = new SolidBrush(Color.Black);
                delay();
                node.right = insert(node.right, key, (kali * 2) + 1, bagi * 2, tinggi + 100);
            }
            else
                return node;

            /* Cập nhật chiều cao của nút tổ tiên này */
            node.height = 1 + max(height(node.left),
                                height(node.right));

            /* Lấy hệ số cân bằng của tổ tiên này
            node to check whether this node became  
            Wunbalanced */
            int balance = getBalance(node);

            // Nếu nút này trở nên không cân bằng, thì có 4 trường hợp
            // Trường hợp Left Left 
            if (balance > 1 && key < node.left.key)
            {
                form.Status.Text = "Right Rotate on " + node.key;
                delay();
                return rightRotate(node);
            }

            // Trường hợp Right Right   
            if (balance < -1 && key > node.right.key)
            {
                form.Status.Text = "Right Rotate on " + node.key;
                delay();
                return leftRotate(node);
            }

            // Trường hợp Left Right  
            if (balance > 1 && key > node.left.key)
            {
                form.Status.Text = "Double right Rotate on " + node.key;
                delay();
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }

            // Trường hợp Right Left  
            if (balance < -1 && key < node.right.key)
            {
                form.Status.Text = "Double left Rotate on " + node.key;
                delay();
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            /* trả về con trỏ nút (không thay đổi) */
            return node;
        }

        /* Đưa ra một cây tìm kiếm nhị phân không rỗng, trả về
        nút có giá trị khóa tối thiểu được tìm thấy trong cây đó.
        Lưu ý rằng toàn bộ cây không cần phải
        đã tìm kiếm. */
        Node minValueNode(Node node)
        {
            Node current = node;

            /* vòng xuống để tìm lá ngoài cùng bên trái */
            while (current.left != null)
                current = current.left;

            return current;
        }

        public Node deleteNode(Node root, int key)
        {
            // nếu root là rỗng thì   
            if (root == null)
            {
                form.Status.Text = "Deleted key not found in tree";
                delay();
                return root;
            }

            // Nếu khóa cần xóa nhỏ hơn khóa của gốc, thì nó nằm ở cây con bên trái
            if (key < root.key)
            {
                form.Status.Text = key + " is lesser than " + root.key;
                Viet[root.idViet].brush = new SolidBrush(Color.Yellow);
                delay();
                form.Status.Text = " Current go to left";
                Viet[root.idViet].brush = new SolidBrush(Color.Black);
                delay();

                root.left = deleteNode(root.left, key);
            }

            // Nếu khóa cần xóa lớn hơn khóa của gốc, thì nó nằm trong cây con bên phải
            else if (key > root.key)
            {
                form.Status.Text = key + " is greater than " + root.key;
                Viet[root.idViet].brush = new SolidBrush(Color.Yellow);
                delay();
                form.Status.Text = " Current go to right";
                Viet[root.idViet].brush = new SolidBrush(Color.Black);
                delay();

                root.right = deleteNode(root.right, key);
            }

            // nếu khóa giống với khóa của gốc, thì đây là nút sẽ bị xóa
            else
            {
                form.Status.Text = "Node is found";
                Viet[root.idViet].brush = new SolidBrush(Color.Yellow);
                delay();

                // nút chỉ có một nút con hoặc không có nút con
                if ((root.left == null) || (root.right == null))
                {
                    Node temp = null;
                    if (temp == root.left)
                        temp = root.right;
                    else
                        temp = root.left;

                    // Trường hợp không có con
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else // Trường hợp chỉ có một con  
                        root = temp; 
                }
                else
                {

                    // nút có hai nút con: Lấy nút kế tiếp nhỏ hơn (nhỏ nhất trong cây con bên phải)
                    Node temp = minValueNode(root.right);

                    // Sao chép dữ liệu duyệt giữa của successor vào nút này 
                    root.key = temp.key;

                    // Xóa duyệt giữa của successor
                    root.right = deleteNode(root.right, temp.key);
                }

            }

            // Nếu cây chỉ có một nút thì trả về
            if (root == null)
                return root;

            // Cập nhật chiều cao của node hiện tại 
            root.height = max(height(root.left), height(root.right)) + 1;

            // Kiểm tra xem node có cân bằng không, nếu không thì cân bằng lại
            int balance = getBalance(root);

            // Nếu node không cân bằng sẽ có 4 trường hợp
            // Trường hợp Left Left  
            if (balance > 1 && getBalance(root.left) >= 0)
            {
                form.Status.Text = "Right Rotate on " + root.key;
                delay();
                return rightRotate(root);
            }
            // Trường hợp Left Right  
            if (balance > 1 && getBalance(root.left) < 0)
            {

                form.Status.Text = "Double Right Rotate on " + root.key;
                delay();

                root.left = leftRotate(root.left);
                return rightRotate(root);
            }

            // Trường hợp Right Right  
            if (balance < -1 && getBalance(root.right) <= 0)
            {
                form.Status.Text = "Left Rotate on " + root.key;
                delay();
                return leftRotate(root);
            }

            // Trường hợp Right Left  
            if (balance < -1 && getBalance(root.right) > 0)
            {
                form.Status.Text = "Double Rotate on " + root.key;
                delay();

                root.right = rightRotate(root.right);
                return leftRotate(root);
            }

            return root;
        }

        public void find(int value) // Hàm tìm kiếm node
        {
            if (root == null) return;
            Node current = root;
            while (current != null)
            {
                if (value < current.key)
                {
                    form.Status.Text = value + " is lesser than " + current.key;
                    Viet[current.idViet].brush = new SolidBrush(Color.Yellow);
                    delay();
                    form.Status.Text = " Current go to left";
                    Viet[current.idViet].brush = new SolidBrush(Color.Black);
                    delay();
                    current = current.left;
                }
                else if (value > current.key)
                {
                    form.Status.Text = value + " is greater than " + current.key;
                    Viet[current.idViet].brush = new SolidBrush(Color.Yellow);
                    delay();
                    form.Status.Text = " Current go to right";
                    Viet[current.idViet].brush = new SolidBrush(Color.Black);
                    current = current.right;
                    delay();
                }
                else
                {
                    form.Status.Text = value + " exist in tree";
                    Viet[current.idViet].brush = new SolidBrush(Color.Yellow);
                    delay();
                    Viet[current.idViet].brush = new SolidBrush(Color.Black);
                    form.mbox(value + " has been found in tree");
                    delay();
                    return;
                }

            }
            form.Status.Text = value + "Value not found";
            form.mbox(value + " doesn't exist in tree");
            delay();

        }
        public void inOrder(Node root)
        {
            if (root == null) return;
            inOrder(root.left);
            Viet[root.idViet].brush = new SolidBrush(Color.Yellow);
            delay();
            inOrderResult += root.key + " ";
            inOrder(root.right);

        }
        public void preOrder(Node root)
        {
            if (root == null) return;
            Viet[root.idViet].brush = new SolidBrush(Color.Yellow);
            delay();
            preOrderResult += root.key + " ";
            preOrder(root.left);
            preOrder(root.right);
        }
        public void postOrder(Node root)
        {
            if (root == null) return;
            postOrder(root.left);
            postOrder(root.right);
            Viet[root.idViet].brush = new SolidBrush(Color.Yellow);
            delay();
            postOrderResult += root.key + " ";
        }

        // PHẦN TRANG TRÍ VÀ HIỆU ỨNG
        public void inOrderHelper()
        {
            Viet.Clear();
            Thanh.Clear();
            ctrViet = 1;
            ctrThanh = 1;
            inOrderClear(ref this.root, 1, 1, 50);
        }
        public void inOrderClear(ref Node root, int kali, int bagi, int tinggi)
        {
            if (root == null) return;
            inOrderClear(ref root.left, (kali * 2) - 1, bagi * 2, tinggi + 100);

            Viet.Add("Viet" + ctrViet, new Value(484 / bagi * kali + 1, tinggi, root.key.ToString()));
            root.idViet = "Viet" + ctrViet;
            ctrViet++;
            form.pictureBox1.Invalidate();
            Application.DoEvents();
            if (root.left != null)
            {
                Thanh.Add("Thanh" + ctrThanh, new Extra((484 / bagi * kali + 1) + 25, tinggi + 30, (484 / (bagi * 2)) * ((kali * 2) - 1) + 25, tinggi + 100));
                ctrThanh++;
                form.pictureBox1.Invalidate();
            }

            if (root.right != null)
            {
                Thanh.Add("Thanh" + ctrThanh, new Extra((484 / bagi * kali + 1) + 25, tinggi + 30, (484 / (bagi * 2)) * ((kali * 2) + 1) + 25, tinggi + 100));
                ctrThanh++;
                form.pictureBox1.Invalidate();
            }
            inOrderClear(ref root.right, (kali * 2) + 1, bagi * 2, tinggi + 100);
        }
        public void preOrderHelper()
        {
            Viet.Clear();
            Thanh.Clear();
            ctrViet = 1;
            ctrThanh = 1;
            preOrderClear(ref this.root, 1, 1, 50);
        }
        public void preOrderClear(ref Node root, int kali, int bagi, int tinggi)
        {
            if (root == null) return;
            inOrderClear(ref root.left, (kali * 2) - 1, bagi * 2, tinggi + 100);

            Viet.Add("Viet" + ctrViet, new Value(484 / bagi * kali + 1, tinggi, root.key.ToString()));
            root.idViet = "Viet" + ctrViet;
            ctrViet++;
            form.pictureBox1.Invalidate();
            Application.DoEvents();
            if (root.left != null)
            {
                Thanh.Add("Thanh" + ctrThanh, new Extra((484 / bagi * kali + 1) + 25, tinggi + 30, (484 / (bagi * 2)) * ((kali * 2) - 1) + 25, tinggi + 100));
                ctrThanh++;
                form.pictureBox1.Invalidate();
            }

            if (root.right != null)
            {
                Thanh.Add("Thanh" + ctrThanh, new Extra((484 / bagi * kali + 1) + 25, tinggi + 30, (484 / (bagi * 2)) * ((kali * 2) + 1) + 25, tinggi + 100));
                ctrThanh++;
                form.pictureBox1.Invalidate();
            }
            inOrderClear(ref root.right, (kali * 2) + 1, bagi * 2, tinggi + 100);
        }
        public void postOrderHelper()
        {
            Viet.Clear();
            Thanh.Clear();
            ctrViet = 1;
            ctrThanh = 1;
            postOrderClear(ref this.root, 1, 1, 50);
        }
        public void postOrderClear(ref Node root, int kali, int bagi, int tinggi)
        {
            if (root == null) return;
            inOrderClear(ref root.left, (kali * 2) - 1, bagi * 2, tinggi + 100);

            Viet.Add("Viet" + ctrViet, new Value(484 / bagi * kali + 1, tinggi, root.key.ToString()));
            root.idViet = "Viet" + ctrViet;
            ctrViet++;
            form.pictureBox1.Invalidate();
            Application.DoEvents();
            if (root.left != null)
            {
                Thanh.Add("Thanh" + ctrThanh, new Extra((484 / bagi * kali + 1) + 25, tinggi + 30, (484 / (bagi * 2)) * ((kali * 2) - 1) + 25, tinggi + 100));
                ctrThanh++;
                form.pictureBox1.Invalidate();
            }

            if (root.right != null)
            {
                Thanh.Add("Thanh" + ctrThanh, new Extra((484 / bagi * kali + 1) + 25, tinggi + 30, (484 / (bagi * 2)) * ((kali * 2) + 1) + 25, tinggi + 100));
                ctrThanh++;
                form.pictureBox1.Invalidate();
            }
            postOrderClear(ref root.right, (kali * 2) + 1, bagi * 2, tinggi + 100);




        }

    }
}

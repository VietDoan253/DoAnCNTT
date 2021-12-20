using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    public class Node
    {
        public int key, height; // giá trị node, chiều cao cây
        public Node left, right; // node bên trái, bên phải

        // kiểu string truyền vào chuỗi
        public string idViet; 
        public string idThanh;

        public Node(int key,string idViet)
        {
            this.key = key;
            this.idViet = idViet;
            height = 1;

        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNTT_BST
{
    class Binary_Search_Tree
    {
        Tree_Node root;
        int totalNodes = 0;
        const int rootTreeX = 50; //tọa độ node đầu tiên
        const int rootTreeY = 15;

        public Binary_Search_Tree()
        {
            Tree_Node tmp = new Tree_Node();
            tmp.Data = 0;
            tmp.Level = 0;
            tmp.ToaDoX = rootTreeX;
            tmp.ToaDoY = rootTreeY;
            root = tmp;
        }
        #region Propertise
        public Tree_Node Root
        {
            get { return root; }
            set { root = value; }
        }
        public int TotalNodes
        {
            get { return totalNodes; }
            set { totalNodes = value; }
        }
        public int RootTreeX
        {
            get { return rootTreeX; }
        }
        public int RootTreeY
        {
            get { return rootTreeY; }
        }
        #endregion
    }
}

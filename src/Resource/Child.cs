using Resource.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resource
{
    public partial class Child : Form
    {
        /// <summary>
        /// 状态
        /// </summary>
        private Status status;

        /// <summary>
        /// 主键
        /// </summary>
        private int index;

        public Child(Status status, int index)
        {
            InitializeComponent();
            InitSelfData(status, index);
        }

        /// <summary>
        /// 初始用户相关数据
        /// </summary>
        private void InitSelfData(Status status, int index)
        {
            this.status = status;
            this.index = index;

            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

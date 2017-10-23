using Resource.DataAcess;
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
        private FileStatus status;

        /// <summary>
        /// 主键
        /// </summary>
        private int index;

        public Child(FileStatus status, int index)
        {
            InitializeComponent();
            InitSelfData(status, index);
            DisplayOrEnableComponent();
        }

        /// <summary>
        /// 初始用户相关数据
        /// </summary>
        private void InitSelfData(FileStatus status, int index)
        {
            this.status = status;
            this.index = index;

            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            if (status != FileStatus.New)
                LoadData();
        }

        private void DisplayOrEnableComponent()
        {
            if (status == FileStatus.Edit)
                txtKey.Enabled = false;
            else if (status == FileStatus.View)
            {
                txtKey.Enabled = false;
                btnOk.Visible = false;
            }
                
        }

        private void LoadData()
        {
            var result = ResourceDataService.GetResourceInfoByIndex(index);
            if (result == null)
                return;

            txtKey.Text = result.Key;
            txtChinese.Text = result.Chinese;
            txtEnglish.Text = result.English;
            txtTraditional.Text = result.Traditional;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckDataBeforeSave())
            {
                MessageBox.Show("‘关键字’和‘中文’两者必须输入。", "提示");
                return;
            }

            if (status == FileStatus.Edit)
                ResourceDataService.Update(index, txtChinese.Text.Trim(), txtEnglish.Text.Trim(), txtTraditional.Text.Trim());
            else if (status == FileStatus.New)
            {
                var keyResult = ResourceDataService.GetResourceInfoByKey(txtKey.Text.Trim());
                if (keyResult != null)
                {
                    MessageBox.Show("数据库中已存在相同的关键字，请保持其唯一", "提示");
                    return;
                }

                ResourceDataService.New(txtKey.Text.Trim(), txtChinese.Text.Trim(), txtEnglish.Text.Trim(), txtTraditional.Text.Trim());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool CheckDataBeforeSave()
        { 
            var flag = true;
            if (string.IsNullOrEmpty(txtKey.Text.Trim()) || string.IsNullOrEmpty(txtChinese.Text.Trim()) || string.IsNullOrWhiteSpace(txtTraditional.Text))
                flag = false;

            return flag;
        }
    }
}

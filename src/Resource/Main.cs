using Resource.DataAcess;
using Resource.Model;
using Resource.Service;
using System;
using System.Collections;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            InitComboxData();
            InitGridColumn();
            InitGridData();
        }

        #region 初始化表格
        private void InitGridColumn()
        {
            dgResourceList.AutoGenerateColumns = false;
            dgResourceList.ReadOnly = true;
            dgResourceList.AllowUserToResizeColumns = false;

            dgResourceList.Columns.AddRange(
                new DataGridViewColumn[] { 
                    new DataGridViewTextBoxColumn(){
                         DisplayIndex = 0,
                         HeaderText = "关键字",
                         Name = "Key",
                         DataPropertyName = "Key",
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Width = 269,
                    },
                    new DataGridViewTextBoxColumn(){
                         DisplayIndex = 1,
                         HeaderText = "中文",
                         Name = "Chinese",
                         DataPropertyName = "Chinese",
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Width = 485,
                    },
                    new DataGridViewTextBoxColumn(){
                         DisplayIndex = 2,
                         HeaderText = "英文",
                         Name = "English",
                         DataPropertyName =  "English",
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Width = 485
                    },
                    new DataGridViewButtonColumn(){
                         DisplayIndex = 3,
                         HeaderText = "删除",
                         DefaultCellStyle = new DataGridViewCellStyle { NullValue = "删除", Font = new System.Drawing.Font("", 10), Alignment = DataGridViewContentAlignment.BottomCenter},
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Tag = "Delete",
                         Width = 60
                    },
                    new DataGridViewButtonColumn(){
                         DisplayIndex = 4,
                         HeaderText = "修改",
                         DefaultCellStyle = new DataGridViewCellStyle{NullValue = "修改",Font = new System.Drawing.Font("", 10), Alignment = DataGridViewContentAlignment.BottomCenter},
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Tag = "Modify",
                         Width = 60
                    },
                    new DataGridViewTextBoxColumn(){
                         DisplayIndex = 5,
                         Name = "Index",
                         DataPropertyName = "Index",
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Width = 0,
                    }
                });
        }
        #endregion

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitComboxData()
        {
            cmbSearchType.Items.AddRange(new List<ComboboxItem>
            {
                new ComboboxItem{
                     Text = "关键字",
                     Value = "Key"
                },
                new ComboboxItem{
                     Text = "内容",
                     Value = "Value"
                }
            }.ToArray());

            cmbSearchType.SelectedIndex = 0;
        }

        private void InitGridData()
        {
            var resourceData = ResourceDataService.Search(((ComboboxItem)cmbSearchType.SelectedItem).Value, SearchText.Text.Trim(), 50);
            dgResourceList.DataSource = resourceData;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitGridData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var child = new Child(FileStatus.New, 0);
            child.StartPosition = FormStartPosition.CenterParent;

            if (child.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                InitGridData();
        }

        /// <summary>
        /// 删除和修改
        /// </summary>
        private void dgResourceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var column = dgResourceList.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    var tag = column.Tag;
                    if (tag == null) return;

                    var index = GetDataIndexData();
                    if (index == 0) return;

                    if (string.Equals("Delete", tag.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (MessageBox.Show(this, "你确定要删除此条数据?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            ResourceDataService.DeleteOneData(index);
                            var list = (IList)dgResourceList.DataSource;
                            list.RemoveAt(dgResourceList.CurrentRow.Index);
                            dgResourceList.DataSource = null;
                            dgResourceList.DataSource = list;
                        }
                    }
                    else if (string.Equals("Modify", tag.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        var child = new Child(FileStatus.Edit, index);
                        child.StartPosition = FormStartPosition.CenterParent;

                        if (child.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            InitGridData();
                    }
                }
            }
        }

        private void dgResourceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = GetDataIndexData();
            if (index == 0) return;

            var child = new Child(FileStatus.View, index);
            child.StartPosition = FormStartPosition.CenterParent;

            child.ShowDialog();
        }

        private int GetDataIndexData()
        {
            string value = dgResourceList.CurrentRow.Cells["Index"].Value.ToString();

            int index = 0;
            int.TryParse(value, out index);
            return index;
        }

        /// <summary>
        /// 当为回车键时查询
        /// </summary>
        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                InitGridData();
        }

        /// <summary>
        /// 下载生成的资源文件
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {
            var data = ResourceDataService.Search("Key", string.Empty);
            if (data.Count == 0)
                return;

            ResourceGenerater.GenerateResxFile(data);
            MessageBox.Show("已将相关内容生成到Temp目录中。", "提示");
        }
    }
}

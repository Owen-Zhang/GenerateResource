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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            cmbSearchType.SelectedIndex = 0;
            InitGridColumn();
            InitGridData();
        }

        private void InitGridColumn()
        {
            dgResourceList.AutoGenerateColumns = false;
            dgResourceList.ReadOnly = false;

            dgResourceList.Columns.AddRange(
                new DataGridViewColumn[] { 
                    new DataGridViewTextBoxColumn(){
                         DisplayIndex = 0,
                         HeaderText = "关键字",
                         Name = "Key",
                         DataPropertyName = "Key",
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Width = 190,
                    },
                    new DataGridViewTextBoxColumn(){
                         DisplayIndex = 1,
                         HeaderText = "中文",
                         Name = "Chinese",
                         DataPropertyName = "Chinese",
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Width = 350,
                    },
                    new DataGridViewTextBoxColumn(){
                         DisplayIndex = 2,
                         HeaderText = "英文",
                         Name = "English",
                         DataPropertyName =  "English",
                         SortMode = DataGridViewColumnSortMode.NotSortable,
                         Width = 350
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
                    }
                });
        }

        private void InitGridData()
        {
            dgResourceList.DataSource = new List<ResourceModel> { 
                new ResourceModel {
                     Key = "test1",
                     Chinese = "test1-chinese",
                     English = "test1-english"
                },
                new ResourceModel {
                     Key = "test2",
                     Chinese = "test2-chinese",
                     English = "test2-english"
                }
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

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

                    //删除
                    if (string.Equals("Delete", tag.ToString(), StringComparison.OrdinalIgnoreCase))
                    {

                    }
                    //修改
                    else if (string.Equals("Modify", tag.ToString(), StringComparison.OrdinalIgnoreCase))
                    { 
                    
                    }
                }
            }
        }
    }
}

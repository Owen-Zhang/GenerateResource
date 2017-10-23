using Resource.Model;
using System.Collections.Generic;

namespace Resource.DataAcess
{
    public class ResourceDataService
    {
        /// <summary>
        /// 删除某条数据
        /// </summary>
        public static void DeleteOneData(int index)
        {
            var command = DataAccess.DbManager.GetDataCommand("Resource_DeleteOne");
            command.SetParameterValue("@Index", index);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 根据主键查询出当前的资源信息
        /// </summary>
        public static ResourceModel GetResourceInfoByIndex(int index)
        {
            var command = DataAccess.DbManager.GetDataCommand("Resource_GetOneByTransactionNumber");
            command.SetParameterValue("@Index", index);
            return command.Query<ResourceModel>();
        }

        /// <summary>
        /// 根据关键字查询出数据
        /// </summary>
        public static ResourceModel GetResourceInfoByKey(string key) 
        {
            var command = DataAccess.DbManager.GetDataCommand("Resource_GetOneByKey");
            command.SetParameterValue("@Key", key);
            return command.Query<ResourceModel>();
        }

        /// <summary>
        /// 新增
        /// </summary>
        public static void New(string keyWord, string chinese, string english, string traditional)
        {
            var command = DataAccess.DbManager.GetDataCommand("Resource_NewOne");
            command.SetParameterValue("@KeyWord", keyWord);
            command.SetParameterValue("@Chinese", chinese);
            command.SetParameterValue("@English", english);
            command.SetParameterValue("@Traditional", traditional);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 更新
        /// </summary>
        public static void Update(int index, string chinese, string english, string traditional)
        {
            var command = DataAccess.DbManager.GetDataCommand("Resource_UpdateOne");
            command.SetParameterValue("@Index", index);
            command.SetParameterValue("@Chinese", chinese);
            command.SetParameterValue("@English", english);
            command.SetParameterValue("@Traditional", traditional);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询
        /// </summary>
        public static List<ResourceModel> Search(string keyWordType, string content, int total = int.MaxValue)
        {
            var command = DataAccess.DbManager.GetDataCommand("Resource_Search");
            command.SetParameterValue("@KeyWordType", keyWordType);
            command.SetParameterValue("@Content", content);
            command.SetParameterValue("@Total", total);

            return command.QueryList<ResourceModel>();
        }
    }
}

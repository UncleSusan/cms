using System.Data;
using BaiRong.Core.Data;
using SiteServer.CMS.Wcm.Model;
using SiteServer.Plugin;
using SiteServer.Plugin.Models;

namespace SiteServer.CMS.Wcm.Provider
{
    public class GovPublicApplyReplyDao : DataProviderBase
    {
        private const string SqlSelect = "SELECT ReplyID, PublishmentSystemID, ApplyID, Reply, FileUrl, DepartmentID, UserName, AddDate FROM wcm_GovPublicApplyReply WHERE ReplyID = @ReplyID";

        private const string SqlSelectByApplyId = "SELECT ReplyID, PublishmentSystemID, ApplyID, Reply, FileUrl, DepartmentID, UserName, AddDate FROM wcm_GovPublicApplyReply WHERE ApplyID = @ApplyID";

        private const string ParmReplyId = "@ReplyID";
        private const string ParmPublishmentsystemid = "@PublishmentSystemID";
        private const string ParmApplyId = "@ApplyID";
        private const string ParmReply = "@Reply";
        private const string ParmFileUrl = "@FileUrl";
        private const string ParmDepartmentId = "@DepartmentID";
        private const string ParmUserName = "@UserName";
        private const string ParmAddDate = "@AddDate";

        public void Insert(GovPublicApplyReplyInfo replyInfo)
        {
            var sqlString = "INSERT INTO wcm_GovPublicApplyReply(PublishmentSystemID, ApplyID, Reply, FileUrl, DepartmentID, UserName, AddDate) VALUES (@PublishmentSystemID, @ApplyID, @Reply, @FileUrl, @DepartmentID, @UserName, @AddDate)";
            
            var parms = new IDataParameter[]
			{
                GetParameter(ParmPublishmentsystemid, DataType.Integer, replyInfo.PublishmentSystemID),
                GetParameter(ParmApplyId, DataType.Integer, replyInfo.ApplyID),
                GetParameter(ParmReply, DataType.NText, replyInfo.Reply),
                GetParameter(ParmFileUrl, DataType.NVarChar, 255, replyInfo.FileUrl),
                GetParameter(ParmDepartmentId, DataType.Integer, replyInfo.DepartmentID),
				GetParameter(ParmUserName, DataType.VarChar, 50, replyInfo.UserName),
                GetParameter(ParmAddDate, DataType.DateTime, replyInfo.AddDate)
			};

            ExecuteNonQuery(sqlString, parms);
        }

        public void Delete(int replyId)
        {
            string sqlString = $"DELETE FROM wcm_GovPublicApplyReply WHERE ReplyID = {replyId}";
            ExecuteNonQuery(sqlString);
        }

        public void DeleteByApplyId(int applyId)
        {
            string sqlString = $"DELETE FROM wcm_GovPublicApplyReply WHERE ApplyID = {applyId}";
            ExecuteNonQuery(sqlString);
        }

        public GovPublicApplyReplyInfo GetReplyInfo(int replayId)
        {
            GovPublicApplyReplyInfo replyInfo = null;

            var parms = new IDataParameter[]
			{
				GetParameter(ParmReplyId, DataType.Integer, replayId)
			};

            using (var rdr = ExecuteReader(SqlSelect, parms))
            {
                if (rdr.Read())
                {
                    var i = 0;
                    replyInfo = new GovPublicApplyReplyInfo(GetInt(rdr, i++), GetInt(rdr, i++), GetInt(rdr, i++), GetString(rdr, i++), GetString(rdr, i++), GetInt(rdr, i++), GetString(rdr, i++), GetDateTime(rdr, i));
                }
                rdr.Close();
            }

            return replyInfo;
        }

        public GovPublicApplyReplyInfo GetReplyInfoByApplyId(int applyId)
        {
            GovPublicApplyReplyInfo replyInfo = null;

            var parms = new IDataParameter[]
			{
				GetParameter(ParmApplyId, DataType.Integer, applyId)
			};

            using (var rdr = ExecuteReader(SqlSelectByApplyId, parms))
            {
                if (rdr.Read())
                {
                    var i = 0;
                    replyInfo = new GovPublicApplyReplyInfo(GetInt(rdr, i++), GetInt(rdr, i++), GetInt(rdr, i++), GetString(rdr, i++), GetString(rdr, i++), GetInt(rdr, i++), GetString(rdr, i++), GetDateTime(rdr, i));
                }
                rdr.Close();
            }

            return replyInfo;
        }
    }
}

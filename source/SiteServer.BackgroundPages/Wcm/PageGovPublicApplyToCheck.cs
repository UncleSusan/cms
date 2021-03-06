using System;
using System.Collections.Specialized;
using BaiRong.Core;
using SiteServer.CMS.Core;
using SiteServer.CMS.Model.Enumerations;

namespace SiteServer.BackgroundPages.Wcm
{
    public class PageGovPublicApplyToCheck : BasePageGovPublicApplyTo
	{
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BreadCrumb(AppManager.Wcm.LeftMenu.IdGovPublic, "待审核申请", AppManager.Wcm.Permission.WebSite.GovPublicApply);
            }
        }

        protected override string GetSelectString()
        {
            return DataProvider.GovPublicApplyDao.GetSelectStringByState(PublishmentSystemId, EGovPublicApplyState.Replied);
        }

        private string _pageUrl;
        protected override string PageUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_pageUrl))
                {
                    _pageUrl = PageUtils.GetWcmUrl(nameof(PageGovPublicApplyToCheck), new NameValueCollection
                    {
                        {"siteId", PublishmentSystemId.ToString()}
                    });
                }
                return _pageUrl;
            }
        }
	}
}

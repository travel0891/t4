namespace view
{
    using System;
    using System.Configuration;
    using System.Web.UI;

    public class viewBase : Page
    {
        private String _staticUrl;
        /// <summary>
        /// 静态资源地址
        /// </summary>
        protected String staticUrl { get { return _staticUrl; } }

        private String _staticVersion;
        /// <summary>
        /// 静态资源版本号
        /// </summary>
        protected String staticVersion { get { return _staticVersion; } }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _staticUrl = ConfigurationManager.AppSettings["staticUrl"];
            _staticVersion = ConfigurationManager.AppSettings["staticVersion"];
        }
    }
}
﻿using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace GitHubLabelInitialiser.Web.Helpers
{
	public static class GitHubLoginHelperExtension
	{
		private const string BaseUrl = "https://github.com/login/oauth/access_token";

		public static MvcHtmlString LoginButton(this HtmlHelper htmlHelper, string clientId, string redirectUri = null, IList<string> scope = null)
		{
			var link = new TagBuilder("a");
			link.MergeAttribute("href", CreateLink(clientId, redirectUri, scope));
			link.InnerHtml = "Create account with GitHub";
			var html = link.ToString();

			return MvcHtmlString.Create(html);
		}

		private static string CreateLink(string clientId, string redirectUri = null, IEnumerable<string> scope = null)
		{
			var optional = new StringBuilder();
			var state = "&state=" + System.Guid.NewGuid();

			if (redirectUri != null) optional.Append("&redirect_uri=" + redirectUri);
			if (scope != null) optional.Append("&scope=" + string.Join(",", scope));

			return string.Format(@"{0}?client_id={1}{2}{3}", BaseUrl, clientId, optional, state);
		}
	}
}
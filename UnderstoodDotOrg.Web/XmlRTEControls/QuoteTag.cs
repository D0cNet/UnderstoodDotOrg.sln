using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Web;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnderstoodDotOrg.Web.XmlRTEControls
{
	public class QuoteTag : DialogForm
	{
		protected Sitecore.Web.UI.HtmlControls.Memo memCode;

		protected override void OnLoad(EventArgs e)
		{
			Assert.ArgumentNotNull(e, "e");
			base.OnLoad(e);
			if (!Context.ClientPage.IsEvent)
			{
				this.Mode = WebUtil.GetQueryString("mo");
				string text = WebUtil.GetQueryString("selectedText");
				memCode.Value = text;
			}
		}

		protected override void OnOK(object sender, EventArgs args)
		{
			Assert.ArgumentNotNull(sender, "sender");
			Assert.ArgumentNotNull(args, "args");

			string content = "<q>" + memCode.Value + "</q>";

			if (this.Mode == "webedit")
			{
				SheerResponse.SetDialogValue(StringUtil.EscapeJavascriptString(content));
				base.OnOK(sender, args);
			}
			else
				SheerResponse.Eval("scClose(" + StringUtil.EscapeJavascriptString(content) + ")");
		}

		protected override void OnCancel(object sender, EventArgs args)
		{
			Assert.ArgumentNotNull(sender, "sender");
			Assert.ArgumentNotNull(args, "args");
			if (this.Mode == "webedit")
				base.OnCancel(sender, args);
			else
				SheerResponse.Eval("scCancel()");
		}

		protected string Mode
		{
			get
			{
				string str = StringUtil.GetString(base.ServerProperties["Mode"]);
				if (!string.IsNullOrEmpty(str))
					return str;
				return "shell";
			}
			set
			{
				Assert.ArgumentNotNull(value, "value");
				base.ServerProperties["Mode"] = value;
			}
		}
	}
}
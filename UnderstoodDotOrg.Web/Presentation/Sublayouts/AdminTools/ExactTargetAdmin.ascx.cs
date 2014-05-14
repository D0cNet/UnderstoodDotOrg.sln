namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools
{
	using System;

	using UnderstoodDotOrg.Services.ExactTarget;
	using UnderstoodDotOrg.Domain.ExactTarget;
	using System.Collections.Generic;

	public partial class ExactTargetAdmin : System.Web.UI.UserControl
	{
		private void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				// initialize text boxes
				tbxSubscriberEmail1.Text = "jtesta@agencyoasis.com";
				tbxSubscriberKey1.Text = "jtesta@agencyoasis.com";
				tbxSubscriberFN1.Text = "Joe";
				lblMessage.Text = "Email Test has not started ...";
				txtHtmlContent.Text = "<p><b>This is a test!</b></p>";
				txtWebinarCode.Text = "<p><b>This is a test!</b></p>";
			}
		}

		protected void btnETTests_Click(object sender, EventArgs e)
		{
			//InvokeEM2ParentToolkitReply reply = ExactTargetService.InvokeEM2ParentToolkit(new InvokeEM2ParentToolkitRequest { ToEmail = tbxSubscriberEmail1.Text });
			InvokeWelcomeToUnderstoodReply reply = ExactTargetService.InvokeWelcomeToUnderstood(new InvokeWelcomeToUnderstoodRequest { ToEmail = tbxSubscriberEmail1.Text, FirstName = tbxSubscriberFN1.Text });

			//InvokeEM10WebinarConfirmationReply reply = ExactTargetService.InvokeEM10WebinarConfirmation(new InvokeEM10WebinarConfirmationRequest { ToEmail = tbxSubscriberEmail1.Text, WebinarModule = txtWebinarCode.Text });
			
			
			lblMessage.Text = reply.Message;
		}

		protected void btnEM2_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM3_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM4_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM5_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM6_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM7_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM8_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM9_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM10_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM11_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM12_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM13_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM14_Click(object sender, EventArgs e)
		{

		}

		protected void btnEM15_Click(object sender, EventArgs e)
		{

		}

		protected void btne1a_Click(object sender, EventArgs e)
		{

		}

		protected void btne1b_Click(object sender, EventArgs e)
		{

		}

		protected void btne1B_Click1(object sender, EventArgs e)
		{

		}

		protected void btne1c_Click(object sender, EventArgs e)
		{

		}



	}
}
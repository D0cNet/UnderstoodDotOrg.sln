using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
public partial class SignUpPageItem : CustomItem
{

public static readonly string TemplateId = "{91338E32-0BA8-4F1F-BEA3-12701F8D6386}";

#region Inherited Base Templates

private readonly MyAccountBaseItem _MyAccountBaseItem;
public MyAccountBaseItem MyAccountBase { get { return _MyAccountBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public SignUpPageItem(Item innerItem) : base(innerItem)
{
	_MyAccountBaseItem = new MyAccountBaseItem(innerItem);

}

public static implicit operator SignUpPageItem(Item innerItem)
{
	return innerItem != null ? new SignUpPageItem(innerItem) : null;
}

public static implicit operator Item(SignUpPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Directions
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Directions"]);
	}
}


public CustomTextField NewsletterDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Newsletter Description"]);
	}
}


public CustomTextField TermsofServiceDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Terms of Service Description"]);
	}
}


public CustomTextField Privacylinktext
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Privacy link text"]);
	}
}


public CustomTextField Acknowledgemessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Acknowledge message"]);
	}
}


public CustomTextField ZipCodeLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Zip Code Link Text"]);
	}
}


public CustomTextField ZipCodeMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Zip Code Message"]);
	}
}


public CustomTextField WeTakePrivacySeriouslyText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["We Take Privacy Seriously Text"]);
	}
}


public CustomGeneralLinkField PrivacyPolicyLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Privacy Policy Link"]);
	}
}


public CustomTextField AlreadySignedUpText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Already Signed Up Text"]);
	}
}


public CustomImageField FBImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["FB Image"]);
	}
}


#endregion //Field Instance Methods
}
}
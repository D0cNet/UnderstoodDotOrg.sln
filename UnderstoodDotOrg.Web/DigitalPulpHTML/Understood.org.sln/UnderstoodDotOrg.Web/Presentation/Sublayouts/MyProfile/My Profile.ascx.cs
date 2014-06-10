namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Domain.Membership;

    public partial class My_Profile : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
#region Mock User
            var currentUser = new Member()
            {
                FirstName = "Sonya",
                LastName = "Mik",
                ScreenName = "SonyasMom65",
                ZipCode = "07040",
                Role = Guid.Parse("{890F06AF-284E-43E1-9647-0EFEEB000526}"), //Mother
                //HomeLife = Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"), //not displayed?
                //PersonalityType = Guid.Parse("{8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983}"),               
                hasOtherChildren = false,
                allowConnections = true,
                allowNewsletter = true,
                isPrivate = false,
                Interests = new List<Interest>() {
                    new Interest() {
                        Key = Guid.Parse("{0642E401-8E66-4C69-89C6-294C257456C8}"),
                        CategoryName = "Journey",
                        Value = "Still Figuring Out",
                    },
                    new Interest() {
                        Key = Guid.Parse("{78FC54BD-691A-4C74-9E84-5B299094143E}"),
                        CategoryName = "School Issues",
                        Value = "School Services",
                    },
                    new Interest() {
                        Key = Guid.Parse("{09DE69B9-6043-47C8-8ECB-40574E013956}"),
                        CategoryName = "School Issues",
                        Value = "Homeschooling",
                    },
                    new Interest() {
                        Key = Guid.Parse("{448FFAC8-AE1E-446D-9A38-DB134C793140}"),
                        CategoryName = "School Issues",
                        Value = "Bullying",
                    },
                    new Interest() {
                        Key = Guid.Parse("{8891DE05-873F-43AE-804A-E7D1DCF6DD6D}"),
                        CategoryName = "Ways to Help Your Child",
                        Value = "Evaluations",
                    },
                    new Interest() {
                        Key = Guid.Parse("{DDD43387-BE5D-4884-BC13-645FA356150F}"),
                        CategoryName = "Ways to Help Your Child",
                        Value = "Tutors & Academic Skills Programs",
                    },
                    new Interest() {
                        Key = Guid.Parse("{26A98810-4539-4BB7-8D6F-43CFE075AED3}"),
                        CategoryName = "Technologies And Apps",
                        Value = "Apps",
                    },
                    new Interest() {
                        Key = Guid.Parse("{70045D51-CCF8-4CCD-8C14-AFE23F6759B0}"),
                        CategoryName = "Ways to Help Your Child",
                        Value = "Advocating for Your Child's Rights",
                    },
                },
                Children = new List<Child>() { 
                    new Child() {
                        Nickname = "Michael",
                        //IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                        //Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                        Grade = Guid.Parse("{67AA2A29-E6FF-49B2-9F9E-D29F07C19C23}"),
                        EvaluationStatus = Guid.Parse("{990FB117-F12E-4E3C-898B-8A9EB217FCFD}"),
                        Issues = new List<Issue>() { 
                            new Issue() {
                                Key = Guid.Parse("{3B4DC3FC-517D-47B5-B151-198AB7B3C6D4}"),
                                Value = "Spoken Language"
                            },
                            new Issue() {
                                Key = Guid.Parse("{3390C210-0B22-48FD-A411-881F956EDC0C}"),
                                Value = "Listening"
                            },
                            new Issue() {
                                Key = Guid.Parse("{CE405288-18FA-4665-A94C-AE6A558795DF}"),
                                Value = "Social Skills"
                            },
                            new Issue() {
                                Key = Guid.Parse("{CB5320E9-5F0D-4204-B76C-DE630A8BBE51}"),
                                Value = "Motor Skills"
                            },
                        },
                        //Diagnoses = new List<Diagnosis>() { 
                        //    new Diagnosis() {
                        //        Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
                        //        Value = "ADHD"
                        //    }
                        //},
                    },
                    new Child() {
                        Nickname = "Sally",
                        //IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                        //Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                        Grade = Guid.Parse("{79AB134B-CC1F-4BB6-94F8-12FE9E181F9E}"),
                        EvaluationStatus = Guid.Parse("{990FB117-F12E-4E3C-898B-8A9EB217FCFD}"),
                        Issues = new List<Issue>() { 
                            new Issue() {
                                Key = Guid.Parse("{2611BEA0-33E6-4732-9BD5-B56857C5EA26}"),
                                Value = "Reading"
                            },
                            new Issue() {
                                Key = Guid.Parse("{1D338D37-CF4E-4C1C-9499-EBA6C0A2BBA0}"),
                                Value = "Math"
                            },
                            new Issue() {
                                Key = Guid.Parse("{B904242D-E290-4A2E-86D9-372DC42AB692}"),
                                Value = "Writing"
                            },
                            new Issue() {
                                Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
                                Value = "Attention or Staying Focused"
                            },
                            new Issue() {
                                Key = Guid.Parse("{28BB0311-D062-48F0-BEDF-C2D74EB6737E}"),
                                Value = "Hyperactivity or Impulsivity"
                            },
                        },
                        //Diagnoses = new List<Diagnosis>() { 
                        //    new Diagnosis() {
                        //        Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
                        //        Value = "ADHD"
                        //    }
                        //},
                    }
                },
            };
            
            string username = "sonya.mik@gmail.com";
            string password = "digitalpulp!";
            string phonenumber = "555-555-1234";
#endregion

            uxChildList.DataSource = currentUser.Children;
            uxChildList.DataBind();

            uxInterestList.DataSource = currentUser.Interests.Where(x => x.CategoryName != "Journey");
            uxInterestList.DataBind();

            uxEmailAddress.Text = username;
            uxJourney.Text = currentUser.Interests.Where(x => x.CategoryName == "Journey").First().Value;
            uxPassword.Text = replacePassword(password);
            uxPhoneNumber.Text = phonenumber;
            uxPrivacyLevel.Text = currentUser.allowConnections ? DictionaryConstants.OpenToConnect : DictionaryConstants.NotOpenToConnect;
            uxRole.Text = getItemName(currentUser.Role); //lookup
            uxScreenname.Text = currentUser.ScreenName;
            uxZipcode.Text = currentUser.ZipCode;
            uxAddChild.Text = string.Format(uxAddChild.Text, ((ChildCount) currentUser.Children.Count).ToString());

        }

        private string replacePassword(string password)
        {
            string ret = string.Empty;
            
            for (int i = 0; i < password.Length; i++)
            {
                ret += "·";
            }

            return ret;
        }

        enum ChildCount
        {
            First = 0,
            Second = 1,
            Third = 2,
            Fourth = 3,
            Fifth = 4,
            Sixth = 5
        }

        protected void uxChildList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            string[] g = { "boy", "girl" };

            var item = e.Item.DataItem as Child;
            var issueList = e.Item.FindControl("uxChildIssueList") as ListView;
            var grade = e.Item.FindControl("uxGrade") as Literal;
            var gender = e.Item.FindControl("uxGender") as Literal;
            var evaluatedStatus = e.Item.FindControl("uxEvaluationStatus") as Literal;

            if (item != null)
            {
                if (issueList != null)
                {
                    issueList.DataSource = item.Issues;
                    issueList.DataBind();
                }

                if (grade != null)
                {
                    grade.Text = getItemName(item.Grade); //lookup
                }

                if (gender != null)
                {
                    gender.Text = g[e.Item.DataItemIndex];
                }

                if (evaluatedStatus != null)
                {
                    evaluatedStatus.Text = getItemName(item.EvaluationStatus); //lookup
                }
            }
        }

        protected string getItemName(Guid guid)
        {
            return Sitecore.Context.Database.GetItem(guid.ToString()).Name;
        }
    }
}
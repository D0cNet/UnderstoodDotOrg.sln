using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UnderstoodDotOrg.Command
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string parentName = null;
            string value = string.Empty;
            int id = 0;
            string csmId = string.Empty;
            bool isChild = false;
            List<string> attributeList = new List<string>();
            int attributeCount = 0;
            int listCount = 0;
            string attName = null;
            string attValue = null;
            bool isEmpty = false;
            int depth1 = 0;
            int depth2 = 0;
            int parentCount = 1;

            //string uri = "C:\\Users\\dallegrone\\Desktop\\Poses DB Project\\app2.xml";
            string uri = "http://api.commonsensemedia.org/api/v2/reviews/browse?api_key=534823b372928738c93803b534a7a770&channel=app&special_needs=1";
            XmlTextReader reader = new XmlTextReader(uri);
            while (reader.Read())
            {
                XmlNodeType nodeType = reader.NodeType;
                Console.Write("\r {0} Complete", id);
                switch (nodeType)
                {
                    case XmlNodeType.Element:

                        if (reader.Name == "id" && id != 0)
                        {
                            reader.Read();
                            csmId = reader.Value;
                            break;
                        }

                        if (parentCount == 0)
                        {
                            depth1 = reader.Depth;
                        }

                        if (parentCount != 0)
                        {
                            depth2 = reader.Depth;
                        }

                        if (depth1 < depth2)
                        {
                            depth1 = depth2;
                            parentName = name;
                            InsertToDB(name, null, csmId);
                            isChild = true;
                        }

                        if (depth2 < depth1)
                        {
                            depth1 = depth2;

                            if (depth1 != 1)
                            {
                                isChild = false;
                            }
                        }

                        if (depth1 == depth2)
                        {
                            if (isChild == true)
                            {
                            }
                        }

                        if (reader.Name == "entry")
                        {
                            id++;
                            break;
                        }

                        name = reader.Name;

                        if (reader.HasAttributes && id != 0)
                        {
                            if (reader.IsEmptyElement)
                            {
                                isEmpty = true;
                                InsertToDB(name, null, csmId);
                            }

                            if (reader.HasValue == false)
                            {
                                isEmpty = true;
                                InsertToDB(name, null, csmId);
                            }

                            for (int i = 0; i < reader.AttributeCount; i++)
                            {
                                attributeCount = (reader.AttributeCount) * 2;

                                reader.MoveToAttribute(i);

                                attributeList.Add(reader.Name);

                                attributeList.Add(reader.Value);

                                if (isEmpty == true)
                                {
                                    InsertAttrubuteToDB(reader.Name, reader.Value, GetDBItem("ItemID", "[Poses_Understood_DataImport].[dbo].[tbl_MediaReviewItem_Temp]", name, csmId));
                                    isEmpty = false;
                                }
                            }
                        }
                        parentCount++;
                        break;

                    case XmlNodeType.Text:

                        value = reader.Value;

                        if (name == "id" && id != 0)
                        {
                            csmId = reader.Value;
                        }

                        if (id != 0 && name != null && isChild == false)
                        {
                            InsertToDB(name, value, csmId);
                            UpdateDB(name, value, csmId);

                            if (attributeList.Count != 0)
                            {
                                int i = 0;

                                while (i < attributeCount)
                                {
                                    listCount++;

                                    if ((listCount % 2) != 0 || i == 0)
                                    {
                                        attName = attributeList[i];
                                    }

                                    if ((listCount % 2) == 0 && i != 0)
                                    {
                                        attValue = attributeList[i];
                                        InsertAttrubuteToDB(attName, attValue, GetDBItem("ItemID", "[Poses_Understood_DataImport].[dbo].[tbl_MediaReviewItem_Temp]", name, csmId));
                                    }
                                    i++;
                                }
                            }
                            listCount = 0;
                            attributeCount = 0;
                            attributeList.Clear();
                        }

                        if (id != 0 && name != null && isChild == true)
                        {
                            string pItemId = GetDBItem("ItemID", "[Poses_Understood_DataImport].[dbo].[tbl_MediaReviewItem_Temp]", parentName, csmId);
                            InsertChildToDB(pItemId, name, value, "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        }

                        break;

                    case XmlNodeType.CDATA:

                        value = reader.Value;

                        if (id != 0 && name != null)
                        {
                            InsertToDB(name, value, csmId);
                            UpdateDB(name, value, csmId);
                        }

                        if (id != 0 && name != null && isChild == true)
                        {
                            string pItemId = GetDBItem("ItemID", "[Poses_Understood_DataImport].[dbo].[tbl_MediaReviewItem_Temp]", parentName, csmId);
                            InsertChildToDB(pItemId, name, value, "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        }

                        if (attributeList.Count != 0)
                        {
                            for (int i = 0; i < attributeCount; i++)
                            {
                                listCount++;

                                if ((listCount % 2) != 0 || i == 0)
                                {
                                    attName = attributeList[i];
                                }

                                if ((listCount % 2) == 0 && i != 0)
                                {
                                    attValue = attributeList[i];
                                    InsertAttrubuteToDB(attName, attValue, GetDBItem("ItemID", "[Poses_Understood_DataImport].[dbo].[tbl_MediaReviewItem_Temp]", name, csmId));
                                }
                            }
                        }
                        listCount = 0;
                        attributeCount = 0;
                        attributeList.Clear();
                        break;
                }
            }
        }

        public static void InsertToDB(string name, string value, string csmId)
        {
            using (SqlConnection conn =
                        new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"INSERT tbl_MediaReviewItem_Temp (ItemName, ItemValue, CSMReviewItemID, ImportStatusID, ReviewID) 
                        VALUES (@name, @value, @csmRev, @importStatus, @reviewId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@value", value);
                        cmd.Parameters.AddWithValue("@csmRev", csmId);
                        cmd.Parameters.AddWithValue("@importStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        cmd.Parameters.AddWithValue("@reviewId", "B77B8C7D-B89C-4E6E-9CCE-1FAA2C092941");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Insert Failed
                }

            }
        }

        public static void InsertAttrubuteToDB(string attName, string attValue, string id)
        {
            using (SqlConnection conn =
                        new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                if (attValue == null)
                {
                    attValue = string.Empty;
                }
                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"INSERT tbl_MediaReviewItemAttribute_Temp (ParentItemID, AttributeName, AttributeValue, ImportStatusID) 
                        VALUES (@id, @name, @value, @importStatus)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", attName);
                        cmd.Parameters.AddWithValue("@value", attValue);
                        cmd.Parameters.AddWithValue("@importStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Insert Failed
                }
            }
        }

        public static void InsertChildToDB(string pItemId, string cItemName, string cItemValue, string importStatusId)
        {
            using (SqlConnection conn =
                        new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"INSERT tbl_MediaReviewItemChildren_Temp (ParentItemID, ChildItemName, ChildItemValue, ImportStatusID) 
                        VALUES (@pItemId, @cItemName, @cItemValue, @importStatusId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@pItemId", pItemId);
                        cmd.Parameters.AddWithValue("@cItemName", cItemName);
                        cmd.Parameters.AddWithValue("@cItemValue", cItemValue);
                        cmd.Parameters.AddWithValue("@importStatusId", importStatusId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Insert Failed
                }

            }
        }

        public static void UpdateDB(string name, string value, string csmId)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd =
                        new SqlCommand(@"UPDATE tbl_MediaReviewItem_Temp SET ItemName=@NewName, ItemValue=@NewValue,
                                    CSMReviewItemID=@NewCsmRev, ImportStatusID=@NewImportStatus, ReviewID=@NewReviewID 
                                    WHERE ItemName=@NewName AND ItemValue=@NewValue AND CSMReviewItemID=@NewCsmRev", conn))
                    {
                        cmd.Parameters.AddWithValue("@NewName", name);
                        cmd.Parameters.AddWithValue("@NewValue", value);
                        cmd.Parameters.AddWithValue("@NewCsmRev", csmId);
                        cmd.Parameters.AddWithValue("@NewImportStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        cmd.Parameters.AddWithValue("@NewReviewID", "B77B8C7D-B89C-4E6E-9CCE-1FAA2C092941");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Update Failed
                }
            }
        }

        public static void UpdateDBChild(string name, string value, string csmId)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd =
                        new SqlCommand(@"UPDATE tbl_MediaReviewItem_Temp SET ItemName=@NewName, ItemValue=@NewValue,
                                    CSMReviewItemID=@NewCsmRev, ImportStatusID=@NewImportStatus, ReviewID=@NewReviewID 
                                    WHERE ItemName=@NewName AND ItemValue=@NewValue AND CSMReviewItemID=@NewCsmRev", conn))
                    {
                        cmd.Parameters.AddWithValue("@NewName", name);
                        cmd.Parameters.AddWithValue("@NewValue", value);
                        cmd.Parameters.AddWithValue("@NewCsmRev", csmId);
                        cmd.Parameters.AddWithValue("@NewImportStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        cmd.Parameters.AddWithValue("@NewReviewID", "B77B8C7D-B89C-4E6E-9CCE-1FAA2C092941");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Update Failed
                }
            }
        }

        public static string GetDBItem(string item, string table, string name, string csmId)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                string itemId = string.Empty;

                conn.Open();

                try
                {
                    using (SqlCommand cmd =
                new SqlCommand(@"SELECT " + item + @" FROM " + table +
                    " WHERE ItemName='" + name + "' AND CSMReviewItemID='" + csmId + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();

                        itemId = reader["ItemID"].ToString();

                        reader.Close();

                        return itemId;
                    }
                }
                catch (SqlException ex)
                {
                    //Get Item Failed
                    return null;
                }
            }
        }
    }
}


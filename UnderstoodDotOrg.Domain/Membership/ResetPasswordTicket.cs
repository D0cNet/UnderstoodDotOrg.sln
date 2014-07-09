using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Membership
{
    public class ResetPasswordTicket
    {
        private string _ResetTicketID;
        private string _UserID;
        private string _CreatedOn;
        private bool _Used;
        private string _IP;

        private string _Status;

        public string ResetTicketID
        {
            get
            {
                return _ResetTicketID;
            }
        }

        public string UserID{
            get
            {
                return _UserID;
            }
        }

        public string CreatedOn{
            get
            {
                return _CreatedOn;
            }
        }

        public bool Used{
            get
            {
                return _Used;
            }
        }

        public string IP
        {
            get
            {
                return _IP;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }
        }



        public ResetPasswordTicket(Guid UID)
        { //Make new password reset ticket for the User passed to the constructor

            _ResetTicketID = Guid.NewGuid().ToString();
            _UserID = UID.ToString();
            _CreatedOn = String.Format("{0:u}", DateTime.Now);
            _Used = false;
            _IP = "";

            string sqlInsert = "INSERT INTO PasswordResetTickets (ResetKey, UID, CreatedDate, UsedAction) VALUES (@ResetKey, @UID, @CreatedDate, 0)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResetKey", _ResetTicketID);
                        cmd.Parameters.AddWithValue("@UID", UserID);
                        SqlParameter CreatedDateParam = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                        CreatedDateParam.Value = DateTime.Parse(_CreatedOn);

                        cmd.Parameters.Add(CreatedDateParam);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                _Status = "Password Reset Email Expired";
            }




            
        }

        public ResetPasswordTicket(string ticketID)
        { //Get existing reset ticket based on ticketID passed in constructor
            _ResetTicketID = ticketID;
            string sql = "Select UID, CreatedDate, UsedAction, IPofUser FROM PasswordResetTickets WHERE ResetKey = @ResetTicketID";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResetTicketID", ResetTicketID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            _UserID = reader["UID"].ToString();
                            _CreatedOn = reader["CreatedDate"].ToString();
                            _Used = Boolean.Parse(reader["UsedAction"].ToString()) ? true : false;
                            _IP = reader["IPofUser"].ToString();

                            DateTime ticketCreatedDate = DateTime.Parse(_CreatedOn);
                            if (_Used || (DateTime.Now - ticketCreatedDate).Hours > 24)
                            {
                                _Status = "Password rest has expired";
                            }
                        }
                        else
                        {
                            _Status = "Password Reset Email Expired";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _Status = "Password Reset Email Expired";
            }
        }

        public void CompleteTicket(string IP)
        {
            string sql = "UPDATE PasswordResetTickets SET UsedAction=1,IPofUser=@IPofUser WHERE ResetKey=@ResetTicketID";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResetTicketID", ResetTicketID);
                        cmd.Parameters.AddWithValue("@IPofUser", IP);
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                _Status = "Update Failed";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using XoDataWeb.Models;
namespace XoDataWeb.Models
{
    public class DBContext
    {
        SqlConnection con;

        public DBContext()
        {
            con = new SqlConnection("Server=WINDOWS-SNAEAQL; Initial Catalog=csc; Persist Security Info = True; Integrated Security=True");
        }
        public bool AddData(DataMo db)
        {
            string str = "Insert Into XoData (Name,FatherName,MotherName) values('" + db.Name + "','" + db.FatherName + "','" + db.MotherName + "')";
            SqlCommand cmd = new SqlCommand( str ,con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i > 0)
            {
                return true;
            }
           else
            {
                return false;
            }
        }
        public bool Updatedata(DataMo db )
        {
            string str = "update  XoData Set Name='" + db.Name + "', FatherName='" + db.FatherName + "', MotherName='" + db.MotherName + "' Where Id="+db.ID;
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
          
        }
        public bool DeleteData(int id)
        {
            string str = "delete from XoData Where Id=" + id;
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if( i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<DataMo> GelAllData()
        {
            List<DataMo> ilist = new List<DataMo>();
            string str = " Select * from XoData";
            SqlCommand cmd = new SqlCommand(str,con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sda.Fill(dt);
            con.Close();
            foreach( DataRow dr in dt.Rows)
            {
                ilist.Add(new DataMo
                {
                    ID=Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    FatherName = Convert.ToString(dr["FatherName"]),
                    MotherName = Convert.ToString(dr["MotherName"]),

                });
            }
            return ilist;

        }
    }
}
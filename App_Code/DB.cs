using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Data;


/// <summary>
///dbClass 的摘要说明
/// </summary>
public class DbClass
{
    public DbClass()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    //下载于51aspx.com
    OleDbConnection mConn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    DataSet ds = new DataSet();

    #region Open
    /// <summary>
    /// Open
    /// </summary>
    public void Open()
    {
        try
        {
            if (mConn.State == ConnectionState.Closed)
            {
                mConn.Open();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion
    
    #region Close
    /// <summary>
    /// Close
    /// </summary>
    public void Close()
    {
        try
        {
            if (mConn.State == ConnectionState.Open)
            {
                mConn.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion
   
    #region GetComm
    /// <summary>
    /// GetComm
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public OleDbCommand GetComm(string strSql)
    {
        OleDbConnection conn = mConn;
        OleDbCommand comm = new OleDbCommand();
        try
        {
            comm.Connection = conn;
            comm.CommandText = strSql;
            comm.CommandType = CommandType.Text;
            return comm;
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion

    #region getTable
    /// <summary>
    /// getTable
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public DataTable getTable(string strSql, string tableName)
    {
        OleDbConnection conn = mConn;
       
            Open();
            OleDbCommand comm = new OleDbCommand(strSql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
            da.Fill(ds, tableName);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
       
       
    }
    #endregion

    #region ExecNonQuery
    /// <summary>
    /// ExecNonQuery
    /// </summary>
    /// <param name="comm"></param>
    public void ExecNonQuery(OleDbCommand comm)
    {
        try
        {
            Open();
            comm.ExecuteNonQuery();
            Close();
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion

    //DataSet ds = new DataSet();
    //OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
    //OleDbDataAdapter da;

    //public int addUser(string username,string pwd,string sex,string qq,string hobby,string identify,string rgTime) {
    //    if (conn.State == ConnectionState.Closed) {
    //        conn.Open();
    //    }
    //    OleDbCommand comm=new OleDbCommand("insert into users(username,pwd,sex,qq,hobby,identify,rgTime)values('"+username+"','"+pwd+"','"+sex+"','"+qq+"','"+hobby+"','"+identify+"','"+rgTime+"')",conn);
    //    da = new OleDbDataAdapter(comm);
    //    int i=comm.ExecuteNonQuery();

    //    if (conn.State == ConnectionState.Open) {
    //        conn.Close();
    //    }
    //    return i;
    //}
    //public void addArticle(string username,string title,string content,string writeTime) {
    //    if (conn.State == ConnectionState.Closed) {
    //        conn.Open();
    //    }
    //    //OleDbCommand comm = new OleDbCommand("insert into articles(username,title,content,writeTime) values('" + (Session["username"]) + "','" + title + "','" + content + "','" + writeTime + "') where username='" + (Session["username"]) + "'", conn);
    //    //int i = comm.ExecuteNonQuery();
    //    //if (i > 0){

    //    //}
    //    //else { 

    //    //}
    //    if (conn.State == ConnectionState.Open) {
    //        conn.Close();
    //    }
    //}
    //public DataTable result(int id,int count) {

    //    return ;
    //}
}
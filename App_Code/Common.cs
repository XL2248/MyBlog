using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

/// <summary>
///Common 的摘要说明
/// </summary>
public class Common{

	public Common(){
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //定义一种方法，返回常用的字符串
    //public string msgBox(string txtMessage, string Url){
    //    string str;
    //    str = "<script language=javascript>alert('" + txtMessage + "');location='" + Url + "';</script>";
    //    return str;
    //}

    //OleDbConnection conn = new OleDbConnection("server=.;dataset=blog;uid=sa;pwd=123456");
    DataSet ds = new DataSet();

    //public OleDbConnection getConn() {
    //    OleDbConnection conn = new OleDbConnection("server=.;dataset=blog;uid=sa;pwd=123456");
    //    return conn;
    //}

    //public OleDbCommand getCmd(string strSQL) {
    //    OleDbCommand cmd = new OleDbCommand(strSQL,conn);
    //    return cmd;
    //}

    //public void Open() {
    //    if (conn.State == ConnectionState.Closed) {
    //        conn.Open();
    //    }
    //}

    //public void Closed() {
    //    if (conn.State == ConnectionState.Open) {
    //        conn.Close();
    //    }
    //}

    //public OleDbDataAdapter getDa(string strSQL) {
    //    OleDbDataAdapter da = new OleDbDataAdapter();
    //}

    //public DataTable getTable(string strSQL,string tbname) {
    //    getCmd(strSQL);
    //    OleDbDataAdapter da = new OleDbDataAdapter();
    //    da.Fill(ds,tbname);
    //    return ds.Tables[0];
    //}

    //定义一种方法，返回常用的字符串
    public string msgBox(string txtMessage, string Url) {
        string str;
        str = "<script language=javascript>alert('" + txtMessage + "');location='" + Url + "';</script>";
        return str;
    }


    //定义一种方法，返回常用的字符串
    public string msgBoxPage(string txtMessage){
        string str;
        str = "<script language=javascript>alert('" + txtMessage + "');location='javascript:history.go(-1)';</script>";
        return str;
    }

    //定义一种方法返回整形
    public static int AddCounts(string articleID,string userName) {

        OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["conn"]);
            OleDbCommand comm = new OleDbCommand("update word set counts=counts+1  where ID=" + articleID, conn);
            OleDbCommand cmd = new OleDbCommand("select * from word  where ID=" + articleID, conn);
                  
            if (conn.State == ConnectionState.Closed) {
                conn.Open();
            }
       
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds,"articles");
        int count = 0;
        count = int.Parse(ds.Tables["articles"].Rows[0]["counts"].ToString());
        //如果不是作者本人阅读 ，文章点击次数加1次 否则不加
        if (userName != ds.Tables["articles"].Rows[0]["username"].ToString())
        {
            count += 1;
            OleDbCommand comm1 = new OleDbCommand("update articles set counts='" + count + "' where articleId=" + articleID, conn);
            comm1.ExecuteNonQuery();
            OleDbCommand comm2 = new OleDbCommand("select counts from articles where articleId=" + articleID, conn);
            OleDbDataAdapter da2 = new OleDbDataAdapter(comm);
            da.Fill(ds, "article1");
            count = int.Parse(ds.Tables["articles"].Rows[0]["counts"].ToString());
        }
        
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        return count;
    }


    public string random(int n) 
    {
        //定义一个包括数字、大写英文字母和小写英文字母的字符串
        string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        //将strchar字符串转化为数组
        //String.Split 方法返回包含此实例中的子字符串（由指定Char数组的元素分隔）的 String 数组。
        string[] arrVc = strchar.Split(',');
        string vNum = "";
        //记录上次随机数值，尽量避免产生几个一样的随机数           
        int temp = -1;
        //采用一个简单的算法以保证生成随机数的不同
        Random rand = new Random();
        for (int i = 1; i < n + 1; i++){
            if (temp != -1){
                //unchecked 关键字用于取消整型算术运算和转换的溢出检查。
                //DateTime.Ticks 属性获取表示此实例的日期和时间的刻度数。
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            //Random.Next 方法返回一个小于所指定最大值的非负随机数。
            int t = rand.Next(61);
            if (temp != -1 && temp == t){
                return random(n);
            }
            temp = t;
            vNum += arrVc[t];
        }
        return vNum;//返回生成的随机数
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;


namespace JSOA.WebSite.Test
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("nihao2<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("nihao2<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("nihao3<br/>");
        }
    

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="maillAddr">地址</param>
        /// <param name="title">标题</param>
        /// <param name="doc">内容</param>
        //public  void SendMail(string maillAddr, string title, string doc)
        //{
        //    System.Net.Mail.MailMessage myEmail = new System.Net.Mail.MailMessage();
        //    myEmail.From = new System.Net.Mail.MailAddress("zhi.a.zhang@jci.com", "流程审批提醒", System.Text.Encoding.UTF8);

        //    myEmail.To.Add(maillAddr);
        //    myEmail.Subject = title;
        //    myEmail.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码

        //    myEmail.Body = doc;
        //    myEmail.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码
        //    myEmail.IsBodyHtml = true;//是否是HTML邮件

        //    myEmail.Priority = MailPriority.High;//邮件优先级

        //    SmtpClient client = new SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential(SystemConfig.GetValByKey("SendEmailAddress", ""),
        //        SystemConfig.GetValByKey("SendEmailPass", ""));

        //    //上述写你的邮箱和密码
        //    //client.Port = SystemConfig.GetValByKeyInt("SendEmailPort", 587); //使用的端口
        //    client.Host = SystemConfig.GetValByKey("SendEmailHost", "");
        //    client.EnableSsl = false; //经过ssl加密.
        //    object userState = myEmail;
        //    try
        //    {
        //        client.Send(myEmail);

        //        //   client.SendAsync(myEmail, userState);
        //    }
        //    catch (System.Net.Mail.SmtpException ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
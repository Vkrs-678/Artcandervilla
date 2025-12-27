using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.IO;
using System.Web.UI;

namespace RazorpaySampleApp.SendmailClass
{
    public class Sendmail
    {
        private static readonly string frommail = "artcandervilla@gmail.com";
        public  void Email(string htmlString,string tomail,string Subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(frommail);
                message.To.Add(new MailAddress(tomail));
                message.Subject = Subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = htmlString;
                
                //message.Attachments.Add(new Attachment());
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
               
               
              
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(frommail, "vhnh sous ynao spny");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void Email(string htmlString, string tomail, string Subject,string path)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(frommail);
                message.To.Add(new MailAddress(tomail));
                message.Subject = Subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = htmlString;

                message.Attachments.Add(new Attachment(path));
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(frommail, "vhnh sous ynao spny");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EmailWithImgae( string tomail, string Subject, AlternateView htmlview)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(frommail);
                message.To.Add(new MailAddress(tomail));
                message.Subject = Subject;
                message.IsBodyHtml = true; //to make message body as html
               // message.Body = htmlString;
                message.AlternateViews.Add(htmlview);
                //message.Attachments.Add(new Attachment());
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host

                message.Attachments.Contains(null);
                message.AlternateViews.Add(htmlview);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(frommail, "vhnh sous ynao spny");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using SendingEmail.UsersClasses;

namespace SendingEmail.UsersClasses
{
    public class SendingEmail
    {
        private InfoEmail InfoEmail { get; set; }
        public SendingEmail(InfoEmail infoEmail)
        {
            InfoEmail = infoEmail
            ?? throw new ArgumentNullException(nameof(infoEmail));
        }
        public void Send() 
        {
            try
            {
                SmtpClient mysmtpClient = new SmtpClient(InfoEmail.SmtpClientAdress);
                mysmtpClient.UseDefaultCredentials = false;
                mysmtpClient.EnableSsl = true;
                
                if (InfoEmail.Port != -1)
                    mysmtpClient.Port = InfoEmail.Port;

                NetworkCredential basicAuthenticationInfo = new NetworkCredential(InfoEmail.EmailAdressFrom.EmailAdress, InfoEmail.EmailPassword);
                mysmtpClient.Credentials = basicAuthenticationInfo;

                MailAddress from = new MailAddress(InfoEmail.EmailAdressFrom.EmailAdress, InfoEmail.EmailAdressFrom.Name);
                MailAddress to = new MailAddress(InfoEmail.EmailAdressTo.EmailAdress, InfoEmail.EmailAdressTo.Name);
                MailMessage myMail = new MailMessage(from, to);

                MailAddress replyTo = new MailAddress(InfoEmail.EmailAdressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyTo);
                Encoding encoding = Encoding.UTF8;
                myMail.Subject = InfoEmail.Subject;
                myMail.SubjectEncoding = encoding;

                mysmtpClient.Send(myMail);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

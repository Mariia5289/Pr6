using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingEmail.UsersClasses
{
    public class InfoGMail : InfoEmail
    {
        public InfoGMail(StringPair emailAdressTo, string subject, string body)
            : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.gmail.com";
            EmailAdressFrom = new StringPair("klopovamash@gmail.com", "Клопова Мария Михайловна");
            EmailPassword = "krwu saia urvj cqpc";
            Port = 578;
        }
    }
}

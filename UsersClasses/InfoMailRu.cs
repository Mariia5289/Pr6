using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingEmail.UsersClasses
{
    public class InfoMailRu : InfoEmail
    {
        public InfoMailRu(StringPair emailAdressTo, string subject, string body)
            : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.mail.ru";
            EmailAdressFrom = new StringPair("testsend.00@mail.ru", "Клопова Мария Михайловна");
            EmailPassword = "JfnzGSz8TCHC30s6jzar";
            Port = -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Models.Other
{
    public class EmailSenderData
    {
        public string EmailAddressSender { get; set; }
        public string EmailPassword { get; set; }
        public string EmailLoginSender { get; set; }
        public string SmtpServerHost { get; set; }
        public int SmtpServerPort { get; set; }
    }
}

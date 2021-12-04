using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TavolgaAPI.Models.Other;

namespace TavolgaAPI.Services
{
    public class EmailService
    {
        private readonly EmailSenderData _senderData;
        private readonly ILogger _logger;
        public EmailService(IOptions<EmailSenderData> senderData, ILogger<EmailService> logger)
        {
            _senderData = senderData.Value;
            _logger = logger;
        }
        public void SendMessage(string toEmail, string subject, string body, bool isBodyHtml = false)
        {
            try
            {
                MailAddress from = new MailAddress(_senderData.EmailAddressSender);
                MailAddress to = new MailAddress(toEmail);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = isBodyHtml;

                SmtpClient smtp = new SmtpClient(_senderData.SmtpServerHost, _senderData.SmtpServerPort);
                smtp.Credentials = new NetworkCredential(_senderData.EmailLoginSender, _senderData.EmailPassword);
                smtp.EnableSsl = true;
                //smtp.Timeout = 5000;
                smtp.Send(m);
            }
            catch(Exception e)
            {
                _logger.LogError($"Email message was bad!\n{e.Message}");
            }
        }
    }
}

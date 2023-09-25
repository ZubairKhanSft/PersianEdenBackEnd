using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using PersianEden.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfigurationSection _smtpConfiguration;
        public EmailService(IConfiguration configuration)
        {
            _smtpConfiguration = configuration.GetSection("smtp");
        }

        private async Task SendAsync(MimeMessage message)
        {
            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(_smtpConfiguration["Host"], Convert.ToInt32(_smtpConfiguration["Port"]), false);
                smtpClient.AuthenticationMechanisms.Clear();
                smtpClient.AuthenticationMechanisms.Add("PLAIN");
                await smtpClient.AuthenticateAsync(_smtpConfiguration["Username"], _smtpConfiguration["Password"]);
                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);
            }
        }

        public async Task SendAsync(string receiver, string senderName, string senderEmail, string subject, string mailBody)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(senderName ?? _smtpConfiguration["SenderName"], senderEmail ?? _smtpConfiguration["SenderEmail"]));
            mimeMessage.To.Add(new MailboxAddress(receiver));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new BodyBuilder { HtmlBody = mailBody }.ToMessageBody();
            await SendAsync(mimeMessage);
        }

        public async Task SendWithAttachmentAsync(string email, string subject, string mailBody, string path)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_smtpConfiguration["SenderName"], _smtpConfiguration["SenderEmail"]));
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.Subject = subject;
            var body = new TextPart("plain")
            {
                Text = mailBody
            };
            var attachment = new MimePart("application/pdf")
            {
                Content = new MimeContent(File.OpenRead(path)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(path)
            };
            var multipart = new Multipart();
            multipart.Add(body);
            multipart.Add(attachment);
            mimeMessage.Body = multipart;
            await SendAsync(mimeMessage);
        }

    }
}

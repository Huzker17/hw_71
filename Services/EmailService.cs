﻿using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "exaamplee123@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("exaamplee123@mail.ru", "iq9kLCFx2FarHWr56RwF");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}

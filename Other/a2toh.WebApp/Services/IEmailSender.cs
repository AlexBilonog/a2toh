﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace a2toh.WebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

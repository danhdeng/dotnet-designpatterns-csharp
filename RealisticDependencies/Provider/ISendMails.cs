using RealisticDependencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealisticDependencies.Provider;

    interface ISendMails
    {
    public Task SendMessage(EmailMessage message);
    }


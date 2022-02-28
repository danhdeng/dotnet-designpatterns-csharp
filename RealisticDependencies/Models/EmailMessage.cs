using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealisticDependencies.Models;
public class EmailMessage
{
    public string To { get; set; }
    public string Content { get; set; }

    public EmailMessage(string to, string content) {
        To = to;
        Content = content;
    }
}



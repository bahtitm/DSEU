using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DSEU.Application.Common.Models
{
    public class EmailAttachments
    {
        public string Name { get; set; }
        public Stream Data { get; set; }

    }
}

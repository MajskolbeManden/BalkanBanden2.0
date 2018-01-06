﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class MessageModel
    {
        public int MessageID { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Sender { get; set; }
        public int GroupID { get; set; }
    }
}
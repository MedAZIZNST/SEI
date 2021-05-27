using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.ViewModel
{
    public class ParametreSmtpEmailVM
    {
        public int IdSmtp { get; set; }
        public DateTime DateParametrage { get; set; }
        public string Smtp { get; set; }
        public string ServeurSmtp { get; set; }
        public string PortSmtp { get; set; }
        public string MotPasseSmtp { get; set; }
    }
}

﻿using EsgFiskDll.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical.ApiCalls
{
    public class reqHeader
    {
        public string SendDateTime { get; set; }

    }

    public class certificate
    {
        public string CertificatePassword { get; set; }
        public string CertificatePath { get; set; }
        public string CertificateData { get; set; }
    }

    public class RequestBase
    {
        public RequestBase(FiskConfigs Configs)
        {

            Header = new reqHeader { SendDateTime = System.DateTime.Now.ToString("o") };
            if (Configs.IsServiceTest == true)
            {
                Certificate = new certificate { CertificatePassword = Configs.CertificatePassword, CertificatePath = Configs.CertificatePath};
            }
            else
            {
                Certificate = new certificate { CertificatePassword = Configs.CertificatePassword, CertificateData = Configs.CertificateData};
            }
            IsServiceTest = Configs.IsServiceTest;
                
        }
        public reqHeader Header { get; set; }
        public certificate Certificate { get; set; }
        public bool IsServiceTest { get; set; }

    }
}

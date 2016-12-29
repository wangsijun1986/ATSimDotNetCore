using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;

namespace ATSimCommon
{
    public class Encryption
    {
        private static IDataProtector protector;

        public string EncryptValue(string value)
        {
            return protector.Protect(value);
        }

        public string DecryptValue(string value)
        {
            return protector.Unprotect(value);
        }

        public void CreateProtector(IDataProtectionProvider provider)
        {
            if (protector == null)
            {
                protector = provider.CreateProtector("DotNetCore.Common.Encryption");
            }
        }
    }
}

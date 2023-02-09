﻿using Microsoft.EntityFrameworkCore;

namespace DI.Test.Data.Entities
{
    [Owned]
    public partial class Login
    {
        public string Uuid { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Md5 { get; set; }

        public string Sha1 { get; set; }

        public string Sha256 { get; set; }
    }
}

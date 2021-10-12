using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMasters.Options
{
    public class JWTOptions
    {
        public SecurityKey SecurityKey { get; set; }
    }
}

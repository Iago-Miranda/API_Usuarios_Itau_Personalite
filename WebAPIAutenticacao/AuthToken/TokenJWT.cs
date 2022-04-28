using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAutenticacao.AuthToken
{
    public class TokenJWT
    {
        private JwtSecurityToken token;

        internal TokenJWT(JwtSecurityToken token)
        {
            this.token = token;
        }

        public DateTime ValidoAte => token.ValidTo;

        public string valor => new JwtSecurityTokenHandler().WriteToken(this.token);
    }
}

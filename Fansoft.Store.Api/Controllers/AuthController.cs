using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fansoft.Store.Api.Models;
using Fansoft.Store.Api.Models.AuthCtrlVM;
using Fansoft.Store.Api.Models.UsuarioCtrlVM;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fansoft.Store.Api.Controllers
{
    public class AuthController: ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly SecuritySettings _securitySettings;

        public AuthController(
            IUsuarioRepository usuarioRepository,
            //IOptions<SecuritySettings> securitySettings
            SecuritySettings securitySettings
            )
        {
            _usuarioRepository = usuarioRepository;
            _securitySettings = securitySettings;//.Value;
        }
        
        [HttpPost("api/v1/signin")]
        public async Task<IActionResult> SignIn([FromBody]PostCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var data = await _usuarioRepository.GetByEmailAsync(command.Email);

            if (data==null || data.Senha != command.Senha.Encrypt())
            {
                    return Unauthorized("Usuário ou senha inválidos");
            }

            var token = gerarToken(data.ToVM());

            return Ok(token);
        }

        private string gerarToken(GetAll usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securitySettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>{
                new Claim("id", usuario.Id.ToString()),
                new Claim("nome", usuario.Nome),
                new Claim("email", usuario.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _securitySettings.Emissor,
                audience: _securitySettings.ValidoEm,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_securitySettings.ExpiracaoHoras),
                notBefore: DateTime.UtcNow,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
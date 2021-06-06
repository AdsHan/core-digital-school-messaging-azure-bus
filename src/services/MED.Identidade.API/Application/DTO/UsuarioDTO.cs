using System;

namespace MED.Identidade.API.Application.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
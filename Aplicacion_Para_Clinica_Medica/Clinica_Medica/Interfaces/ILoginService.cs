using Modelos;

namespace Clinica_Medica.Interfaces
{
    public interface ILoginService
    {
        Task<bool> ValidarUsuario(Login login);
    }
}

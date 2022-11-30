using Clinica_Medica.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Clinica_Medica.Service
{
    public class LoginService : ILoginService
    {
        private readonly Config _configuracion;
        private ILoginRepositorio loginRepositorio;

        public LoginService(Config config)
        {
            _configuracion = config;
            loginRepositorio = new LoginRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ValidarUsuario(Login login)
        {
            return await loginRepositorio.ValidarUsuario(login);
        }
    }
}

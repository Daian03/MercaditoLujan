using MercaditoLujanWEB.Entities;

namespace MercaditoLujanWEB.Services
{
    public interface IUsuariosModel
    {
        Respuesta? RegistrarUsuario(Usuarios entidad);
        UsuarioRespuesta? IniciarSesion(Usuarios entidad);
        UsuarioRespuesta? RecuperarAcceso(Usuarios entidad);
        UsuarioRespuesta? CambiarContrasenna(Usuarios entidad);
    }
}

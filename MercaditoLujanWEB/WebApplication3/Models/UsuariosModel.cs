using MercaditoLujanWEB.Entities;
using MercaditoLujanWEB.Services;
using System.Net.Http.Headers;


namespace MercaditoLujanWEB.Models
{
    public class UsuariosModel(HttpClient _http, IConfiguration _configuration,
                                IHttpContextAccessor _sesion) : IUsuariosModel
    {
        public UsuarioRespuesta? IniciarSesion(Usuarios entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuarios/IniciarSesion";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }
        public Respuesta? RegistrarUsuario(Usuarios entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuarios/RegistrarUsuario";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? RecuperarAcceso(Usuarios entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuarios/RecuperarAcceso";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? CambiarContrasenna(Usuarios entidad)
        {
            string url = _configuration.GetSection("settings:UrlApi").Value + "api/Usuarios/CambiarContrasenna";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _http.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }
    }
}

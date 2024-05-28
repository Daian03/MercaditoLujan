namespace MercaditoLujanAPI.Entities
{
    public class Usuarios
    {
        public long IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? CedulaUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Contrasenna { get; set; }
        public string? Telefono { get; set; }
        public short IdRol { get; set; }
        public string? NombreRol { get; set; }
        public string? Token { get; set; }
        public bool? Estado { get; set; }
        public bool? EsTemporal { get; set; }
        public string? ContrasennaTemporal { get; set; }
    }

    public class UsuarioRespuesta
    {
        public UsuarioRespuesta()
        {
            Codigo = "00";
            Mensaje = string.Empty;
            Dato = null;
            Datos = null;
        }

        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public Usuarios? Dato { get; set; }
        public List<Usuarios>? Datos { get; set; }
    }
}
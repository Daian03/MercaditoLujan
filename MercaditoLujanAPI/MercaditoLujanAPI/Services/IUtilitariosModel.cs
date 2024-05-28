namespace MercaditoLujanAPI.Services
{
    public interface IUtilitariosModel
    {
        string Encrypt(string texto);

        public string Decrypt(string texto);

        string? GenerarToken(long IdUsuario);

        string GenerarCodigo();

        void EnviarCorreo(string Destinatario, string Asunto, string Mensaje);
    }
}


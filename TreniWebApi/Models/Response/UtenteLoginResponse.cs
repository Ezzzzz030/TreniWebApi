namespace TreniWebApi.Models.Response
{
    public class UtenteLoginResponse
    {
        public string TokenSession { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

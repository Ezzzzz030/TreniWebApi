namespace TreniWebApi.Models.Response
{
    public class UtenteLoginResponse
    {
        public int IdUser { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public DateTime TokenExpirationDate { get; set; }
        public string TokenSession { get; set; } = string.Empty;
    }
}

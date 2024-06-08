using System.ComponentModel.DataAnnotations;

namespace TreniWebApi.Models.Requests
{
    public class StazioneRegistrationRequest
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Indirizzo { get; set; }
    }
}

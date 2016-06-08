
namespace Hambasafe.Api.Models.v1
{
    public class UserIdentificationModel
    {
        public int UserId { get; set; }

        public string FileExtension { get; set; }

        public string Base64Data { get; set; }
    }
}

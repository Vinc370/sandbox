using System.ComponentModel.DataAnnotations;

namespace dotnet.Models
{
    public class DapperModel
    {
        public Database database { get; set; }

        public UserData userData { get; set; }
    }
}

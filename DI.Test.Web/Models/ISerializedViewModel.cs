using System.Text.Json;

namespace DI.Test.Web.Models
{
    public interface ISerializedViewModel
    {
        string Serialize(JsonSerializerOptions options);
    }
}

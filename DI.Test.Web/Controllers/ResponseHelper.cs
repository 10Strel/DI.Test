using DI.Test.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DI.Test.Web.Controllers
{
    public abstract class BaseResponse
    {
        protected bool _isSerialized = false;

        public readonly JsonSerializerOptions _serializeOptions;

        public string Json { get; protected set; }

        public BaseResponse()
        {
            _serializeOptions = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            };
        }

        public string GetJson => _isSerialized ? Json : $"{{ {Json} }}";
    }

    public class ResponseSuccess : BaseResponse
    {
        private readonly string _message;

        public ResponseSuccess(ISerializedViewModel item) : base()
        {
            _isSerialized = true;

            Json = item.Serialize(options: _serializeOptions);
        }

        public ResponseSuccess(string message) : base()
        {
            this._message = message;

            Json = $"[\"{_message}\"]";
        }
    }

    public class ResponseError : BaseResponse
    {
        private readonly string _key;
        private readonly string _message;

        public ResponseError(string key, string message) : base()
        {
            this._key = key;
            this._message = message;

            Json = $"\"{_key}\":[\"{_message}\"]";
        }
    }

    public class ResponseErrorList : List<ResponseError>
    {
        public ResponseErrorList(List<ResponseError> list)
        {
            this.AddRange(list);
        }

        public string GetJson => $"{{ {string.Join(',', this.Select(s => s.Json))} }}";
    }

    public class JsonResponse
    {
        private readonly string _responseObject;

        private readonly HttpStatusCode _status;

        public string ResponseObject => _responseObject;

        public bool Success => ((int)_status >= 200 && (int)_status <= 299);

        public JsonResponse(string responseObject, HttpStatusCode status)
        {
            this._responseObject = responseObject;
            this._status = status;
        }
    }

    public class JsonResponseConverter : JsonConverter<JsonResponse>
    {
        public override JsonResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, JsonResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteBoolean("sucsess", value.Success);

            if (value.Success)
            {
                writer.WritePropertyName("result");
            }
            else
            {
                writer.WritePropertyName("error");
            }

            writer.WriteRawValue($"{value.ResponseObject}");

            writer.WriteEndObject();
        }
    }

    public static class ResponseHelper
    {
        private static JsonSerializerOptions SerializeOptions { get; }

        static ResponseHelper()
        {
            SerializeOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            SerializeOptions.Converters.Add(new JsonResponseConverter());
        }

        public static ObjectResult Success(string responseObject, HttpStatusCode status = HttpStatusCode.OK)
        {
            ObjectResult objectResult = new(JsonSerializer.Serialize(new JsonResponse(responseObject, status), SerializeOptions))
            {
                StatusCode = (int)status
            };

            objectResult.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/json;utf-8"));
            return objectResult;
        }

        public static ObjectResult Error(string? responseObject = null, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            ObjectResult objectResult = new(JsonSerializer.Serialize(new JsonResponse(responseObject, status), SerializeOptions))
            {
                StatusCode = (int)status
            };

            objectResult.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/json;utf-8"));
            return objectResult;
        }
    }
}

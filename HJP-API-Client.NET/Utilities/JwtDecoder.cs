using System.Text.Json;
using Hjp.Api.Client.Dto;

namespace Hjp.Api.Client.Utilities
{
    public static class JwtDecoder
    {
        public static JwtPayloadModel DecodePayload(string jwt)
        {
            var parts = jwt.Split('.');
            if (parts.Length < 2)
            {
                throw new ArgumentException("Invalid JWT format");
            }

            var payload = parts[1];

            // Base64URL → Base64変換
            payload = PadBase64(payload.Replace('-', '+').Replace('_', '/'));

            var bytes = Convert.FromBase64String(payload);
            var model = JsonSerializer.Deserialize<JwtPayloadModel>(bytes);

            if (model == null)
            {
                throw new InvalidOperationException("Failed to deserialize JWT payload.");
            }

            return model;
        }

        private static string PadBase64(string base64)
        {
            var padding = 4 - (base64.Length % 4);
            if (padding < 4)
            {
                base64 += new string('=', padding);
            }
            return base64;
        }
    }
}

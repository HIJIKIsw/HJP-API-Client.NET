using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Hjp.Api.Client.Common;

namespace Hjp.Api.Client.Utilities
{
    internal static class RequestUtility
    {
        public static string ToQueryString(object query)
        {
            if (query == null) return string.Empty;

            var properties = query.GetType().GetProperties();
            var sb = new StringBuilder();

            foreach (var property in properties)
            {
                var value = property.GetValue(query);
                if (value == null) continue;

                var name = Uri.EscapeDataString(property.Name);

                // MEMO: IEnumerableかつstringは除外（stringもIEnumerable<char>なので）
                if (value is IEnumerable enumerable && value is string == false)
                {
                    foreach (var item in enumerable)
                    {
                        if (item == null) continue;
                        sb.Append(sb.Length == 0 ? "?" : "&");
                        sb.Append($"{name}={Uri.EscapeDataString(item.ToString()!)}");
                    }
                }
                else
                {
                    sb.Append(sb.Length == 0 ? "?" : "&");
                    sb.Append($"{name}={Uri.EscapeDataString(value.ToString()!)}");
                }
            }

            return sb.ToString();
        }

        public static Dictionary<string, string> CreateSignatureHeaders(ulong discordUserId, string apiKey)
        {
            var result = new Dictionary<string, string>();

            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var nonce = Guid.NewGuid().ToString("N");

            var message = $"{discordUserId}:{timestamp}:{nonce}";
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(apiKey));
            var signature = Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(message)));

            result.Add(Constants.DiscordUserIdHeaderName, discordUserId.ToString()!);
            result.Add(Constants.NonceHeaderName, nonce);
            result.Add(Constants.TimestampHeaderName, timestamp.ToString()!);
            result.Add(Constants.SignatureHeaderName, signature);

            return result;
        }
    }
}
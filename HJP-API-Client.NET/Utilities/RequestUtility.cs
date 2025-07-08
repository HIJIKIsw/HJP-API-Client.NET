using System.Collections;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Hjp.Api.Client.Common;
using Hjp.Shared.Constants;

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

        public static Dictionary<string, string> CreateRequestHeaders(bool isIncludeNonce = true, string? signature = null)
        {
            var result = new Dictionary<string, string>();

            if (isIncludeNonce == true)
            {
                var nonce = Guid.NewGuid().ToString("N");
                result.Add(ApiConstants.HeaderNames.Nonce, nonce);
            }

            if (signature != null)
            {
                var headerName = HttpRequestHeader.Authorization.ToString();
                result.Add(headerName, new AuthenticationHeaderValue(ApiConstants.AuthenticationScheme, signature).ToString());
            }

            return result;
        }
    }
}
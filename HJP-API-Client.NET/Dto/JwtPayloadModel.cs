using System.Security.Claims;
using System.Text.Json.Serialization;
using Hjp.Shared.Constants;
using Hjp.Shared.Enums;

namespace Hjp.Api.Client.Dto
{
    public class JwtPayloadModel
    {
        [JsonPropertyName(ApiConstants.ClaimTypes.DiscordUserId)]
        private string discordUserIdString { get; set; } = "0";
        public ulong DiscordUserId
        {
            get => ulong.Parse(this.discordUserIdString);
            set => this.discordUserIdString = value.ToString();
        }

        [JsonPropertyName(ApiConstants.ClaimTypes.UserName)]
        public string UserName { get; set; } = null!;

        [JsonPropertyName(ApiConstants.ClaimTypes.AvatarUrl)]
        public string AvatarUrl { get; set; } = null!;

        [JsonPropertyName(ClaimTypes.Role)]
        private string roleString { get; set; } = PermissionType.User.ToString();
        public PermissionType Role
        {
            get => Enum.Parse<PermissionType>(this.roleString);
            set => this.roleString = value.ToString();
        }

        [JsonPropertyName("exp")]
        public long Expiration { get; set; }

        [JsonPropertyName("iss")]
        public string Issuer { get; set; } = null!;

        [JsonPropertyName("aud")]
        public string Audience { get; set; } = null!;
    }
}
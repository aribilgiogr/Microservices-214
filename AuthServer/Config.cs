using Duende.IdentityServer.Models;

namespace AuthServer
{
    public static class Config
    {
        // API Scope'ları (Erişilecek Kaynaklar):
        public static IEnumerable<ApiScope> ApiScopes => [new("api1", "API 01")];

        // İstemciler (Token Talep Edecek Uygulamalar):
        public static IEnumerable<Client> Clients => [
        new() {
            ClientId ="client",
            
            // Kullanıcı etkileşimi olmayan, machine-to-machine iletişim için.
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // Şifre (Secret): Gerçek hayatta bu değer iyi saklanmalıdır.
            ClientSecrets ={new Secret("secret".Sha256())},

            // Bu istemcinin erişebileceği scope'lar.
            AllowedScopes = {"api1"}
        } ];
    }
}

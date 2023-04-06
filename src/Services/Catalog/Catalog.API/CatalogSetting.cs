namespace Catalog.API;

public class CatalogSetting
{
    public string ConnectionString { get; set; }
    public int CheckUpdateTimeForEventPublinshWorker { get; set; }

    [ConfigurationKeyName("KEYCLOAK")]
    public KeyCloakSettingsRoot KeyCloakSettingsRoot { get; set; }
}

public class KeyCloakSettingsRoot
{
    public string Realm { get; set; }
    public string AuthServerUrl { get; set; }
    public string SslRequired{ get; set; }
    public string Resource { get; set; }
    public bool VerifyTokenAudience { get; set; }
    [ConfigurationKeyName("Credentials")]
    public CredentialsSettings CredentialsSettings { get; set; }

    public int ConfidentialPort { get; set; }
}

public class CredentialsSettings
{
    public string Secret { get; set; }
}
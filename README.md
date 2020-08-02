# Facebook SDK (Graph API C# Client)

Facebook SDK (C# Graph API Client) for Facebook Graph API

## How to start using the library?
You need to add Facebook section to your JSON configuration file with your ClientId and ClientSecret:

```json
{
  "Facebook": {
    "AppId": "100011113333444",
    "Secret": "12ab23bc34bee22f3e9ad9d431234567"
  }
}
```

In your dependency injection setup add Facebook client initialization code:

```c#
ServiceProvider = new ServiceCollection()
            .AddFacebookClient(options => config.GetSection("Facebook").Bind(options))
            .BuildServiceProvider();
```

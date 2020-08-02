# Facebook SDK (Graph API C# Client)
![.NET Core](https://github.com/devTaras/fb-dotnet-sdk/workflows/.NET%20Core/badge.svg?branch=master)
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

### Capabilities
The library support operation with application and user tokens (get, convert, debug) and can query basic information about the user.
You can use _IAccessTokenFbService_ or _IDebugTokenFbService_ for token operations.
_IUserFbService_ - get information about the user.

_ITestUserFbService_ - service for Test Users


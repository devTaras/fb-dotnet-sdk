# Facebook SDK (Graph API C# Client)
![.NET Core](https://github.com/devTaras/fb-dotnet-sdk/workflows/.NET%20Core/badge.svg?branch=master)

Facebook SDK (C# Graph API Client) for Facebook Graph API

Target: _.NET Standard 2.0_

Integration tests target: _.NET Core 3.1_

## Where is package? 
[GraphApi.Facebook.Client](https://www.nuget.org/packages/GraphApi.Facebook.Client/) - only prerelease version available

## How to start using the library?
You need to add Facebook section to your JSON configuration file with your ClientId and ClientSecret:

```json
{
  "Facebook": {
    "AppId": "168859494420616",
    "Secret": "36fe14d2c7a4e22f3e9ad9d436883518",
    "TestUserId": "101298791447225"
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


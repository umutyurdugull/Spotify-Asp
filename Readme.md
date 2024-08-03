If you want to use application first you need to change API key in the ``` applicaton.json ``` file. If you don't have an API key You need to go [Spotify Developer Platform](https://developer.spotify.com/dashboard), create an app get get your own client id and secret. <br>
Then update the ``` applicaton.json ``` file like this
``` {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Spotify": {
    "ClientId": "YOUR-CLIENT-ID",
    "ClientSecret": "YOUR-CLIENT-SECRET"
  },
  "AllowedHosts": "*"
}
```
And one last step open ``` \Spotify-Asp\SpotifyASP``` directory in your command prompt and write 
> dotnet watch



Now you're good to go! 
If you find any bugs or you have any ideas you can create a pull request anytime.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpotifyAPI.Web;

var builder = WebApplication.CreateBuilder(args);

var spotifyConfig = builder.Configuration.GetSection("Spotify").Get<SpotifyConfig>();

// Servisleri ekle
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(spotifyConfig);
builder.Services.AddSingleton<SpotifyClient>(provider =>
{
    var config = provider.GetRequiredService<SpotifyConfig>();
    var credentials = new ClientCredentialsRequest(config.ClientId, config.ClientSecret);
    var token = new OAuthClient().RequestToken(credentials).Result;
    return new SpotifyClient(token.AccessToken);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class SpotifyConfig
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}
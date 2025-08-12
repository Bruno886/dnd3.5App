using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TG.Blazor.IndexedDB;
using dnd3._5App;
using dnd3._5App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddIndexedDB(dbModel =>
{
    dbModel.DbName = "DnDApp";
    dbModel.Version = 1;
    dbModel.Stores.Add(new StoreSchema
    {
        Name = "characters",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = false }
    });
});

builder.Services.AddScoped<StorageService>();
builder.Services.AddScoped<RulesService>();

await builder.Build().RunAsync();

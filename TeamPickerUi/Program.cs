using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TeamPickerUi;
using TeamPickerUi.Logic;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ITeamStorage, TeamStorage>();
//builder.Services.AddScoped<IValidator<ITeamStorage>, TeamStorageValidation>();

await builder.Build().RunAsync();

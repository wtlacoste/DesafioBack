using Andreani.ARQ.AMQStreams.Extensions;
using Andreani.ARQ.WebHost.Extension;
using Andreani.Scheme.Onboarding;
using DesafioBackendAPI.Application;
using DesafioBackendAPI.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using DesafioBackendAPI.Infrastructure.Services;




var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins(builder.Configuration["URL_REACT_FRONT"]);
					  });
});

builder.Host.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services
    .AddKafka(builder.Configuration)
	.ToConsumer<Subscriber, Pedido>("PedidoAsignado1")
	.CreateOrUpdateTopic(6, names: "PedidoCreado1")
    .ToProducer<Pedido>("PedidoCreado1")

	.Build();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

app.ConfigureAndreani(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.Run();

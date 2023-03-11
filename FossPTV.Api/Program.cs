using FossPTV.Api;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

int developerId = builder.Configuration.GetValue("Credentials:DeveloperId", -1);

if (developerId == -1)
	throw new Exception("Developer ID is not set or is invalid.");

string? developerKey = builder.Configuration.GetValue<string>("Credentials:DeveloperKey");

if (string.IsNullOrWhiteSpace(developerKey))
	throw new Exception("Developer Key is not set or is invalid.");

PtvClient client = new PtvClient(developerId, developerKey);
builder.Services.AddSingleton(client);

WebApplication application = builder.Build();

if (application.Environment.IsDevelopment())
{
	application.UseSwagger();
	application.UseSwaggerUI();
}

application.UseHttpsRedirection();
application.UseAuthorization();
application.MapControllers();

application.Run();
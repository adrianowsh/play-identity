using Play.Identity.Service;
using Play.Identity.Service.HostedServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHostedService<IdentitySeedHostedService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMongodbIdentitySettings(builder.Configuration);
builder.Services.AddIdentityServerSettings(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseIdentityServer();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.Run();

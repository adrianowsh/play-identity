using Play.Identity.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
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

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder=WebApplication.CreateBuilder(args); // creates builder project
builder.Configuration.AddEnvironmentVariables(); // tells the .net env to read variables like PORT, JwtSecret )

builder.Services.AddControllers(); // to support controllers , speciasl c# classes that define routes 
builder.Services.AddCors(options=>{ // adding cors , 
    options.AddPolicy("AllowAll", new CorsPolicyBuilder().AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .Build() // here allowing all to access to access your server
    );
});

// setting up jwt authenctication middleware in app
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>{
        options.TokenValidationParameters= new TokenValidationParameters{
            ValidateIssuer=false,
            ValidateAudience=false,
            ValidateLifetime=true,
            ValidateIssuerSigningKey=true,
            IssuerSigningKey=new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSecret"] ?? "default_secretr")
            )
        };

    });



builder.Services.AddAuthorization();

var app=builder.Build();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.MapGet("/", async context => {
    await context.Response.WriteAsync("This is home route");
});

app.MapControllers();  // automatically maps conrtroller routes  /tenants , /props based on Route attributes inside the controller classes

var port=builder.Configuration.GetValue<int?>("PORT") ?? 3002;
app.Run($"http://0.0.0.0:{port}");




using CM.Community_Back_end.Services.PostService;
using CM.Community_Back_end.Services.UserService;
using System.Reflection;
using CM.Community_Back_end.Services.GroupService;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ably.HealthCheck;
using IO.Ably;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using CM.Community_Back_end.Services;
using System.Configuration;
using Ably;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using CM.Community_Back_end.Models;
using IO.Ably.Realtime;

var builder = WebApplication.CreateBuilder(args);

//if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production") {
//    builder.Services.AddDbContext<ApplicationDbContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//} else {
//    builder.Services.AddDbContext<ApplicationDbContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//}

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection1");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGroupService, GroupService>();

//var config = Configuration
//    .GetSection("Ably")
//    .Get<AblyConfig>();
//var ably = newAblyRealtime(config.ApiKey);

var config =
    builder.Configuration
    .GetSection("Ably");
var ably = new AblyRealtime("gh1Qig.JTwI_A:dLtqVFIPnlHf-qm0kCPD7F5A46NVfmh8P2jJVlrpKQE");

IRealtimeChannel channel = ably.Channels.Get(
    "realtime");
//channel.Presence.Enter("Alex entered the chat");
channel.Publish(
    "post",
    new Post { postID = 1, postText = "Hello World", groupID = 1, userID = 1, publicationDate = DateTime.Now });
//.AddCheck(
//    "AblyChannel",
//    new AblyChannelHealthCheck(
//        ably,
//        "Topic"
//    )
//)

var app = builder.Build();

// Configure the HTTP request pipeline.



if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseWebSockets();



//gh1Qig.JTwI_A:dLtqVFIPnlHf - qm0kCPD7F5A46NVfmh8P2jJVlrpKQE
app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();

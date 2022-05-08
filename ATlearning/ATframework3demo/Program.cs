using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.BaseFramework;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics;

if(args != default)
    EnvironmentSettings.AppArgs = args.ToList();
#pragma warning disable CS8604 // ��������, ��������-������, ����������� �������� NULL, ��� ��������� "args" � "WebApplicationBuilder WebApplication.CreateBuilder(string[] args)".
var builder = WebApplication.CreateBuilder(args);
#pragma warning restore CS8604 // ��������, ��������-������, ����������� �������� NULL, ��� ��������� "args" � "WebApplicationBuilder WebApplication.CreateBuilder(string[] args)".
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredModal();
#pragma warning disable CS8604 // ��������, ��������-������, ����������� �������� NULL, ��� ��������� "fileName" � "FileInfo.FileInfo(string fileName)".
#pragma warning disable CS8602 // ������������� ��������� ������ ������.
var currentProcFilePath = new FileInfo(Process.GetCurrentProcess().MainModule.FileName);
#pragma warning restore CS8602 // ������������� ��������� ������ ������.
#pragma warning restore CS8604 // ��������, ��������-������, ����������� �������� NULL, ��� ��������� "fileName" � "FileInfo.FileInfo(string fileName)".
#pragma warning disable CS8604 // ��������, ��������-������, ����������� �������� NULL, ��� ��������� "path1" � "string Path.Combine(string path1, string path2)".
builder.Environment.WebRootPath = Path.Combine(currentProcFilePath.DirectoryName, "wwwroot");
#pragma warning restore CS8604 // ��������, ��������-������, ����������� �������� NULL, ��� ��������� "path1" � "string Path.Combine(string path1, string path2)".
builder.Environment.ContentRootPath = currentProcFilePath.DirectoryName;
Environment.CurrentDirectory = currentProcFilePath.DirectoryName;
Log.WriteHtmlHeader(Log.commonLogPath);
Log.Info(">>>>New session started<<<<");
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();

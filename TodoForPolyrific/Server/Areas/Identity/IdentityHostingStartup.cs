using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoForPolyrific.Server.Data;
using TodoForPolyrific.Server.Models;

[assembly: HostingStartup(typeof(TodoForPolyrific.Server.Areas.Identity.IdentityHostingStartup))]
namespace TodoForPolyrific.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
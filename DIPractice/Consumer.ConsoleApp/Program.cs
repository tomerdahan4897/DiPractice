using System.Security.Authentication.ExtendedProtection;
using Consumer.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

//services.AddSingleton<IConsoleWriter, ConsoleWriter>();
//services.AddSingleton<IIdGenerator, IdGenerator>();
//services.AddTransient<ConsoleWriter>();
//services.AddSingleton(new IdGenerator(new ConsoleWriter()));

services.AddTransient<ConsoleWriter>();
services.AddTransient(provider => new IdGenerator(provider.GetService<ConsoleWriter>()!));

var serviceProvider = services.BuildServiceProvider();

var service1 = serviceProvider.GetRequiredService<IdGenerator>();
var service2 = serviceProvider.GetRequiredService<IdGenerator>();

service1.PrintId();
service2.PrintId();
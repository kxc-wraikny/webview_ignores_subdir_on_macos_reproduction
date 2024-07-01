using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace webview_ignores_subdir_on_macos_reproduction;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}

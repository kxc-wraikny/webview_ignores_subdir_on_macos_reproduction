namespace webview_ignores_subdir_on_macos_reproduction;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

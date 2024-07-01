using System.Diagnostics;

namespace webview_ignores_subdir_on_macos_reproduction;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		WebView.Navigated += (sender, args) => {
			Debug.WriteLine($"Navigated {args.NavigationEvent} - {args.Url}");
		};
	}

	private void SetIndex_clicked(object sender, EventArgs args)
	{
		WebView.Source = new UrlWebViewSource {
			Url="index.html",
		};
	}

	private void SetTest_clicked(object sender, EventArgs args)
	{
		WebView.Source = new UrlWebViewSource {
			Url="test.html",
		};
	}

	private void SetSubdirTest_clicked(object sender, EventArgs args)
	{
		WebView.Source = new UrlWebViewSource {
			Url="subdir/test.html",
		};
	}

	private async void SetSubdirTestWithWorkaround_clicked(object sender, EventArgs args)
	{
		WebView.Source = new UrlWebViewSource {
			Url=await GetCorrectPath("subdir/test.html"),
		};
	}

	private static async Task<string> GetCorrectPath(string path)
	{
		using var stream = await FileSystem.OpenAppPackageFileAsync(path);
		if (stream is FileStream f)
		{
			return f.Name;
		}

		throw new Exception($"Unexpected stream type: {stream.GetType()}");
	}
}

namespace Combination_lock;

public partial class MainPage : ContentPage
{
	string _code = "0601";
	public MainPage()
	{
		InitializeComponent();
	}

	private void DigitClicked(object sender, EventArgs e)
	{
		if (DisplayLabel.Text != "Верно!")
		{
			DisplayLabel.Text += (sender as Button).Text;
		}
	}
	private void ClearClicked(object sender, EventArgs e)
	{
		if (DisplayLabel.Text != "Верно!")
		{
			DisplayLabel.Text = "";
		}
	}
	private void ConfirmClicked(object sender, EventArgs e)
	{
		if (DisplayLabel.Text != "Верно!")
		{
			if (DisplayLabel.Text.Split('\n').Last() == "")
			{
				return;
			}
			if (DisplayLabel.Text.Split('\n').Last() == _code)
			{
				DisplayLabel.Text = "Верно!";

			}
			else
			{
				DisplayLabel.Text = "";
			}
		}
	}
}


namespace LightsOut
{
    public partial class MainPage : ContentPage
    {
        Button[,] buttons = new Button[5, 5];

        public MainPage()
        {
            InitializeComponent();
            
            Button[,] tempbuttons = {
                { b00, b10, b20, b30, b40 },
                { b01, b11, b21, b31, b41 },
                { b02, b12, b22, b32, b42 },
                { b03, b13, b23, b33, b43 },
                { b04, b14, b24, b34, b44 }
            };
            buttons = tempbuttons;
        }

        private void OnClick(object sender, EventArgs e)
        {
            void ChangeColor(Button btn)
            {
                if (btn.BackgroundColor == Colors.AntiqueWhite)
                    btn.BackgroundColor = Colors.Gray;
                else
                    btn.BackgroundColor = Colors.AntiqueWhite;
            }

            // Sprawdzanie jaki ma kolor i zmienianie wszystkich wokół na przeciwny
            int x = 0, y = 0;
            for (int i = 0; i < buttons.GetLength(0); i++)
                for (int j = 0; j < buttons.GetLength(1); j++)
                    if (buttons[i, j] == (Button)sender)
                    {
                        x = i;
                        y = j;
                    }

            // Zmienianie koloru płytek
            if (x > 0) ChangeColor(buttons[x - 1, y]);
            if (y > 0) ChangeColor(buttons[x, y - 1]);
            ChangeColor(buttons[x, y]);
            if (x < 4) ChangeColor(buttons[x + 1, y]);
            if (y < 4) ChangeColor(buttons[x, y + 1]);

            // Sprawdzanie czy plansza jest
            bool isWin = true;
            foreach (Button button in buttons)
                if (button.BackgroundColor != Colors.Gray)
                    isWin = false;

            if (isWin)
                DisplayAlert("Gratulacje!", "Wygrałeś gre LightsOut", "OK");
        }
    }

}

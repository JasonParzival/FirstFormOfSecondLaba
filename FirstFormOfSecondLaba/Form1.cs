namespace FirstFormOfSecondLaba
{
    public partial class Form1 : Form
    {
        //Установить, является ли последовательность цифр при просмотре
        //их слева направо упорядоченной по возрастанию. Например,
        //для последовательности 1,4,7,8 ответ положительный,
        //для чисел 1,7,8,2 и 1,6,6,8 — отрицательный и т.п
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.StringTextBox;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string message = Logic.IsDigitMessage(this.textBox1.Text);
            MessageBox.Show(message);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.StringTextBox = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button.PerformClick();
            }
        }
    }

    public class Logic
    {
        public static bool Check(string smth)
        {
            bool forif = true;
            for (int i = 1; i < smth.Length; i++)
            {
                if ((int)Char.GetNumericValue(smth[i - 1]) < (int)Char.GetNumericValue(smth[i]))
                {
                    forif = true;
                }
                else
                {
                    forif = false;
                    break;
                }
            }
            return forif;
        }

        public static string Message(string smth)
        {
            string message = "";

            if (Logic.Check(smth))
            {
                message = "Последовательность цифр: " + smth + " в порядке возрастания!";
            }
            else
            {
                message = "Последовательность цифр: " + smth + " в порядке убывания!";
            }
            return message;
        }

        public static string IsDigitMessage(string smth)
        {
            string message;

            if (smth.All(char.IsDigit))
            {
                message = Logic.Message(smth);
            }
            else
            {
                message = "Введённая строка не являются цифрой";
            }
            return message;
        }
    }
}

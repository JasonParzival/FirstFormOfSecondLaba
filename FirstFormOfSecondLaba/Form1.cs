namespace FirstFormOfSecondLaba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            string message = Logic.IsDigitMessage(this.textBox1.Text);
            MessageBox.Show(message);
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
                message = "Последовательность: " + smth + " положительна!";
            }
            else
            {
                message = "Последовательность: " + smth + " отрицательна!";
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

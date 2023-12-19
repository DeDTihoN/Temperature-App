using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Google.Cloud.Translation.V2;
using Newtonsoft.Json.Linq;
using MaterialSkin;
using MaterialSkin.Controls;

namespace CityTemperature
{
    public partial class Form1 : MaterialForm
    {
        private const string GoogleTranslateApiKey = "AIzaSyAqbcpU-ZU0K_krumb6wlijpKzud3Jpej4";
        private const string OpenWeatherMapApiKey = "76b6a91eaa1f27a40f0bff71376e1b55";
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal500, Primary.Teal700, Primary.Teal500, Accent.DeepOrange700, TextShade.WHITE);
        }


        // функция перевода города на английский язык с помощью Google Translate API 
        private string TranslateCityToEnglish(string russianCity)
        {
            TranslationClient client = TranslationClient.CreateFromApiKey(GoogleTranslateApiKey);

            var response = client.TranslateText(russianCity, "en", "ru");
            return response.TranslatedText;
        }


        // функция получения температуры в городе с помощью OpenWeatherMap API 
        private void button1_Click(object sender, EventArgs e)
        {
            string russianCity = CityNameBox.Text;
            string englishCity = TranslateCityToEnglish(russianCity);
            try
            {
                string apiKey = OpenWeatherMapApiKey;
                string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={englishCity}&units=metric&appid={apiKey}";


                // получение данных API запроса с помощью библиотеки WebClient 
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(apiUrl);
                    // парсинг данных с помощью библиотеки Newtonsoft.Json 
                    JObject data = JObject.Parse(json);
                    if (data["main"] != null && data["main"]["temp"] != null)
                    {
                        double temperature = Convert.ToDouble(data["main"]["temp"]);
                        ResultLabel.Text = $"Текущая температура в городе {russianCity}: {temperature} C°";
                    }
                    else
                    {
                        ResultLabel.Text = "Не удалось получить данные";
                    }
                }
            }
            catch (Exception ex)
            {
                ResultLabel.Text = "Не удалось получить данные\n\t\t\t( возможно введено неправильное название города)";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {

        }

        private void CityNameBox_Enter(object sender, EventArgs e)
        {
        }

        private void CityNameBox_Leave(object sender, EventArgs e)
        {
        }

        private void CityNameBox_Click(object sender, EventArgs e)
        {
            if (CityNameBox.Text == "Введите город")
                CityNameBox.Clear();
        }
    }
}

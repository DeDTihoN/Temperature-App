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
using System.Configuration;

namespace CityTemperature
{
    public partial class Form1 : MaterialForm
    {
        private readonly string GoogleTranslateApiKey;
        private readonly string OpenWeatherMapApiKey;
        // конструктор формы 
        public Form1()
        {
            InitializeComponent();

            // получение ключей API из файла App.config
            GoogleTranslateApiKey = ConfigurationManager.AppSettings["GoogleTranslateApiKey"];
            OpenWeatherMapApiKey = ConfigurationManager.AppSettings["OpenWeatherMapApiKey"];

            // настройка MaterialSkinManager для улучшения внешнего вида приложения 
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal500, Primary.Teal700, Primary.Teal500, Accent.DeepOrange700, TextShade.WHITE);
        }


        // функция перевода города на английский язык с помощью Google Translate API 
        private string TranslateCityToEnglish(string russianCity)
        {
            // если не введено название города, то возвращается null
            if (russianCity==null)return null;
            TranslationClient client = TranslationClient.CreateFromApiKey(GoogleTranslateApiKey);

            var response = client.TranslateText(russianCity, "en", "ru");
            return response.TranslatedText;
        }


        // функция получения температуры в городе с помощью OpenWeatherMap API после нажатия на кнопку получения результата 
        private void button1_Click(object sender, EventArgs e)
        {
            // название города, введенное пользователем на русском языке
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
                    if (data["main"] != null && data["main"]["temp"] != null) { 
                    
                        // конвертация результатов в тип double с точностью до 2 знаков после запятой
                        double temperature = Convert.ToDouble(data["main"]["temp"]);
                        ResultLabel.Text = $"Текущая температура в городе {russianCity}: {temperature} C°";
                    }
                    else
                    {
                        ResultLabel.Text = "Не удалось получить данные";
                    }
                }
            }
            // обработка исключений для случая, если введено неправильное название города 
            catch (Exception ex)
            {
                ResultLabel.Text = "Не удалось получить данные\n\t\t\t( возможно введено неправильное название города)";
            }
        }

        // очистка поля ввода при нажатии на него
        private void CityNameBox_Click(object sender, EventArgs e)
        {
            if (CityNameBox.Text == "Введите город")
                CityNameBox.Clear();
        }
    }
}

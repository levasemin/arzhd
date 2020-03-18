using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AngleSharp.Html.Parser;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TimeTable : ContentPage
    {
        public List<List<string>> infoabouttrains = new List<List<string>>();
        public HttpClient client = new HttpClient();
        public Dictionary<char, char> word= new Dictionary<char, char>()
            {{'А', 'a'}, {'Б', 'b'}, {'В', 'v'}, {'Г', 'g'}, {'Д', 'd'}, {'Е','e'}, {'Ж', 'j'}, {'З','z'}, {'И','i'}, {'К', 'k'}, {'Л','l'}, {'М', 'm'}, {'Н','n'}, {'О', 'o'}, {'П', 'p'}, {'Р', 'r'}, {'С', 's'}, {'Т', 't'}, {'У', 'u'}, {'Ф', 'f'}, {'Х', 'h'}, {'Ц', 'c'}};
        public Dictionary<char, string> words = new Dictionary<char, string>()
        { {'Ч',"ch"}, {'Ш',"sh"}, {'Щ',"sch"}, {'Э', "e!!"}, {'Ю',"yu"}, {'Я', "ya"}};
        class Train
        {
            public Train(string name, List<string> time, string day, Dictionary<string, string> types)
            {
                this.Name = name;
                this.Time = time;
                this.Day = day;
                if (time.Count == 2)
                    this.Time2 = "Время отправления: " + time[0] + "\nВремя прибытия: " + time[1];
                else
                    this.Time2 = "Время отправления: " + time[0] + "\nВремя прибытия(" + time[1] + "): " + time[2];
                this.Types = types;
            }

            public string Name { private set; get; }
            public string Time2 { private set; get; }
            public string Day { private set; get; }
            public List<string> Time { private set; get; }
            public Dictionary<string, string> Types { private set; get; }

        };
        List<Train> trainsbe = new List<Train>();
        List<Train> trainsnotbe = new List<Train>();
        public bool item;
        public TimeTable(Color color)
        {
            InitializeComponent();
            trainslistview.ItemTapped += NameLabel_Clicked;
            date.Format = "dd/MM/yyyy";
            BackgroundColor = color;
            if (color == Color.FromHex("#FFFFFF"))
            {
                item = true;
            }
            else
            {
                item = false;
                cityto.TextColor = Color.FromHex("#FFFFFF");
                cityfrom.TextColor = Color.FromHex("#FFFFFF");
                date.TextColor = Color.FromHex("#FFFFFF");
                lk.TextColor = Color.FromHex("#FFFFFF");
                beornot.Color = Color.FromHex("#FFFFFF");
            }
        }       
    private async void NameLabel_Clicked(object sender, ItemTappedEventArgs e)
        {
            Train typed = (Train)e.Item;
            await Navigation.PushAsync(new TrainInfo(typed.Name, typed.Time, typed.Day, typed.Types, item));
        }
             
    private async void Find(object sender, EventArgs e)
        {
            empty.Text = "Чух-чух-чух...";
            trainsbe = new List<Train>();
            trainsnotbe = new List<Train>();
            Show();
            client = new HttpClient();
            string day1 = date.Date.ToString();
            day1 = day1.Replace("12:00:00 AM", "").Replace("0:00:00", "");
            string[] dayt;
            if (day1.IndexOf('/') == -1)
            {
                dayt = day1.Split('.');
            }
            else 
            {
                dayt = day1.Split('/');
            }
            if (dayt[0].Length == 1) dayt[0] = '0' + dayt[0];
            if (dayt[1].Length == 1) dayt[1] = '0' + dayt[1];
            string day = dayt[0] + '.' + dayt[1] + '.' + dayt[2];
            string cityfr = "";
            string city = "";
            if (String.IsNullOrEmpty(cityfrom.Text) || String.IsNullOrEmpty(cityto.Text)) { Error(); return;}
            string cityfro = cityfrom.Text.ToUpper();
            string cityt = cityto.Text.ToUpper();
            int k = 0;
            foreach(char w in cityfro) {
                if (w == 'ь' || w == 'ъ') continue;
                if (k == 0) 
                {
                    k += 1;
                    if (word.Keys.ToList().IndexOf(w) > -1) cityfr += word[w].ToString().ToUpper();
                    if (words.Keys.ToList().IndexOf(w) > -1) cityfr += words[w].ToString().ToUpper();
                    continue;
                }
                if (word.Keys.ToList().IndexOf(w) > -1) cityfr += word[w];
                if (words.Keys.ToList().IndexOf(w) > -1) cityfr += words[w]; }
            foreach (char w in cityt)
            {
                if (w == 'ь' || w == 'ъ') continue;
                if (k == 1)
                {
                    k += 1;
                    if (word.Keys.ToList().IndexOf(w) > -1) city += word[w].ToString().ToUpper();
                    if (words.Keys.ToList().IndexOf(w) > -1) city += words[w].ToString().ToUpper();
                    continue;
                }
                if (word.Keys.ToList().IndexOf(w) > -1) city += word[w];
                if (words.Keys.ToList().IndexOf(w) > -1) city += words[w];
            } 
            var domParser = new HtmlParser();
            var current = Xamarin.Essentials.Connectivity.NetworkAccess;

            if (current != Xamarin.Essentials.NetworkAccess.Internet)
            {
                ErrorNET();
                return;
            }
            HttpResponseMessage response = await client.GetAsync("https://poezd.ru/nalichie-mest/" + cityfr + "/" + city + "/?SearchForm%5BdateTo%5D=" + day);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ErrorNET();
                return;
            }
            string source = await response.Content.ReadAsStringAsync();
            if (source.IndexOf("data-stationnamefrom=\"Москва\"") > -1 && cityfr != "Moskva")
            {
                trainsbe = new List<Train>();
                trainsnotbe = new List<Train>();
                Show();
                Error();
                return;
            }
            if (source.IndexOf("data-station_name_to=\"Санкт-Петербург\"") > -1 && city != "Sanktpeterburg")
            {
                trainsbe = new List<Train>();
                trainsnotbe = new List<Train>();
                Show();
                Error();
                return;
            }
            var document = await domParser.ParseDocumentAsync(source);
            List<string> times = new List<string>();
            string tip="";
            string price="";
            int i = 0;
            string name = "";
            trainsbe = new List<Train>();
            trainsnotbe = new List<Train>();
            Dictionary<string, string> types = new Dictionary<string, string>();
            var train = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("poezd poezd--type-train"));
            if (source.IndexOf("ни&nbsp;один поезд не&nbsp;ходит по&nbsp;маршруту") > -1) { Show(); return; }
            foreach (var trai in train)
            {
                i++;
                var nam = trai.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("poezd-info-header-title"));
                foreach (var n in nam) { name = n.TextContent; break; }
                times = new List<string>();
                var time1 = trai.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("time-moscow"));
                foreach (var ti1 in time1) { times.Add(ti1.TextContent); }

                var classes = trai.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("poezd-routes"));
                types = new Dictionary<string, string>();
                foreach (var cl in classes)
                {
                    var ttipp = cl.QuerySelectorAll("span").Where(item => item.ClassName == null);
                    foreach (var t in ttipp) { tip = t.TextContent; break; }
                    var prices = cl.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("poezd-routes-item-right"));
                    foreach (var pricee in prices) { price = pricee.TextContent; break; }
                    string result;
                    if (types.TryGetValue(tip, out result) == false)
                    { types.Add(tip, price);}
                }
                types.Remove("");
                if (types.Keys.Count > 0)
                { trainsbe.Add(new Train(name, times, day.Replace('.', '/'), types)); }
                else {trainsnotbe.Add(new Train(name, times, day.Replace('.', '/'), types)); }
            }
            Show();
        }
        private void Checkbeornot(object sender, EventArgs e) { Show(); }
        private void Show() 
        {
            List<Train> trains = new List<Train>();
            if (beornot.IsChecked) trains = trainsbe;
            else trains = trainsnotbe;
            trainslistview.ItemsSource = trains;
            trainslistview.SelectionMode = 0;
            trainslistview.HasUnevenRows = true;
            if (item == false) trainslistview.SeparatorColor = Color.FromHex("#FFFFFF");
            if (trains.Count == 0)
            {
                empty.Text = "Поездов нет";
                if (item)
                    empty.TextColor = Color.FromHex("#424242");
                else
                    empty.TextColor = Color.FromHex("#FFFFFF");
            }
            else empty.Text = "";
            trainslistview.ItemTemplate = new DataTemplate(() =>
            {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.Style = Device.Styles.TitleStyle;
                nameLabel.FontSize = 20;
                Label nameLabel2 = new Label();
                nameLabel2.SetBinding(Label.TextProperty, "Time2");
                nameLabel2.Style = Device.Styles.TitleStyle;
                nameLabel2.FontSize = 15;
                if (item == false) 
                {
                    nameLabel.TextColor = Color.FromHex("#FFFFFF");
                    nameLabel2.TextColor = Color.FromHex("#FFFFFF");
                }
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Children =
                        {
                            new StackLayout
                            {
                                Children =
                                {
                                    nameLabel,
                                    nameLabel2
                                }
                            }
                        }
                    }
                };
            });
        }
        private async void ErrorNET()
        {
            await DisplayAlert("Ошибка", "Нет подключения к интернету", "Ok");
        }
        private async void Error() 
        {
            await DisplayAlert("Ошибка", "Неверно указаны станции", "Ok"); 
        }
    }


    } 
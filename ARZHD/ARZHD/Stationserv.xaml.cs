using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stationserv : ContentPage
    {
        public bool itemclass;
        class Service
        {
            public Service(string name, string time, string desc, string price = null)
            {
                this.Name = name;
                this.Desc = desc;
                this.Time = time;
                this.Price = price;
            }

            public string Name { private set; get; }
            public string Desc { private set; get; }
            public string Time { private set; get; }
            public string Price { private set; get; }
        };
        public Stationserv(bool item)
        {
            InitializeComponent();
            itemclass = item;
            serviceslist.SeparatorColor = Color.FromHex("#F44336");
            if (item == false)
            {
                serviceslist.SeparatorColor = Color.FromHex("#FFFFFF");
                BackgroundColor = Color.FromHex("#424242");
            }
            Title = "Сервисы вокзала";
            List<Service> services = new List<Service>();
            serviceslist.ItemTapped += Serviceslist_ItemTapped;
            services.Add(new Service("Вероисповедание", "Круглосуточно", "Место, дающее вам возможность остаться наедине с тем, в кого вы верите."));
            services.Add(new Service("Гостиница", "Круглосуточно", "Все номера оснащены собственным санузлом. Во всех комнатах есть телевизор, холодильник и чайник. Есть номера одноместные и двухместные. Есть номера класса «Стандарт» и класса «Люкс».", "Cамый дешевый номер 500 рублей в сутки, самый дорогой – 2000 рублей в сутки."));
            services.Add(new Service("Зал ожидания", "Круглосуточно", "Зал для приятного времяпрепровождения в ожидании поезда."));
            services.Add(new Service("Камера хранения", "Круглосуточно", "Для использования камер необходимо предъявить только паспорт, необязательно иметь при себе проездной билет. Система смарт-карт автоматизирует расчет за предоставляемые услуги, накапливает и хранит информацию о работе камер хранения. Необходимо помнить, что после покупки самой смарт - карты, нужно успеть разместить багаж в ячейку в течение 10 минут, иначе пластиковый ключ аннулируется, а время хранения придется оплатить заново. Запрещено оставлять на хранение домашних животных, птиц, взрывчатое и огнестрельное оружие, психотропные вещества и наркотики, сильно загрязненные вещи и опасные предметы.Не рекомендуется сдавать в камеру хранения денежные средства, важные документы, прочие ценности.", "200 рублей (за сутки)"));
            services.Add(new Service("Кассы", "Круглосуточно", "Здесь вы можете приобрести билет на поезд, или сдать его."));
            services.Add(new Service("Комнаты для матери и ребенка", "Круглосуточно", "Комнаты, имеющие условия, позволяющие пассажирам с маленькими детьми чувствовать себя максимально комфортно."));
            services.Add(new Service("Медпункт", "Круглосуточно", "Место для получения медицинской помощи."));
            services.Add(new Service("Полиция", "Круглосуточно", "В любой момент вы можете обратиться в службу защиты, если столкнулись с нарушениями ваших личных прав или законов."));
            services.Add(new Service("Справочная", "Круглосуточно", "Специалисты справочной службы проконсультируют вас по любым вопросам, связанных с расписанием поездов и электричек, наличием и стоимостью железнодорожных билетов, а также по работе служб вокзала города Ижевска."));
            services.Add(new Service("Туалет", "Круглосуточно", "Место для приятного времяпровождения (бесплатный).", "15 рублей. При наличии проездного документа - бесплатно."));            
            serviceslist.ItemsSource = services;
            serviceslist.SelectionMode = 0;
            serviceslist.HasUnevenRows = true;
            serviceslist.Margin = 10;
            serviceslist.ItemTemplate = new DataTemplate(() =>
            {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.Style = Device.Styles.TitleStyle;
                nameLabel.FontSize = 20;
                nameLabel.Margin = 10;
                if (item == false)
                {
                    nameLabel.TextColor = Color.FromHex("#FFFFFF");
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
                                    nameLabel
                                }
                            }
                        }
                    }
                };
            });
        }

        private async void Serviceslist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Service service = (Service)e.Item;
            await Navigation.PushAsync(new Info(itemclass, service.Name, service.Time, service.Price, service.Desc));
        }
    }
}
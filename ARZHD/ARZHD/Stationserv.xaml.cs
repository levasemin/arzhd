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
            public Service(string name, string time, string desc)
            {
                this.Name = name;
                this.Desc = desc;
                this.Time = time;
            }

            public string Name { private set; get; }
            public string Desc { private set; get; }
            public string Time { private set; get; }
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
            services.Add(new Service("Кассы", "07:00 до 18:00 (по мск)", "Место для покупки возврата билетов."));
            services.Add(new Service("Камера хранения", "Круглосуточно", "Для использования камер необходимо предъявить только паспорт, необязательно иметь при себе проездной билет. Система смарт-карт автоматизирует расчет за предоставляемые услуги, накапливает и хранит информацию о работе камер хранения. Стоимость хранения ручной клади и крупногабаритного багажа обойдется пассажирам в 200 рублей за календарные сутки.Необходимо помнить, что после покупки самой смарт - карты, нужно успеть разместить багаж в ячейку в течение 10 - ти минут, иначе пластиковый ключ аннулируется, а время хранения придется оплатить заново. Запрещено оставлять на хранение домашних животных, птиц, взрывчатое и огнестрельное оружие, психотропные вещества и наркотики, сильно загрязненные вещи и опасные предметы.Не рекомендуется сдавать в камеру хранения денежные средства, важные документы, прочие ценности."));
            services.Add(new Service("Туалет", "Круглосуточно", "Место для приятного времяпровождения (бесплатный)."));
            services.Add(new Service("Зал ожидания", "Круглосуточно", "Зал"));
            services.Add(new Service("Гостиница", "Круглосуточно", "Место для приятного времяпровождения."));
            services.Add(new Service("Комната для матери и ребенка", "Круглосуточно", "Место для приятного времяпровождения."));
            services.Add(new Service("Справочная", "Круглосуточно", "Место для приятного времяпровождения."));
            services.Add(new Service("Полиция", "Круглосуточно", "Место для приятного времяпровождения."));
            services.Add(new Service("Полиция", "Круглосуточно", "Место для приятного времяпровождения."));
            services.Add(new Service("Вероисповедание", "Круглосуточно", "Место для приятного времяпровождения."));
            services.Add(new Service("Диспетчер", "Круглосуточно", "Место для приятного времяпровождения."));
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
            await Navigation.PushAsync(new Info(service.Name, service.Time, service.Desc, itemclass));
        }
    }
}
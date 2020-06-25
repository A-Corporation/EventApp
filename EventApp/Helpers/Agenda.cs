using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using EventApp.Models;

namespace EventApp.Helpers
{
    public class Agenda
    {

        public ObservableCollection<AgendaItem> AgendaItems { get; set; }
        public ObservableCollection<Grouping<string, AgendaItem>> AgendaItemsGrouped { get; set; }
        public ObservableCollection<User> speakers { get; set; }

        public Agenda()
        {
            AgendaItems = new ObservableCollection<AgendaItem>();
            speakers = new ObservableCollection<User>();

            
            speakers.Add(new User("Игорь Манн", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg"));
            //speakers.Add(new User("КОТОРЕВА МАРИНА", "Event manager", "JTB", "ProfilePhoto"));
            //speakers.Add(new User("Прокопьев Григорий", "Consulting manager", "BC", "ProfilePhoto"));


            /*
            AgendaItems.Add(new AgendaItem
            {
                StartTime = "10:00",
                EndTime = "11:00",
                Title = "Почему вы? Как отвечать на самый главный вопрос в бизнесе",
                Location = "Зал 1",
                Date = "13 ноября",
                //Speakers = speakers
                //Speakers = new ObservableCollection<User>(new List<User>{ new User("Игорь Манн", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg") })
            });
            
            AgendaItems.Add(new AgendaItem
            {
                StartTime = "11:30",
                EndTime = "12:30",
                Title = "Запросы клиентов настоящего и будущего: как создавать нужный продукт и ассортимент",
                Location = "Зал 1",
                Date = "13 ноября",
                //Speakers = speakers
            }) ;

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "12:30",
                EndTime = "13:30",
                Title = "Новая волна российских дизайнеров или что будет с вашим магазином через 5 лет",
                Location = "Зал 1",
                Date = "13 ноября",
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "14:30",
                EndTime = "15:30",
                Title = "Личный бренд руководителя модного бизнеса",
                Location = "Зал 1",
                Date = "13 ноября"
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "15:30",
                EndTime = "16:00",
                Title = "практикум по продвижению fashion-аккаунта в Instagram: что работает, а что спускает ваши бюджеты",
                Location = "Зал 1",
                Date = "13 ноября",
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "16:00",
                EndTime = "16:30",
                Title = "Как поднимать продажи с помощью системы учёта или почему 1С уходит в прошлое",
                Location = "Зал 1",
                Date = "13 ноября",
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "16:30",
                EndTime = "17:30",
                Title = "Построение команды продаж, которая перевыполняет планы",
                Location = "Зал 1",
                Date = "13 ноября",
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "11:30",
                EndTime = "12:30",
                Title = "Бренд, ориентированный на оптовые продажи: продукт, процессы, продвиждение",
                Location = "Зал 2",
                Date = "13 ноября",
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "12:30",
                EndTime = "13:30",
                Title = "Тренды осень/зима 2020-21 от WGSN",
                Location = "Зал 2",
                Date = "13 ноября",
                LectureType = "ЛЕКЦИЯ"
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "14:30",
                EndTime = "15:30",
                Title = "Как успешно продаваться в ритейле: советы дизайнерам от ведущих экспертов по российской моде",
                Location = "Зал 2",
                Date = "13 ноября"
            });

            AgendaItems.Add(new AgendaItem
            {
                StartTime = "15:30",
                EndTime = "16:30",
                Title = "Ожидания клиентов в люксе. Успешные стратегии бутика",
                Location = "Зал 2",
                Date = "13 ноября",
            });
            
            var sorted = from item in AgendaItems
                         orderby item.StartTime
                         group item by item.StartTime into itemGroup
                         select new Grouping<string, AgendaItem>(itemGroup.Key, itemGroup);

            AgendaItemsGrouped = new ObservableCollection<Grouping<string, AgendaItem>>(sorted);
            */
        }


    }
}

using System.Collections.ObjectModel;
using EventApp.Helpers;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using EventApp.Web;
using EventApp.Models.Chat;

namespace EventApp.Models
{
    public class Event
    {
        // Название мероприятия
        public string EventName { get; set; }

        // Нужен для идентификации того или иного мероприятия в базе данных при авторизации.
        public string EventID { get; set; } 

        // Пользователь
        public User ProfileUser { get; set; }

        // Ключ пользователя в базе данных
        public string UserKey { get; set; }

        // Типы Users на английском и русском
        public  Dictionary<string, string> UsersTypes { get; set; }

        // Список пользователей (Список пользователей каждого типа)
        public List<ObservableCollection<User>> UsersCollection { get; set; }
        public List<ObservableCollection<Grouping<string, User>>> UsersCollectionGrouped
        {
            get
            {
                List<ObservableCollection<Grouping<string, User>>> result = new List<ObservableCollection<Grouping<string, User>>>();
                foreach (ObservableCollection<User> Users in UsersCollection)
                {
                    var sorted = from user in Users
                                 orderby user.SecondName
                                 group user by user.NameSort into userGroup
                                 select new Grouping<string, User>(userGroup.Key, userGroup);
                    result.Add(new ObservableCollection<Grouping<string, User>>(sorted));
                }
                return result;
            }
        }


        // Программа (Список программ по дням)
        public List<ObservableCollection<AgendaItem>> AgendaCollection { get; set; }
        public List<ObservableCollection<Grouping<string, AgendaItem>>> AgendaCollectionGrouped
        {
            get
            {
                List<ObservableCollection<Grouping<string, AgendaItem>>> result = new List<ObservableCollection<Grouping<string, AgendaItem>>>();
                foreach (ObservableCollection<AgendaItem> AgendaDay in AgendaCollection)
                {
                    var sorted = from item in AgendaDay
                                 orderby item.StartTime
                                 group item by item.StartTime into itemGroup
                                 select new Grouping<string, AgendaItem>(itemGroup.Key, itemGroup);
                    result.Add(new ObservableCollection<Grouping<string, AgendaItem>>(sorted));
                }
                   
                return result;
            }
        }


        // Спонсоры мероприятия
        public ObservableCollection<Sponsor> Sponsors { get; set; }
        public ObservableCollection<Grouping<string, Sponsor>> SponsorsGroupedByName
        {
            get
            {
                var sorted = from sponsor in Sponsors
                             orderby sponsor.Name
                             group sponsor by sponsor.NameSort into sponsorGroup
                             select new Grouping<string, Sponsor>(sponsorGroup.Key, sponsorGroup);
                return new ObservableCollection<Grouping<string, Sponsor>>(sorted);
            }
        }
        public ObservableCollection<Grouping<string, Sponsor>> SponsorsGroupedByCategory
        {
            get
            {
                var sorted = from sponsor in Sponsors
                             orderby sponsor.Category
                             group sponsor by sponsor.Category into sponsorGroup
                             select new Grouping<string, Sponsor>(sponsorGroup.Key, sponsorGroup);
                return new ObservableCollection<Grouping<string, Sponsor>>(sorted);
            }
        }

        // Фото участников
        public ObservableCollection<Photo> PhotoGalleryCollection { get; set; }

        // Фото отчёт
        public ObservableCollection<Photo> PhotoReportCollection { get; set; }

        // Сообщения в чате
        public ObservableCollection<ChatMessage> Messages { get; set; }

        // Вопросы спикерам
        public Dictionary<string, ObservableCollection<SpeakersQuestion>> SpeakersQuestions { get; set; }

        // Голосования
        public Dictionary<string, ObservableCollection<VotingItem>> Votings { get; set; }

        // Оповещения
        public ObservableCollection<Announcement> Announcements { get; set; }

        // Документы
        public ObservableCollection<DocumentItem> Documents { get; set; }

        // Карты местности, план здания и т.п.
        public ObservableCollection<MapItem> Maps { get; set; }

        // Ссылки на различные медиа(instagram, vk, facebook и т.д.)
        public ObservableCollection<SocialMediaItem> SocialMedia { get; set; }

        // -------------- Gamification -------------------
        // Доска участников с набранными очками
        public Dictionary<string, int> Leaderboard { get; set; }

        // Список challenges
        public ObservableCollection<Challenge> Challenges { get; set; }
        // ------------------------------------------------

        // Текущая страница. Нужна для того чтобы открывать новую страницу из базового класса(например User, AgendaItem etc.)
        public ContentPage CurPage { get; set; }

        // Отображение страниц (Какие страницы будут видны в приложении)
        public List<bool> IsUsersPageVisible { get; set; }
        public bool IsListTypesUsersPageVisible { get; set; }
        public bool IsAgendaPageVisible { get; set; }
        public bool IsPhotoGalleryPageVisible { get; set; }
        public bool IsPhotoReportPageVisible { get; set; }
        public bool IsProfilePageVisible { get; set; }
        public bool IsQuestionsTopicsPageVisible { get; set; }
        public bool IsQuestionsPageVisible { get; set; }
        public bool IsListChatsPageVisible { get; set; }
        public bool IsChatPageVisible { get; set; }

        // Страницы в Меню
        public List<string> MenuPages { get; set; }

        // Страницы на TabBar
        public List<string> TabBarPages { get; set; }


        FirebaseHelper firebaseHelper = new FirebaseHelper();


        // Конструктор
        public Event()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //AgendaCollection = await firebaseHelper.ParceAgendaItems(App.EventName);
                //UsersCollection = await firebaseHelper.GetAllPersons();
                PhotoGalleryCollection = await firebaseHelper.ParcePhotos(EventName);
            });
        }


        // Методы


    }
}

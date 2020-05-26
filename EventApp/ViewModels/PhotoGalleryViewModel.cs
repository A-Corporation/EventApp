using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EventApp.Models;

namespace EventApp.ViewModels
{
    public class PhotoGalleryViewModel
    {

        public ObservableCollection<Photo> PhotoGallery { get; set; }
        public ObservableCollection<Photo> PhotoReport { get; set; }

        public PhotoGalleryViewModel()
        {
            CreateGallery();
            CreateReport();
        }


        public void CreateReport()
        {
            PhotoReport = new ObservableCollection<Photo>();

            
            PhotoReport.Add(new Photo
            {
                PhotoUrl = "https://downloader.disk.yandex.ru/preview/7aa64905effd24820ad5fd99cb17cc4b7f64b7f0b9b1e558bcbb66d2eedb348a/5dadd18b/bmqOp4SrzLV62sCQGJdz4-_h5nAzgbr8ZezlWXXFilEN4Tp5xtPbrJqoUcWiSqylEwUYb6rqW_ZP7_6lQK-iqA==?uid=0&filename=01.+Айсель+Трудел%2C+Со-основательница+концепт-стора+Aizel+и+интернет-магазина+Aizel.ru.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&owner_uid=549270437&size=3360x1782"
            });

            PhotoReport.Add(new Photo
            {
                PhotoUrl = "https://downloader.disk.yandex.ru/preview/b5c2b35b960c81f6bf7f7ca0237a4153d79fbbffd08a6615b838ac4797622397/5dadd18b/qAKfuSRu3gHVrQdkPhb-hgYpI07TUAgtY39ubdw3XJmQ0KpqA3xGh9gw15xuA-P9VVXs0XGbuFRlcKo3w9LU_Q==?uid=0&filename=05.+Оксана+Бондаренко%2C+основательница+шоурума+Ли-Лу1.jpg&disposition=inline&hash=&limit=0&content_type=image%2Fjpeg&tknv=v2&owner_uid=549270437&size=3360x1782"
            });
        }

        public void CreateGallery()
        {
            PhotoGallery = new ObservableCollection<Photo>();
            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "https://www.thenamemeaning.com/wp-content/uploads/2015/02/Rachel_McAdams.jpg",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg")
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://pressa.tv/uploads/posts/2016-04/1461923893_c7.jpg",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg")
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://feelgood.ua/media/article/201403/znamenitosti-i-sport_620x280.jpeg",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg")
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://v.img.com.ua/b/orig/1/01/4741883744e64fe273d102dedb901011.jpg",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg")
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://v.img.com.ua/b/orig/1/01/4741883744e64fe273d102dedb901011.jpg",
                User = new User("Никитин Артём", "DG", "ACorp", "https://sun9-54.userapi.com/c830709/v830709120/5b6b2/hLr7vS9OkPE.jpg")
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "https://www.thenamemeaning.com/wp-content/uploads/2015/02/Rachel_McAdams.jpg"
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://pressa.tv/uploads/posts/2016-04/1461923893_c7.jpg"
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://v.img.com.ua/b/orig/1/01/4741883744e64fe273d102dedb901011.jpg"
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "https://www.thenamemeaning.com/wp-content/uploads/2015/02/Rachel_McAdams.jpg"
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://pressa.tv/uploads/posts/2016-04/1461923893_c7.jpg"
            });

            PhotoGallery.Add(new Photo
            {
                PhotoUrl = "http://v.img.com.ua/b/orig/1/01/4741883744e64fe273d102dedb901011.jpg"
            });
        }

        public void AddPhoto(Photo photo)
        {
            PhotoGallery.Add(photo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebApplication5
{
    public class Answers : DbContext
    {
        // Контекст настроен для использования строки подключения "Book" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WebApplication5.Book" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Book" 
        // в файле конфигурации приложения.
        public Answers()
            : base("name=quiz")
        {
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string QuestionId { get; set; }
        public string IsRight { get; set; }

        
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
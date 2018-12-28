using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using mvc.Models;
namespace mvc.Context
{

    public class mvcContext : DbContext
    {
        public DbSet<Event> events { get; set; }

        public DbSet<Purchase> purchases { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Place> places { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>().HasMany(c => c.events)
                 .WithMany(s => s.purchases)
                 .Map(t => t.MapLeftKey("purchaseId")
                 .MapRightKey("eventId")
                 .ToTable("EventPurchase"));

        }


//        {
//            db.Events.Add(new Event { Name = "Человек-Паук 3", Place = "Современник", Info = "Супергерой человек паук стал алоарвпкш", Price = 200 });

        //            db.Events.Add(new Event { Name = "Мужской стриптиз для дам за 60", Place = "Современник2", Info = "Супергерой челоtghjfhfвек паук стал алоарвпкш", Price = 200 });

        //            db.Events.Add(new Event { Name = "Выставка авангардистов для фриков самое то", Place = "Современник3", Info = "Супергерой человек паукfghfghfgh стал алоарвпкш", Price = 200 });

        //            db.Events.Add(new Event { Name = "ЧКислотный рейв обожаю", Place = "Современник4", Info = "Супергерой человек паук стал алоfghssрвпкш", Price = 200 });

        //            db.Events.Add(new Event { Name = "Человек-Паук 7", Place = "Современник5", Info = "СупеААААААААргерой человек паук стал аловапваарвпкш", Price = 200 });

        //            db.Categories.Add(new Category { Name = "Кино" });

        //            db.Categories.Add(new Category { Name = "Театр" });

        //            db.Categories.Add(new Category { Name = "Цирк" });

        //            db.Categories.Add(new Category { Name = "Концерты" });

        //            db.Categories.Add(new Category { Name = "Выставки" });

        //            db.Places.Add(new Place { Name = "Лужники" ,Address = "Шоссе Легионеров,17"});

        //            db.Places.Add(new Place { Name = "Адский котел", Address = "Акультная,666" });

        //            db.Places.Add(new Place { Name = "Пристанище", Address = "Земляная нора,111" });
        //            base.Seed(db);
        
    }





}
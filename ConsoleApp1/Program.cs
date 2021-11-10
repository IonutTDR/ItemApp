using AutoMapper;
using DataAccess.DataContext;
using DataAccess.Repository;
using Services;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemContext ctx = new ItemContextFactory().CreateDbContext(args);
            IItemRepository repo = new ItemRepository(ctx);
            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<Services.Profiles.ItemProfile>();
                cfg.AddProfile(new Services.Profiles.ItemProfile());
            });
            var mapp = new Mapper(mapper);
            ItemService service = new ItemService(repo, mapp);

            var item = new Services.Models.Item()
            {
                Id = 2,
                Title = "Update title",
                Description = "Updated description",
                State = DataAccess.Entities.State.NOT_STARTED
            };

            var items = service.GetItems();
            try
            {
                var i = service.GetItem(5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            finally
            {
                var i1 = service.GetItem(2);

                Console.WriteLine($"{i1.Id} Title: {i1.Title} Description: {i1.Description} State: {i1.State.ToString()}");

                service.UpdateItem(item);

                i1 = service.GetItem(2);
                Console.WriteLine($"{i1.Id} Title: {i1.Title} Description: {i1.Description} State: {i1.State.ToString()}");

                foreach (var ite in items)
                {
                    Console.WriteLine($"{ite.Id} Title: {ite.Title} Description: {ite.Description} State: {ite.State.ToString()}");
                }

            }
        }
    }
    
}

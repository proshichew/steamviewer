// проверить здесб надо будет работу бд 
using DAL.Context;
using DAL.DbEntities;
using DAL.Repository;
using DAL.Mapping;
using Game = Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;
using System.Threading;

Console.WriteLine("privet");
AppDbContext context = new AppDbContext();




var l = context.Wishlists.FirstOrDefault(o=>o.Id==2);
Console.WriteLine(l.Id);

WishlistRepository repository = new WishlistRepository(context);
GameRepository gameRepository = new GameRepository(context);

//repository.Add(Mapper.ToDomain(new Wishlist(9, "1", "1")));

IEnumerable<Domain.Entities.Wishlist> list = await repository.GetAll();



//await gameRepository.Add(new Game(1, "1", 1));

await repository.InsertGame(2, 1);
await repository.InsertGame(2, 2);
await repository.InsertGame(2, 3);


var lis = await repository.GetGames(1);
Console.WriteLine(lis.ElementAt(0).Id);

foreach (Domain.Entities.Wishlist item in list)
{
    IEnumerable<Game> gaes = await repository.GetGames(item.Id);
    if(gaes == null)
    {
        Console.WriteLine(item.Id + " is empty!");
    }
    if (gaes != null)
    {
        foreach (Game game in gaes)
        {
            Console.WriteLine(game.ToString());
        }
    }
}





//if (game != null) Console.WriteLine(game.Id + " Exists");
//else Console.WriteLine("Контекст дерьмо");




//await repository.InsertGame(2, 2);


//IEnumerable<Game> a = await repository.GetGames(1);

//Console.WriteLine(a.ToList()[0].ToString());


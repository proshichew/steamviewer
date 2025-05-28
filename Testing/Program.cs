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

Wishlist a = new Wishlist(0, "a", "a");

context.Add(a);
context.SaveChanges();



//if (game != null) Console.WriteLine(game.Id + " Exists");
//else Console.WriteLine("Контекст дерьмо");




//await repository.InsertGame(2, 2);


//IEnumerable<Game> a = await repository.GetGames(1);

//Console.WriteLine(a.ToList()[0].ToString());


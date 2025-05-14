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





WishlistRepository repository = new WishlistRepository(context);
GameRepository gameRepository = new GameRepository(context);

//repository.Add(Mapper.ToDomain(new Wishlist(9, "1", "1")));


int wishlistId = 2;
Wishlist wishlist = await context.Wishlists
.Include(w => w.Games)
    .FirstOrDefaultAsync(w => w.Id == wishlistId);



context.Games.Add(new DAL.DbEntities.Game(1, "1", 1));

int gameId = 10;
var game = await context.Games
    .FirstOrDefaultAsync(g => g.Id == gameId);


Console.WriteLine(wishlist.Id + " wishlist Exists");
if (game != null) Console.WriteLine(game.Id + " game Exists");
else Console.WriteLine("Репозиторий дерьмо");




//if (game != null) Console.WriteLine(game.Id + " Exists");
//else Console.WriteLine("Контекст дерьмо");




//await repository.InsertGame(2, 2);


//IEnumerable<Game> a = await repository.GetGames(1);

//Console.WriteLine(a.ToList()[0].ToString());


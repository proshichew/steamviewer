// проверить здесб надо будет работу бд 
using DAL.Context;
using DAL.DbEntities;
using DAL.Repository;
using DAL.Mapping;
using Game = Domain.Entities.Game;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Text.Json;
using Steamviewer.Services;

//Console.WriteLine("privet");
//AppDbContext context = new AppDbContext();




//var l = context.Wishlists.FirstOrDefault(o=>o.Id==2);
//Console.WriteLine(l.Id);

//WishlistRepository repository = new WishlistRepository(context);
//GameRepository gameRepository = new GameRepository(context);

////repository.Add(Mapper.ToDomain(new Wishlist(9, "1", "1")));

//IEnumerable<Domain.Entities.Wishlist> list = await repository.GetAll();

//Wishlist a = new Wishlist(0, "a", "a");

//context.Add(a);
//context.SaveChanges();



////if (game != null) Console.WriteLine(game.Id + " Exists");
////else Console.WriteLine("Контекст дерьмо");




////await repository.InsertGame(2, 2);


////IEnumerable<Game> a = await repository.GetGames(1);

////Console.WriteLine(a.ToList()[0].ToString());
///

// Путь к вашему JSON-файлу
//string jsonPath = "inventory.json";
//string json = await File.ReadAllTextAsync(jsonPath);

//// Парсим JSON как массив предметов
//var items = new List<Item>();
//using (var doc = JsonDocument.Parse(json))
//{
//    if (doc.RootElement.ValueKind == JsonValueKind.Array)
//    {
//        foreach (var itemElement in doc.RootElement.EnumerateArray())
//        {
//            var name = itemElement.GetProperty("marketname").GetString() ?? string.Empty;
//            var price = itemElement.GetProperty("priceavg").GetDecimal();
//            var image = itemElement.GetProperty("image").GetString() ?? string.Empty;
//            var color = itemElement.GetProperty("color").GetString() ?? string.Empty;

//            items.Add(new Item(name, price, image, color));
//        }
//    }
//}

//// Создаем инвентарь вручную
//var playerId = "76561198155192476";
//var inventory = new Inventory($"Inventory_{playerId}", playerId, null)
//{
//    Items = items
//};

//// Выводим инвентарь и предметы в консоль
//Console.WriteLine($"Inventory: Name={inventory.Name}, PlayerId={inventory.PlayerId}, GameName={inventory.GameName}, ItemsCount={inventory.Items.Count}");
//foreach (var item in inventory.Items)
//{
//    Console.WriteLine($"Item: Name={item.Name}, Price={item.Price}, Image={item.Image}, Color={item.Color}");
//}

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:5000/")
};

var inventoryService = new InventoryService(httpClient);

string playerId = "76561198155192476";

var inventory = await inventoryService.AddInventoryAsync(playerId);

if (inventory == null)
{
    Console.WriteLine("Failed to create or retrieve inventory.");
    return;
}

Console.WriteLine($"Inventory: Id={inventory.Id}, Name={inventory.Name}, PlayerId={inventory.PlayerId}, GameName={inventory.GameName}");

var items = await inventoryService.GetInventoryItemsAsync(inventory.Id);

foreach (var item in items)
{
    Console.WriteLine($"Item: Name={item.Name}, Price={item.Price}, Image={item.Image}, Color={item.Color}");
}

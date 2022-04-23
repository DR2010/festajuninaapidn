using fjapifestajuninadn.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace fjapifestajuninadn.Services
{
    public class DishesService
    {
        private readonly IMongoCollection<Dish> _dishesCollection;

        public DishesService( IOptions<FestaJuninaDatabaseSettings> festaJuninaDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                festaJuninaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                festaJuninaDatabaseSettings.Value.DatabaseName);

            _dishesCollection = mongoDatabase.GetCollection<Dish>(
                festaJuninaDatabaseSettings.Value.DishesCollectionName);
        }

        public async Task<List<Dish>> GetAsync() =>
            await _dishesCollection.Find(_ => true).ToListAsync();

        public async Task<Dish?> GetAsync(string id) =>
            await _dishesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Dish newDish) =>
            await _dishesCollection.InsertOneAsync(newDish);

        public async Task UpdateAsync(string id, Dish updatedDish) =>
            await _dishesCollection.ReplaceOneAsync(x => x.Id == id, updatedDish);

        public async Task RemoveAsync(string id) =>
            await _dishesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
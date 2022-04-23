namespace fjapifestajuninadn.Models;
public class FestaJuninaDatabaseSettings
    {
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string DishesCollectionName { get; set; } = null!;
    public string OrdersCollectionName { get; set; } = null!;
}


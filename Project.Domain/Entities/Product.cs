namespace Project.Domain.Entities;

public class Product
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created_date { get; set; }
    public DateTime Updated_date { get; set; }
    public DateTime Deleted_date { get; set; }
    public bool IsDeleted { get; set; }
}

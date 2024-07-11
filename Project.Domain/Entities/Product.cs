namespace Project.Domain.Entities;

public class Product
{
    public Product(int id, string name, string description, DateTime created_date, DateTime updated_date, DateTime deleted_date, bool isDeleted)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedDate = created_date;
        UpdatedDate = updated_date;
        DeletedDate = deleted_date;
        IsDeleted = isDeleted;
    }

    public Product()
    {
        Id = -1;
        Name = string.Empty;
    }

    public int Id {  get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}

using MediatR;
using Project.Application.CQRS.Commands.Response;

namespace Project.Application.CQRS.Commands.Request;

public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
{
    public CreateProductCommandRequest(string name, string description, DateTime createdDate, DateTime updatedDate, DateTime deletedDate, bool isDeleted)
    {
        Name = name;
        Description = description;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        DeletedDate = deletedDate;
        IsDeleted = isDeleted;
    }


    //cons
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}

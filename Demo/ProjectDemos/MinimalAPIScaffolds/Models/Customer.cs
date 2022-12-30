namespace MinimalAPIScaffolds.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte Age { get; set; }
    public string Position { get; set; }
    public DateTime? UpdatedOnUtc { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Guid CreatedBy { get; set; }

    public void Update(Customer other)
    {
        this.Name = other.Name;
        this.Age = other.Age;
        this.Position = other.Position;
    }
}

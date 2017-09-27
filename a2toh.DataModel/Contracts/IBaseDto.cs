namespace EventManager.DataModel.Contracts
{
    public interface IBaseDto
    {
        int Id { get; set; }

        string Name { get; set; }

        bool IsActive { get; set; }
    }
}

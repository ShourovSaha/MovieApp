namespace MovieApp.Core.Entities.Base
{
    internal interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
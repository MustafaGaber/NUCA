
namespace  NUCA.Boqs.Application.Boqs.Commands.DeleteItem
{
    public interface IDeleteItemCommand
    {
        void Execute(long projectId, long tableId, long sectionId, long itemId);
    }
}

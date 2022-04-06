
namespace  NUCA.Boqs.Application.Boqs.Commands.DeleteSection
{
    public interface IDeleteSectionCommand
    {
        void Execute(long projectId, long tableId, long sectionId);
    }
}

using blog.Core.DTOs.TutorialDtos;
namespace blog.Core.Interfaces
{
    public interface ITutorialRepository: IReposetory<Tutorial>
    {
        Task<TutorialDto> UpdateTutorialAsync(int tutorial_id, TutorialUpdateDto obj); 
    }
}

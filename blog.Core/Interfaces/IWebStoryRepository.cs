using blog.Core.DTOs;
using blog.Core.DTOs.WebStoryDtos;
using blog.Core.Entities;

namespace blog.Core.Interfaces
{
    public interface IWebStoryRepository: IReposetory<WebStory>
    {
        Task<WebStoryDto> UpdateWebStoryAsync(int story_id, WebStoryUpdateDto obj);
    }
}

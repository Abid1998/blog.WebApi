namespace blog.Core.Interfaces
{
    public interface IUnitofWork
    {
        ICategoriesRepository CategoriesRepository { get; }
        ICommentRepository CommentRepository { get; }
        ITutorialRepository TutorialRepository { get; }
        IGalleryRepository GalleryRepository { get; }
        ITagsRepository TagsRepository { get; }
        IWebStoryRepository WebStoryRepository { get; }

        //IIdentityService IdentityService { get; }

        Task Save();
    }
}

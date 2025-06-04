using AutoMapper;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
namespace blog.Infrastructure.Repositories
{
    public class UnitofWork : IUnitofWork
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UnitofWork(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            CategoriesRepository = new CategoriesRepository(dbContext);
            CommentRepository = new CommentRepository(dbContext);
            TutorialRepository = new TutorialRepository(dbContext, mapper);
            TagsRepository = new TagsRepository(dbContext);
            GalleryRepository = new GalleryRepository(dbContext);
            WebStoryRepository = new WebStoryRepository(dbContext, mapper);
           // IdentityService = new IdentityService(dbContext);
        }

        public ICategoriesRepository CategoriesRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }
        public ITutorialRepository TutorialRepository { get; private set; }
        public IGalleryRepository GalleryRepository { get; private set; }
        public ITagsRepository TagsRepository { get; private set; }

        public IWebStoryRepository WebStoryRepository { get; private set; }

      //  public IIdentityService IdentityService { get; private set; }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}


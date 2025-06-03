using blog.Core.DTOs;
using blog.Core.Entities;
using AutoMapper;
using blog.Core.DTOs.CategoriesDtos;
using blog.Core.DTOs.CommentDtos;
using blog.Core.DTOs.GalleryDtos;
using blog.Core.DTOs.TagsDtos;
using blog.Core.DTOs.Tutorial_DetailsDtos;
using blog.Core.DTOs.TutorialDtos;
using blog.Core.DTOs.WebStoryDtos;
using blog.Core.DTOs.WebStoryPageDtos;

namespace blog.WebApi.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            /// <summary>
            /// Blog Category Mep
            /// </summary>
            CreateMap<Categories, CategoryDto>().ReverseMap();
            CreateMap<CategoryAddDto, Categories>().ReverseMap();
            CreateMap<CategoryUpdateDto, Categories>().ReverseMap();



            /// <summary>
            /// Blog Comment Mep
            /// </summary>
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<CommentAddDto, Comment>().ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();

            /// <summary>
            /// Blog Gallery Mep
            /// </summary>
            CreateMap<Gallery, GalleryDto>().ReverseMap();
            CreateMap<GalleryAddDto, Gallery>().ReverseMap();
            CreateMap<GalleryUpdateDto, Gallery>().ReverseMap();

            /// <summary>
            /// Blog Tags Mep
            /// </summary>
            CreateMap<Tags, TagsDto>().ReverseMap();
            CreateMap<TagsAddDto, Tags>().ReverseMap();
            CreateMap<TagsUpdateDto, Tags>().ReverseMap();

            /// <summary>
            /// Tutorial  Mep 
            /// </summary>

            CreateMap<Tutorial, TutorialDto>()
            .ForMember(dest => dest.Galleries, opt => opt.MapFrom(src => src.galleries))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.tags))
            .ForMember(dest => dest.Tutorial_Details, opt => opt.MapFrom(src => src.TutorialDetails))
            .ReverseMap();


            // CreateMap<Tutorial, TutorialDto>().ReverseMap();
            CreateMap<TutorialAddDto, Tutorial>().ForMember(dest => dest.galleries, opt => opt.Ignore());
            CreateMap<TutorialUpdateDto, Tutorial>().ForMember(dest => dest.galleries, opt => opt.Ignore());
            //CreateMap<TutorialUpdateDto, Tutorial>().ReverseMap();

            /// <summary>
            /// Tutorial Details Mep 
            /// </summary>
            CreateMap<Tutorial_Details, Tutorial_DetailsDto>().ReverseMap();
            CreateMap<Tutorial_DetailsAddDto, Tutorial_Details>().ReverseMap();
            CreateMap<Tutorial_DetailsUpdateDto, Tutorial_Details>().ReverseMap();

            /// <summary>
            /// Web Story Mep 
            /// </summary>
            CreateMap<WebStory, WebStoryDto>().ReverseMap();
            CreateMap<WebStoryAddDto, WebStory>().ReverseMap();
            CreateMap<WebStoryUpdateDto, WebStory>().ReverseMap();
            //CreateMap<WebStoryUpdateDto, WebStory>().ForMember(dest => dest.Pages, opt => opt.Ignore())
              //  .ForMember(dest => dest.cover_image_url, opt => opt.Ignore()); // because you override it manually

            /// <summary>
            /// Web Story Pages Mep 
            /// </summary>
            CreateMap<WebStoryPage, WebStoryPageDto>().ReverseMap();
            CreateMap<WebStoryPageAddDto, WebStoryPage>().ReverseMap();
            CreateMap<WebStoryPageUpdateDto, WebStoryPage>().ReverseMap();




        }
    }
}

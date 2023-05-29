using AutoMapper;
using CommentApp.Domain;
using CommentApp.Domain.Entities;
using CommentApp.Models;
using CommentApp.ViewModels;

namespace CommentApp.Infrastructure.Mapper
{
    public class QLBDSMapperConfiguration : Profile
    {
        public QLBDSMapperConfiguration()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Comments, opt => opt.Ignore());
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Account.Username))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

        }
    }
}

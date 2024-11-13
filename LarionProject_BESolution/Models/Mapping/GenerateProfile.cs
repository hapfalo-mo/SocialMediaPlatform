using AutoMapper;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mapping
{
    public class GenerateProfile : Profile
    {
        public GenerateProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<PostCreateDTO, Post>();
            CreateMap<Post, PostResponseDTO>();
            CreateMap<User,UserValidDTO>();
            CreateMap<User,UserResponseDTO>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<Comment, CommentResponseDTO>();
            CreateMap<Comment, CommentSubResponseDTO>();
        }
    }
}

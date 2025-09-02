using InExTrack.DTOs;
using InExTrack.DTOs.Requests;
using InExTrack.DTOs.Responses;
using InExTrack.Models;
using Mapster;

namespace InExTrack.Common.Mappers
{
    public class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserRequestsDto>();
            config.NewConfig<UserRequestsDto, User>();

            config.NewConfig<User, UserResponseDto>();
            config.NewConfig<UserResponseDto, User>();

            config.NewConfig<Category, CategoryDto>();
            config.NewConfig<CategoryDto, Category>();

            config.NewConfig<UserCategory, UserCategoryDto>();
            config.NewConfig<UserCategoryDto, UserCategory>();
        }
    }
}

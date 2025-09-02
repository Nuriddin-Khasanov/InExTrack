using InExTrack.Common;
using InExTrack.DTOs.Requests;
using InExTrack.DTOs.Responses;
using InExTrack.Interfaces.Repositories;
using InExTrack.Interfaces.Services;
using InExTrack.Models;
using Mapster;

namespace InExTrack.Services;

public class UserService(IUserRepository _userRepository) : IUserService
{
    //private readonly IUserRepository _userRepository;

    //public UserService(IUserRepository userRepository)
    //{
    //    _userRepository = userRepository;
    //}

    public async Task<ApiResponse<IEnumerable<UserResponseDto>>> GetAll(CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAllAsync(cancellationToken)).Adapt<List<UserResponseDto>>();

        return new ApiResponse<IEnumerable<UserResponseDto>>(user, "Пользователи успешно получены!");
    }

    public async Task<ApiResponse<UserResponseDto>> GetUserById(Guid _userId, CancellationToken cancellationToken)
    {
        if (_userId == Guid.Empty)
            return new ApiResponse<UserResponseDto>("Некорректный идентификатор пользователя.");

        var user = await _userRepository.GetByIdAsync(_userId, cancellationToken)
            .ContinueWith(t => t.Result.Adapt<UserResponseDto>(), cancellationToken);

        if (user == null)
            return new ApiResponse<UserResponseDto>("Пользователь не найден!");

        return new ApiResponse<UserResponseDto>(user, "Пользователь успешно получен!");
    }

    public async Task<ApiResponse<UserResponseDto>> AddUser(UserRequestsDto _user, CancellationToken cancellationToken)
    {
        var user = await _userRepository.AddAsync(_user.Adapt<User>(), cancellationToken)
            .ContinueWith(t => t.Result.Adapt<UserResponseDto>(), cancellationToken);

        return new ApiResponse<UserResponseDto>(user, "Пользователь успешно добавлен!");
    }

    public async Task<ApiResponse<UserResponseDto>> UpdateUserById(Guid _userId, UserRequestsDto userRequestsDto, CancellationToken cancellationToken)
    {
        if (_userId == Guid.Empty)
            return new ApiResponse<UserResponseDto>("Некорректный идентификатор пользователя.");

        var updatedUser = (await _userRepository.UpdateAsync(_userId, userRequestsDto, cancellationToken)).Adapt<UserResponseDto>();

        //if (updatedUser == null)
        //    throw new InvalidOperationException("Пользователь не найден или не обновлен.");

        return new ApiResponse<UserResponseDto>(updatedUser, "Пользователь успешно обновлен!");
    }

    public async Task<ApiResponse<bool>> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty)
            return new ApiResponse<bool>("Некорректный идентификатор пользователя.");

        if (await _userRepository.DeleteAsync(id, cancellationToken))
            return new ApiResponse<bool>(true, "Пользователь успешно удален.");
        
        return new ApiResponse<bool>("Пользователь не найден или не удален.");
    }

}

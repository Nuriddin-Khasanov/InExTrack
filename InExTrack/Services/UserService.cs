using InExTrack.Common;
using InExTrack.DTOs.Requests;
using InExTrack.DTOs.Responses;
using InExTrack.Interfaces.Repositories;
using InExTrack.Interfaces.Services;
using InExTrack.Models;
using Mapster;

namespace InExTrack.Services;

public class UserService(IUserRepository _userRepository, IJWTService _jwtService, IFileService _fileService) : IUserService
{
    //private readonly IUserRepository _userRepository;

    //public UserService(IUserRepository userRepository)
    //{
    //    _userRepository = userRepository;
    //}

    //public async Task<ApiResponse<IEnumerable<UserResponseDto>>> GetAll(CancellationToken cancellationToken)
    //{
    //    var user = (await _userRepository.GetAllAsync(cancellationToken)).Adapt<List<UserResponseDto>>();

    //    return new ApiResponse<IEnumerable<UserResponseDto>>(user, "Пользователи успешно получены!");
    //}

    public async Task<ApiResponse<UserResponseDto>> GetUserById(Guid _userId, CancellationToken cancellationToken)
    {
        if (_userId == Guid.Empty)
            return new ApiResponse<UserResponseDto>("Некорректный идентификатор пользователя.");

        var user = (await _userRepository.GetByIdAsync(_userId, cancellationToken)).Adapt<UserResponseDto>();
        // .ContinueWith(t => t.Result.Adapt<UserResponseDto>(), cancellationToken);

        if (user == null)
            return new ApiResponse<UserResponseDto>("Пользователь не найден!");

        return new ApiResponse<UserResponseDto>(user, "Пользователь успешно получен!");
    }

    //public async Task<ApiResponse<bool>> RegisterUserAsync(UserRequestsDto _user, CancellationToken cancellationToken)
    //{
    //    if (_user == null)
    //        return new ApiResponse<bool>("Данные пользователя не предоставлены.");

    //    if (string.IsNullOrWhiteSpace(_user.UserName))
    //        return new ApiResponse<bool>("Имя пользователя не может быть пустым.");

    //    if (await _userRepository.ExistsAsync(_user.UserName, _user.Email, _user.PhoneNumber, cancellationToken))
    //        return new ApiResponse<bool>("Пользователь уже существует, попробуйте изменить имя, Email или номер телефона!");

    //    _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(_user.PasswordHash);

    //    await _userRepository.AddAsync(_user.Adapt<User>());

    //    return new ApiResponse<bool>(true, "Пользователь успешно добавлен!");
    //}

    public async Task<ApiResponse<bool>> RegisterUserAsync(UserRequestsDto _user, CancellationToken cancellationToken)
    {
        if (_user == null)
            return new ApiResponse<bool>("Данные пользователя не предоставлены.");

        if (string.IsNullOrWhiteSpace(_user.UserName))
            return new ApiResponse<bool>("Имя пользователя не может быть пустым.");

        if (await _userRepository.ExistsAsync(_user.UserName, _user.Email, _user.PhoneNumber, cancellationToken))
            return new ApiResponse<bool>("Пользователь уже существует, попробуйте изменить имя, Email или номер телефона!");

        _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(_user.PasswordHash);

        var user = _user.Adapt<User>();

        if (_user.ImageURL != null)
        {
            var savedFile = await _fileService.SaveAsync(_user.ImageURL);
            if(savedFile == null)
                return new ApiResponse<bool>("Ошибка при сохранении файла изображения пользователя.");
            user.Image = new UserFile()
            {
                UserId = user.Id,
                Name = savedFile.Name,
                Url = savedFile.Url,
                Size = savedFile.Size,
                Extension = savedFile.Extension
            };
        }

        // Сохраняем пользователя в БД
        await _userRepository.AddAsync(user);

        return new ApiResponse<bool>(true, "Пользователь успешно добавлен!");
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
        
        return new ApiResponse<bool>("Пользователь не найден или заблокирован.");
    }

    public async Task<ApiResponse<string>> AuthenticateAsync(string username, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        if (user == null || !user.IsActive)
            return new ApiResponse<string>("Пользователь не найден или заблокирован!");

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return new ApiResponse<string>("Неверный пароль!");

        var token = _jwtService.GenerateToken(user);

        return new ApiResponse<string>(token, "Успешный вход");
    }

    //public async Task<bool> RegisterUserAsync(string username, string password)
    //{
    //    if (await _userRepository.ExistsAsync(username))
    //        return false;

    //    var user = new User
    //    {
    //        UserName = username,
    //        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
    //    };

    //    await _userRepository.AddAsync(user);
    //    return true;
    //}

}

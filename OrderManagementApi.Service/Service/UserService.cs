using AutoMapper;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;
using OrderManagementApi.DTO.User.Dto;
using OrderManagementApi.DTO.User.Request;
using OrderManagementApi.DTO.User.Response;
using OrderManagementApi.Service.Abstract;
using OrderManagementApi.Service.Validator.User;
using OrderManagementApi.Utility;

namespace OrderManagementApi.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserListResponse> List()
        {
            UserListResponse response = new UserListResponse();
            try
            {
                IList<User> users = await _userRepository.GetAllAsync(p => p.IsActive == true);
                if (!users.Any())
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;

                }
                response.Users = _mapper.Map<List<UserDto>>(users);
                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<UserSaveResponse> Save(UserSaveRequest userSaveRequest)
        {
            UserSaveResponse response = new UserSaveResponse();
            try
            {
                UserSaveRequestValidator validationRules = new UserSaveRequestValidator();
                var validationResult = validationRules.Validate(userSaveRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }

                User user = _mapper.Map<User>(userSaveRequest);
                user.CreatedById = 1;
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;

                await _userRepository.AddAsync(user);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<UserDeleteResponse> Delete(UserDeleteRequest userDeleteRequest)
        {
            UserDeleteResponse response = new UserDeleteResponse();
            try
            {
                User user = await _userRepository.GetAsync(p => p.Id == userDeleteRequest.Id);

                if (user == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                user.IsActive = false;
                user.ModifiedById = 1;
                user.ModifiedDate = DateTime.Now;

                await _userRepository.UpdateAsync(user);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<UserUpdateResponse> Update(UserUpdateRequest userUpdateRequest)
        {
            UserUpdateResponse response = new UserUpdateResponse();
            try
            {
                UserUpdateRequestValidator validationRules = new UserUpdateRequestValidator();
                var validationResult = validationRules.Validate(userUpdateRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }

                User user = await _userRepository.GetAsync(p => p.Id == userUpdateRequest.Id);
                if (user == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                user.Name = userUpdateRequest.Name;
                user.Surname = userUpdateRequest.Surname;
                user.Email = userUpdateRequest.Email;
                user.Username = userUpdateRequest.Username;
                user.Password = userUpdateRequest.Password;
                user.ModifiedById = 1;
                user.ModifiedDate = DateTime.Now;

                await _userRepository.UpdateAsync(user);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<UserGetResponse> LoginControl(UserGetRequest userGetRequest)
        {
            UserGetResponse response = new UserGetResponse();
            try
            {
                User user = await _userRepository.GetAsync(p => p.IsActive == true && p.Username == userGetRequest.Username && p.Password == userGetRequest.Password);

                if (user == null)
                {
                    response.GenerateErrorResponse(MessageConstants.AUTH_ERROR);
                    return response;
                }
                response.GenerateSuccessResponse();

            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

    }
}
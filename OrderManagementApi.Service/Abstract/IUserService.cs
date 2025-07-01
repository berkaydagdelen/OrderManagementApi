using OrderManagementApi.DTO.Login.Request;
using OrderManagementApi.DTO.User.Request;
using OrderManagementApi.DTO.User.Response;

namespace OrderManagementApi.Service.Abstract
{
    public interface IUserService
    {
        Task<UserListResponse> List();
        Task<UserSaveResponse> Save(UserSaveRequest userSaveRequest);
        Task<UserDeleteResponse> Delete(UserDeleteRequest userDeleteRequest);
        Task<UserUpdateResponse> Update(UserUpdateRequest userUpdateRequest);
        Task<UserGetResponse> LoginControl(UserGetRequest userGetRequest);
    }
}
using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.DTO.User.Request;
using OrderManagementApi.DTO.User.Response;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<UserListResponse>> List()
        {

            UserListResponse userListResponse = await _userService.List();
            return Ok(userListResponse);
        }
        [HttpPost]
        public async Task<ActionResult<UserSaveResponse>> Save(UserSaveRequest userSaveRequest)
        {
            UserSaveResponse userSaveResponse = await _userService.Save(userSaveRequest);
            return Ok(userSaveResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<UserDeleteResponse>> Delete(UserDeleteRequest userDeleteRequest)
        {
            UserDeleteResponse userDeleteResponse = await _userService.Delete(userDeleteRequest);
            return Ok(userDeleteResponse);
        }

        [HttpPut]
        public async Task<ActionResult<UserUpdateResponse>> Update(UserUpdateRequest userUpdateRequest)
        {
            UserUpdateResponse userUpdateResponse = await _userService.Update(userUpdateRequest);
            return Ok(userUpdateResponse);
        }


    }
}

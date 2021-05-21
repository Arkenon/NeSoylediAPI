using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace NeSoyledi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserService _userService;
        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public UserDetailDTO GetUserDetail(int id)
        {
            var _user = _userService.GetUserDetail(id);
            var user = _mapper.Map<UserDetailDTO>(_user);
            user.CommentCount = _user.Comments.Count();
            user.DiscourseCount = _user.Discourses.Count();
            return user;
        }


        [Authorize]
        [HttpGet("")]
        public UserDTO GetUserByToken()
        {
            string authorizationHeader = HttpContext.Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var _jsonToken = handler.ReadToken(authorizationHeader.Substring(7));
            var jsonToken = _jsonToken as JwtSecurityToken;
            var userEmail = jsonToken.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            var _findUser = _userService.Where(x => x.UserEmail == userEmail).FirstOrDefault();
            if (_findUser != null)
            {
                return _mapper.Map<UserDTO>(_findUser);
            }
            else
            {
                return null;
            }
        }
    }
}

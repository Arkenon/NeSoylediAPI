using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;
using System;
using System.Linq;

namespace NeSoyledi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserService _userService;
        private readonly IConfiguration _configuration;
        public LoginController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("")]
        public Token Login(UserLoginDTO userLogin)
        {
            var _findUser = _userService.Where(x => x.UserEmail == userLogin.UserEmail && x.UserPass == userLogin.UserPass).FirstOrDefault();
            if (_findUser != null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(_findUser);
                UserTokenUpdateDTO userTokenUpdateDTO = new UserTokenUpdateDTO()
                {
                    Id = _findUser.Id,
                    RefreshToken = token.RefreshToken,
                    RefreshTokenEndDate = token.Expiration.AddDays(365)
                };
                var user = _mapper.Map<User>(userTokenUpdateDTO);
                var update = _userService.UpdateUserToken(user);

                if (update)
                {
                    return token;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        [HttpPost("")]
        public Token RefreshLogin(string refreshToken)
        {
            var _findUser = _userService.Where(x => x.RefreshToken == refreshToken).FirstOrDefault();
            if (_findUser != null && _findUser?.RefreshTokenEndDate < DateTime.Now)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(_findUser);
                UserTokenUpdateDTO userTokenUpdateDTO = new UserTokenUpdateDTO()
                {
                    Id = _findUser.Id,
                    RefreshToken = token.RefreshToken,
                    RefreshTokenEndDate = token.Expiration.AddDays(365)
                };
                var user = _mapper.Map<User>(userTokenUpdateDTO);
                var update = _userService.UpdateUserToken(user);

                if (update)
                {
                    return token;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}

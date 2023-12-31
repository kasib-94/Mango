﻿using Mango.MessageBus;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services.IServices;

using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;
        public AuthAPIController(IAuthService authService, IMessageBus messegeBus, IConfiguration configuration)
        {
            _authService = authService;
            _response = new ResponseDto();
            _messageBus = messegeBus;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var resultMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                _response.IsSuccess = false;
                _response.Message = resultMessage;
                return BadRequest(_response);

            }
            var value = _configuration.GetValue<string>("ApiSettings:TopicAndQueueNames:RegisterUserQueue");
            await _messageBus.PublishMessage(model.Email, value);

            return Ok(_response);
        }


        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccesfull = await _authService.AssignRole(model.Email.ToUpper(), model.Role.ToUpper());
            if (!assignRoleSuccesfull)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }


    }
}

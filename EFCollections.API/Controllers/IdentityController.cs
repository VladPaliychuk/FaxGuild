using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace EFCollections.API.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly IValidator<SignInRequest> signInValidator;
        private readonly IValidator<SignUpRequest> signUpValidator;
        private readonly ILogger<IdentityController> logger;
        private readonly IIdentityService identityService;

        public IdentityController(IValidator<SignInRequest> signInValidator, 
            IValidator<SignUpRequest> signUpValidator, 
            ILogger<IdentityController> logger,
            IIdentityService identityService)
        {
            this.signInValidator = signInValidator;
            this.signUpValidator = signUpValidator;
            this.logger = logger;
            this.identityService = identityService;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<JwtResponse>> SignInAsync([FromBody] SignInRequest request)
        {
            try
            {
                var valid = signInValidator.Validate(request);

                if (request == null) { throw new ArgumentNullException(nameof(request)); }
                if (!valid.IsValid) { throw new ValidationException(valid.Errors); }

                var response = await identityService.SignInAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі SignInAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<JwtResponse>> SignUpAsync([FromBody] SignUpRequest request)
        {
            try
            {
                if (request == null) { throw new ArgumentNullException(nameof(request)); }
                if (!signUpValidator.Validate(request).IsValid) { throw new Exception(nameof(request)); }

                var response = await identityService.SignUpAsync(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі SignUpAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            } 
        }
    }
}

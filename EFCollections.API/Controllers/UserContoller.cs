using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCollections.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(
            ILogger<UserController> logger,
            IUserRepository userRepository,
            IUserService userService,
            ITokenService tokenService
            )
        {
            _logger = logger;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("GetAccessTokenByRefreshToken")]
        public async Task<IActionResult> RenewAccessToken([FromBody] string requesttoken)
        {
            try
            {
                var newToken = _tokenService.GetAccessTokenByRefreshToken(requesttoken);

                return Ok(newToken);
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }

        /*[HttpGet("Get BLL")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GeAllBLLAsync()
        {
            try
            {
                var result = await _userService.GetAllAsync();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GeAllBLLAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpDelete("DeleteById BLL {id} (Firstly need delete all references, will be updated later)")]
        public async Task<ActionResult> DeleteByIdBLL(int id)
        {
            try
            {
                if (id != 0)
                {
                    await _userService.DeleteByIdAsync(id);
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return BadRequest("Id = 0");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DeleteByIdBLL - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpPost("InserBLL")]
        public async Task<ActionResult> Insert([FromBody] UserResponse user)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                UserValidator validator = new UserValidator();
                ValidationResult result = validator.Validate(user);

                if (!result.IsValid)
                {
                    List<string> errors = result.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _userService.InsertAsync(user);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі InsertAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("BLL{id}")]
        public async Task<ActionResult<UserResponse>> GetByIdBLLAsync(int id)
        {
            try
            {
                var result = await _userService.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали івент з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpPut("Update BLL")]
        public async Task<ActionResult<UserResponse>> UpdateAsync([FromBody] UserRequest request)
        {
            try
            {
                if (request == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                await _userService.UpdateAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі InsertAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }*/
    }
}

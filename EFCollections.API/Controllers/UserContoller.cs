using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Validation;
using EFCollections.DAL.Interfaces.Repositories;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EFCollections.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public UserController(
            ILogger<UserController> logger,
            IUserRepository userRepository,
            IUserService userService
            )
        {
            _logger = logger;
            _userService = userService;
            _userRepository = userRepository;
        }
        /// <summary>
        /// Get filtered users with id less then specified
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get FilteredUser {lessThen}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetFilteredUserAsync(int lessThen)
        {
            try
            {
                var result = await _userService.GetFilteredUsersAsync(lessThen);
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetSortedUsers() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("Get SortedByName BLL")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetSortedUsersAsync()
        {
            try
            {
                var result = await _userService.GetSortByNameAsync();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetSortedUsers() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("Get BLL")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GeAllBLLAsync()
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
        public async Task<ActionResult> Insert([FromBody] UserDto user)
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
        public async Task<ActionResult<UserDto>> GetByIdBLLAsync(int id)
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
        public async Task<ActionResult<UserDto>> UpdateAsync([FromBody] UserDto user)
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

                await _userService.UpdateAsync(user);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі InsertAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}

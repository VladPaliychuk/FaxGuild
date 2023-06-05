using EFCollections.BLL.DTO.Requests;
using EFCollections.BLL.DTO.Responses;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Validation;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EFCollections.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly ILogger<StorageController> _logger;
        private readonly IStorageService _storageService;
        private readonly IStorageRepository _storageRepository;
        public StorageController(
            ILogger<StorageController> logger,
            IStorageRepository storageRepository,
            IStorageService StorageService
            )
        {
            _logger = logger;
            _storageService = StorageService;
            _storageRepository = storageRepository;
        }

        [HttpGet("Get BLL")]
        public async Task<ActionResult<IEnumerable<StorageResponse>>> GeAllBLLAsync()
        {
            try
            {
                var result = await _storageService.GetAllAsync();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GeAllBLLAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpDelete("DeleteByDoubleId BLL")]
        public async Task<ActionResult> DeleteByIdBLL(int userId, int postId)
        {
            try
            {
                if (userId != 0 && postId != 0)
                {
                    await _storageService.DeleteByDoubleIdAsync(userId,postId);
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

        [HttpDelete("DeleteByUserId BLL")]
        public async Task<ActionResult> DeleteByUserAsync(int userId)
        {
            try
            {
                if (userId != 0)
                {
                    await _storageService.DeleteByUserAsync(userId);
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
        public async Task<ActionResult> Insert([FromBody] StorageRequest storage)
        {
            try
            {
                if (storage == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                await _storageService.InsertAsync(storage);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі InsertAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("BLL{id}")]
        public async Task<ActionResult<StorageResponse>> GetByIdBLLAsync(int id)
        {
            try
            {
                var result = await _storageService.GetByIdAsync(id);
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
    }
}

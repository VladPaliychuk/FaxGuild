using EFCollections.BLL.DTO;
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
    public class CollectionController : ControllerBase
    {
        private readonly ILogger<CollectionController> _logger;
        private readonly ICollectionService _collectionService;
        private readonly ICollectionRepository _collectionRepository;
        public CollectionController(
            ILogger<CollectionController> logger,
            ICollectionRepository collectionRepository,
            ICollectionService collectionService
            )
        {
            _logger = logger;
            _collectionService = collectionService;
            _collectionRepository = collectionRepository;
        }

        [HttpGet("Get BLL")]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GeAllBLLAsync()
        {
            try
            {
                var result = await _collectionService.GetAllAsync();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GeAllBLLAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpDelete("DeleteById BLL {id}")]
        public async Task<ActionResult> DeleteByIdBLL(int id)
        {
            try
            {
                if (id != 0)
                {
                    await _collectionService.DeleteByIdAsync(id);
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
        public async Task<ActionResult> Insert([FromBody] CollectionDto collection)
        {
            try
            {
                if (collection == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                CollectionValidator validator = new CollectionValidator();
                ValidationResult result = validator.Validate(collection);

                if (!result.IsValid)
                {
                    List<string> errors = result.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _collectionService.InsertAsync(collection);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі InsertAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("BLL{id}")]
        public async Task<ActionResult<CollectionDto>> GetByIdBLLAsync(int id)
        {
            try
            {
                var result = await _collectionService.GetByIdAsync(id);
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
        public async Task<ActionResult<CollectionDto>> UpdateAsync([FromBody] CollectionDto collection)
        {
            try
            {
                if (collection == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                CollectionValidator validator = new CollectionValidator();
                ValidationResult result = validator.Validate(collection);

                if (!result.IsValid)
                {
                    List<string> errors = result.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _collectionService.UpdateAsync(collection);
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

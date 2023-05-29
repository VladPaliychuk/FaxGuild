using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Services;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCollections.API.Controllers
{
    public class CollectionPostController : ControllerBase
    {
        private readonly ILogger<CollectionPostController> _logger;
        private readonly ICollectionPostService _collectionPostService;
        private readonly ICollectionPostRepository _collectionPostRepository;
        public CollectionPostController(
            ILogger<CollectionPostController> logger,
            ICollectionPostService collectionPostService,
            ICollectionPostRepository collectionPostRepository
            )
        {
            _logger = logger;
            _collectionPostService = collectionPostService;
            _collectionPostRepository = collectionPostRepository;
        }
        [HttpGet("Get BLL")]
        public async Task<ActionResult<IEnumerable<CollectionPostDto>>> GeAllBLLAsync()
        {
            try
            {
                var result = await _collectionPostService.GetAllAsync();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GeAllBLLAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpDelete("DeleteById BLL")]
        public async Task<ActionResult> DeleteByIdBLL(int collectionId, int postId)
        {
            try
            {
                if (collectionId != 0 && postId != 0)
                {
                    await _collectionPostService.DeleteByDoubleIdAsync(collectionId, postId);
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

        [HttpDelete("DeleteByCollectionId BLL")]
        public async Task<ActionResult> DeleteByUserAsync(int collectionId)
        {
            try
            {
                if (collectionId != 0)
                {
                    await _collectionPostService.DeleteByCollectionAsync(collectionId);
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
        public async Task<ActionResult> Insert([FromBody] CollectionPostDto post)
        {
            try
            {
                if (post == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                await _collectionPostService.InsertAsync(post);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі InsertAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("BLL{id}")]
        public async Task<ActionResult<CollectionPostDto>> GetByIdBLLAsync(int id)
        {
            try
            {
                var result = await _collectionPostService.GetByIdAsync(id);
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
        public async Task<ActionResult<CollectionPostDto>> UpdateAsync([FromBody] CollectionPostDto post)
        {
            try
            {
                if (post == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                await _collectionPostService.UpdateAsync(post);
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


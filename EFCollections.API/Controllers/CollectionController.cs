using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCollections.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ILogger<CollectionController> _logger;
        private IUnitOfWork _ADOuow;
        public CollectionController(ILogger<CollectionController> logger,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var results = await _ADOuow.CollectionRepository.GetAsync();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}

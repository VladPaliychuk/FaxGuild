﻿using EFCollections.BLL.DTO;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Validation;
using EFCollections.DAL.Interfaces.Repositories;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EFCollections.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        private readonly IPostRepository _postRepository;
        public PostController(
            ILogger<PostController> logger,
            IPostRepository postRepository,
            IPostService PostService
            )
        {
            _logger = logger;
            _postService = PostService;
            _postRepository = postRepository;
        }

        [HttpGet("Get BLL")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GeAllBLLAsync()
        {
            try
            {
                var result = await _postService.GetAllAsync();
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
                    await _postService.DeleteByIdAsync(id);
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
        public async Task<ActionResult> Insert([FromBody] PostDto post)
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

                PostValidator validator = new PostValidator();
                ValidationResult result = validator.Validate(post);

                if (!result.IsValid)
                {
                    List<string> errors = result.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _postService.InsertAsync(post);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі InsertAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("BLL{id}")]
        public async Task<ActionResult<PostDto>> GetByIdBLLAsync(int id)
        {
            try
            {
                var result = await _postService.GetByIdAsync(id);
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
        public async Task<ActionResult<PostDto>> UpdateAsync([FromBody] PostDto post)
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

                PostValidator validator = new PostValidator();
                ValidationResult result = validator.Validate(post);

                if (!result.IsValid)
                {
                    List<string> errors = result.Errors.Select(error => error.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await _postService.UpdateAsync(post);
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

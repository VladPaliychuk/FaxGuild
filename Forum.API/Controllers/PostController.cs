using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ForumDAL.Entities;
//using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using ForumDAL.Repositories.Contracts;
using Forum.BLL.Interfaces;
using Forum.BLL.DTOs;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        private IUnitOfWork _ADOuow;
        public PostController(ILogger<PostController> logger,
            IUnitOfWork ado_unitofwork, IPostService postService)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
            _postService = postService;
        }

        [HttpGet("GetById BLL")]
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            var posts = await _postService.GetPostById(id);
            
            try
            {
                _ADOuow.Commit();
                if (posts == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали івент з бази даних!");
                    return Ok(posts);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("BLL-GetAllPosts")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            try
            {
                var results = await _postService.GetAllPosts();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllPosts() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("GetAverageLikes BLL")]
        public async Task<ActionResult<int>> GetAverageLikesAsync()
        {
            try
            {
                var results = await _postService.GetAverageLikes();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllPostsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPostsAsync()
        {
            try
            {
                var results = await _ADOuow._postRepository.GetAllAsync();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllPostsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow._postRepository.GetAsync(id);
                _ADOuow.Commit();
                if (result  == null)
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
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/events
        [HttpPost]
        public async Task<ActionResult> PostEventAsync([FromBody] Post evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                var created_id = await _ADOuow._postRepository.AddAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/events/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Post evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                var event_entity =  await _ADOuow._postRepository.GetAsync(id);
                if(event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                 await _ADOuow._postRepository.ReplaceAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/events/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _ADOuow._postRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._postRepository.DeleteAsync(id);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DeleteByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        /// <summary>
        /// Додає зв'язок мені ту мені між таблицями Post і Tag у таблицю PostTag
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="tagName">example: Cyril7</param>
        /// <returns></returns>
        [HttpPost("AddPostToTag (adding id's to PostTag)")]
        public async Task<ActionResult> AddTagToPostAsync(int postId, string tagName)
        {
            try
            {
                var event_entity = await _ADOuow._postRepository.GetAsync(postId);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {postId}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._postRepository.AddTagToPost(postId, tagName);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі AddTagToPostAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("GetAllTagsByPostId")]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllTagsByPostIdAsync(int postId)
        {
            try
            {
                var results = await _ADOuow._postRepository.GetAllTagsByPostIdAsync(postId);
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllTagsByPostIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}

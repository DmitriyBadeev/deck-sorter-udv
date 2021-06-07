using System.Linq;
using DeckSorter.Api.Dto;
using DeckSorter.Core.Entities;
using DeckSorter.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeckSorter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IRepository<Deck> _repository;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;

        public DeckController(IRepository<Deck> repository, IShuffleAlgorithm shuffleAlgorithm)
        {
            _repository = repository;
            _shuffleAlgorithm = shuffleAlgorithm;
        }
    
        /// <summary>
        /// Создать именованную колоду карт (колода создаётся упорядоченной)
        /// </summary>
        /// <param name="name">Имя колоды</param>
        [HttpPost]
        public IActionResult Create([FromBody] string name)
        {
            var deck = _repository.Get(name);
            
            if (deck != null)
            {
                return BadRequest($"Колода с именем {name} уже существует");
            }
            
            _repository.Create(name);

            return Ok();
        }
        
        /// <summary>
        /// Удалить именованную колоду
        /// </summary>
        /// <param name="name">Имя колоды</param>
        [HttpDelete]
        public IActionResult Remove([FromQuery] string name)
        {
            var deck = _repository.Get(name);
            
            if (deck == null)
            {
                return NotFound($"Колода с именем {name} не найдена");
            }
            
            _repository.Delete(name);

            return Ok();
        }
        
        /// <summary>
        /// Получить список названий колод
        /// </summary>
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var decks = _repository.GetAll().Select(d => d.Name);
            
            return Ok(decks);
        }
        
        /// <summary>
        /// Перетасовать колоду 
        /// </summary>
        /// <remarks>
        /// Алгоритм задается в конфигурации приложения полем ShuffleAlgorithm
        ///
        /// Доступны 2 алгоритма: Common и Manually. 
        /// </remarks>
        /// <param name="name">Имя колоды</param>
        [HttpPost("shuffle")]
        public IActionResult Shuffle([FromBody] string name)
        {
            var deck = _repository.Get(name);
            
            if (deck == null)
            {
                return NotFound($"Колода с именем {name} не найдена");
            }
            
            deck.ShuffleCards(_shuffleAlgorithm);
            
            return Ok();
        }
        
        /// <summary>
        /// Получить колоду по имени (в её текущем состоянии)
        /// </summary>
        /// <param name="name">Имя колоды</param>
        [HttpGet]
        public IActionResult Get([FromQuery] string name)
        {
            var deck = _repository.Get(name);

            if (deck == null)
            {
                return NotFound($"Колода с именем {name} не найдена");
            }

            var deckDto = new DeckDto(deck);
            
            return Ok(deckDto);
        }
    }
}
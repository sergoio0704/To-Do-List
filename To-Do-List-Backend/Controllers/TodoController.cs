using Microsoft.AspNetCore.Mvc;
using To_Do_List_Backend.Dto;
using To_Do_List_Backend.Services;

namespace To_Do_List_Backend.Controllers
{
    [ApiController]
    [Route( "rest/{controller}")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController( ITodoService todoService )
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            try
            {
                return Ok( _todoService.GetTodos()
                    .ConvertAll( t => t.ConvertToTodoDto() ) );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpGet]
        [Route( "{todoId}" )]
        public IActionResult GetTodo( int todoId )
        {
            try
            {
                return Ok( _todoService.GetTodo( todoId ).ConvertToTodoDto() );
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpPost]
        [Route( "create" )]
        public IActionResult CreateTodo( [FromBody] TodoDto todo )
        {
            try
            {
                return Ok( _todoService.CreateTodo( todo ) );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpDelete]
        [Route( "{todoId}/delete" )]
        public IActionResult DeleteTodo( int todoId )
        {
            try
            {
                _todoService.DeleteTodo( todoId );
                return Ok();
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }

        [HttpPut]
        [Route( "{todoId}/complete" )]
        public IActionResult CompleteTodo( int todoId )
        {
            try
            {
                return Ok( _todoService.CompleteTodo( todoId ) );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }
        }
    }
}

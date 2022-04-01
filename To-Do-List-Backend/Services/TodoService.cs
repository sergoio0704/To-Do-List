using To_Do_List_Backend.Domain;
using To_Do_List_Backend.Dto;
using To_Do_List_Backend.Repositories;

namespace To_Do_List_Backend.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService( ITodoRepository todoRepository )
        {
            _todoRepository = todoRepository;
        }

        public List<Todo> GetTodos()
        {
            return _todoRepository.GetTodos();
        }

        public int CompleteTodo( int todoId )
        {
            Todo todo = _todoRepository.Get( todoId );
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found, #Id - {todoId}" );
            }

            if ( todo.IsDone )
            {
                return todo.Id;
            }
            else
            {
                todo.SetComplete();
            }

            return _todoRepository.Update( todo );
        }

        public int CreateTodo( TodoDto todo )
        {
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found" );
            }

            Todo todoEntity = todo.ConvertToTodo();

            return _todoRepository.Create( todoEntity );
        }

        public void DeleteTodo( int todoId )
        {
            Todo todo = _todoRepository.Get( todoId );
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found, #Id - {todoId}" );
            }

            _todoRepository.Delete( todo );
        }

        public Todo GetTodo( int todoId )
        {
            Todo todo = _todoRepository.Get( todoId );
            if ( todo == null )
            {
                throw new Exception( $"{nameof( Todo )} not found, #Id - {todoId}" );
            }

            return todo;
        }
    }
}

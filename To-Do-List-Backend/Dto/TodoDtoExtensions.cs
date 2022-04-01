using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Dto
{
    public static class TodoDtoExtensions
    {
        public static Todo ConvertToTodo( this TodoDto todoDto )
        {
            return new Todo
            {
                Id = todoDto.Id,
                Title = todoDto.Title,
                IsDone = todoDto.IsDone
            };
        }

        public static TodoDto ConvertToTodoDto( this Todo todoDto )
        {
            return new TodoDto
            {
                Id = todoDto.Id,
                Title = todoDto.Title,
                IsDone = todoDto.IsDone
            };
        }
    }
}

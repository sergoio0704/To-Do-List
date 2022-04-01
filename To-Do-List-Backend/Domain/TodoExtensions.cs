namespace To_Do_List_Backend.Domain
{
    public static class TodoExtensions
    {
        public static void SetComplete( this Todo todo )
        {
            todo.IsDone = true;
        }
    }
}

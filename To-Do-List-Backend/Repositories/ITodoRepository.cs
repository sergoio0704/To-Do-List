﻿using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Repositories
{
    public interface ITodoRepository
    {
        List<Todo> GetTodos();
        Todo Get( int id );
        int Create( Todo todo );
        void Delete( Todo todo );
        int Update( Todo todo );
    }
}

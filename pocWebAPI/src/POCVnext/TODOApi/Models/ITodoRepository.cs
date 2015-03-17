﻿using System;
using System.Collections.Generic;

namespace POCVnext.TODOApi.Models
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> AllItems { get; }
        void Add(TodoItem item);
        TodoItem GetById(int id);
        bool TryDelete(int id);
    }
}
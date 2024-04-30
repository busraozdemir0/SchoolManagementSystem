﻿using DataAccessLayer.Repository.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IRepository<Comment>
    {
        Task SafeDeleteCommentAsync(Guid commentId);
        Task UndoDeleteCommentAsync(Guid commentId);
    }
}

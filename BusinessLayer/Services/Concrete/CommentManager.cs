using BusinessLayer.Services.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Extensions;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CommentManager(ICommentDal commentDal, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _commentDal = commentDal;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<Comment>> GetDeletedListAsync()
        {
            return await _commentDal.GetAllAsync(x => x.IsDeleted, u => u.User);
        }

        public async Task<List<Comment>> GetListAsync()
        {
            return await _commentDal.GetAllAsync(x => !x.IsDeleted, u => u.User, i => i.User.Image);
        }

        public async Task TAddAsync(Comment t)
        {
            Comment comment = new()
            {
                Content = t.Content,
                UserId = _user.GetLoggedInUserId(), // Giris yapip da yorum yapan kisinin id'sini tabloya kaydediyoruz.
                CreatedDate = t.CreatedDate,
            };
            await _commentDal.AddAsync(comment);
            await _unitOfWork.SaveAsync();
        }

        public async Task TDeleteAsync(Comment t)
        {
            await _commentDal.DeleteAsync(t);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Comment> TGetByGuidAsync(Guid id)
        {
            return await _commentDal.GetByGuidAsync(id);
        }

        public async Task TSafeDeleteCommentAsync(Guid commentId)
        {
            await _commentDal.SafeDeleteCommentAsync(commentId);
        }

        public async Task TUndoDeleteCommentAsync(Guid commentId)
        {
            await _commentDal.UndoDeleteCommentAsync(commentId);
        }

        public async Task TUpdateAsync(Comment t)
        {
            await _commentDal.UpdateAsync(t);
            await _unitOfWork.SaveAsync();
        }
    }
}

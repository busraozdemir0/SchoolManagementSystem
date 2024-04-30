using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : Repository<Comment>, ICommentDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfCommentRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SafeDeleteCommentAsync(Guid commentId)
        {
            var comment = await _unitOfWork.GetRepository<Comment>().GetAsync(x => x.Id == commentId);

            comment.IsDeleted = true;
            comment.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await _unitOfWork.SaveAsync();
        }

        public async Task UndoDeleteCommentAsync(Guid commentId)
        {
            var comment = await _unitOfWork.GetRepository<Comment>().GetAsync(x => x.Id == commentId);

            comment.IsDeleted = false;
            comment.DeletedDate = null;

            await _unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await _unitOfWork.SaveAsync();
        }
    }
}

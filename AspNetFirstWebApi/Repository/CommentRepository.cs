using AspNetFirstWebApi.Data;
using AspNetFirstWebApi.Interfaces;
using AspNetFirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetFirstWebApi.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext content)
        {
            _context = content;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }
        
    }
}

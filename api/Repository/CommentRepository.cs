using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Inferfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);

        }

        public async Task<Comment> CreateAsync(Comment CommentModel)
        {
            await _context.Comments.AddAsync(CommentModel);
            await _context.SaveChangesAsync();

            return CommentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var ExistingComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (ExistingComment == null)
            {
                return null;
            }

            ExistingComment.Title = commentModel.Title;
            ExistingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return ExistingComment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var ExistingComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (ExistingComment == null)
            {
                return null;
            }

            _context.Comments.Remove(ExistingComment);
            await _context.SaveChangesAsync();

            return ExistingComment;
        }
    }
}
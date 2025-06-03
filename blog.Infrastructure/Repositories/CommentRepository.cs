using blog.Core.Entities;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace blog.Infrastructure.Repositories
{
    public class CommentRepository: Reposetory<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CommentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Comment> UpdateCommentAsync(int commnet_id, Comment updateObj)
        {
            // Fetch the existing business profile by id
            var existingModal = await dbContext.TblComment.FirstOrDefaultAsync(x => x.comment_id == commnet_id);

            if (existingModal == null) throw new InvalidOperationException("Comment not found");

            try
            {
                // Update properties (only if provided)
                if (!string.IsNullOrWhiteSpace(updateObj.comment_name)) existingModal.comment_name = updateObj.comment_name;

                if (!string.IsNullOrWhiteSpace(updateObj.comment_email)) existingModal.comment_email = updateObj.comment_email;

                if (!string.IsNullOrWhiteSpace(updateObj.comment_phone)) existingModal.comment_phone = updateObj.comment_phone;

                if (!string.IsNullOrWhiteSpace(updateObj.comment_message)) existingModal.comment_message = updateObj.comment_message;

                if (!string.IsNullOrWhiteSpace(updateObj.comment_reply)) existingModal.comment_reply = updateObj.comment_reply;

                if (!string.IsNullOrWhiteSpace(updateObj.comment_url)) existingModal.comment_url = updateObj.comment_url;

                existingModal.status = updateObj.status;
                existingModal.updated_by = updateObj.updated_by;
                existingModal.updated_at = updateObj.updated_at;

                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception here (e.g., using a logging framework)
                throw new InvalidOperationException("Error updating business profile", ex);
            }
            return existingModal; // Return the updated profile

        }
    }
}

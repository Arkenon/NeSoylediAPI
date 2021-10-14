using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeSoyledi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICommentService _commentService;
        private IDiscourseService _discourseService;
        private IVersusService _versusService;
        public CommentController(ICommentService commentService, IMapper mapper, IDiscourseService discourseService, IVersusService versusService)
        {
            _mapper = mapper;
            _commentService = commentService;
            _discourseService = discourseService;
            _versusService = versusService;
        }

        [HttpGet("{id}")]
        public async Task<CommentDTO> GetById(int id)
        {
            var _comment = await _commentService.GetById(id);
            var comment = _mapper.Map<CommentDTO>(_comment);
            return comment;
        }

        [HttpGet("{postId}")]
        public IEnumerable<CommentDTO> GetCommentsByPostId(int pageNumber, int pageSize, int postId)
        {
            var comment = _commentService.GetCommentsByPostId(pageNumber, pageSize, postId);
            var commentList = _mapper.Map<IEnumerable<CommentDTO>>(comment);
            var metadata = new
            {
                comment.TotalCount,
                comment.PageSize,
                comment.CurrentPage,
                comment.TotalPages,
                comment.HasNext,
                comment.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return commentList;
        }


        [HttpGet("{userId}")]
        public IEnumerable<CommentByUserDTO> GetCommentsByUserId(int pageNumber, int pageSize, int userId)
        {
            var comments = _commentService.GetCommentsByUserId(pageNumber, pageSize, userId);
            var commentList = _mapper.Map<IEnumerable<CommentByUserDTO>>(comments);

            var metadata = new
            {
                comments.TotalCount,
                comments.PageSize,
                comments.CurrentPage,
                comments.TotalPages,
                comments.HasNext,
                comments.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return commentList;
        }

        [HttpPost]
        public async Task<SaveCommentResponseDTO> AddComment(SaveCommentDTO form)
        {
            DiscourseDTO _discourse;
            VersusDTO _versus;

            Comment _comment = new Comment()
            {
                CommentPostId = form.CommentPostId,
                CommentContent = form.CommentContent,
                CommentDate = form.CommentDate,
                CommentPostType = form.CommentPostType,
                CommentStatus = form.CommentStatus,
                UserId = form.UserId,
                UserEmail = form.UserEmail,
                UserAgent = form.UserAgent,
                UserIP = form.UserIP,
                UserName = form.UserName,
                IsActive = form.IsActive

            };

            if (form.CommentPostType == "soylem")
            {
                _discourse = await GetDiscourseById(form.CommentPostId);
                _comment.CommentPostSlug = _discourse.PostSlug;
                _comment.CommentPostTitle = _discourse.DiscourseTitle;
            }
            if (form.CommentPostType == "versus")
            {
                _versus = await GetVersusById(form.CommentPostId);
                _comment.CommentPostSlug = _versus.PostSlug;
                _comment.CommentPostTitle = _versus.VersusTitle;
            }

          
            var id = _commentService.Create(_comment);

            CommentDTO new_comment = await GetById(id);

            SaveCommentResponseDTO res = new SaveCommentResponseDTO()
            {
                ErrorMessage = "",
                Status = true,
                Comment = new_comment
            };
            return res;

        }

        private async Task<DiscourseDTO> GetDiscourseById(int id)
        {
            var _discourse = await _discourseService.GetById(id);
            var discourse = _mapper.Map<DiscourseDTO>(_discourse);
            return discourse;
        }

        private async Task<VersusDTO> GetVersusById(int id)
        {
            var _versus = await _versusService.GetById(id);
            var versus = _mapper.Map<VersusDTO>(_versus);
            return versus;
        }
    }
}

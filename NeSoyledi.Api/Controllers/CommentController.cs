using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NeSoyledi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICommentService _commentService;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _mapper = mapper;
            _commentService = commentService;
        }
        [HttpGet("{userId}")]
        public IEnumerable<CommentByUserDTO> GetCommentsByUserId(int pageNumber, int pageSize, int userId)
        {
            var comment = _commentService.GetCommentsByUserId(pageNumber, pageSize, userId);
            var commentList = _mapper.Map<IEnumerable<CommentByUserDTO>>(comment);
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
    }
}

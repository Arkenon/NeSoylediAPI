using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeSoyledi.Api.Models.DataTypeObjects;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSoyledi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReactionService _reactionService;
        public ReactionController(IMapper mapper, IReactionService reactionService)
        {
            _mapper = mapper;
            _reactionService = reactionService;
        }
        [HttpPost]
        public SaveReactionResponseDTO AddReaction(ReactionDTO form)
        {
            var reaction = _mapper.Map<Reaction>(form);

            var ifExist = _reactionService.Where(x => x.PostId == form.PostId && x.ReactionType == form.ReactionType && x.PostType == form.PostType && (x.UserId == form.UserId || x.UserIP == form.UserIP));

            int add;
            
            if (ifExist.Count() > 0)
            {
                foreach (var item in ifExist)
                {
                    _reactionService.Delete(item.Id);
                }
                add = 0;
            } else
            {
                add = _reactionService.Create(reaction);
            }

            var getTotals = this.GetReactionTotals(form.PostId, form.PostType);

            SaveReactionResponseDTO  res = new SaveReactionResponseDTO()
            {
                ErrorMessage = "",
                Status = true,
                TotalLikes = getTotals.TotalLikes,
                TotalDislikes = getTotals.TotalDislikes,
                TotalFavorites = getTotals.TotalFavorites
            };

            return res;
        }

        [HttpGet("{id}")]
        public SaveReactionResponseDTO GetReactionTotals(int id, string postType)
        {
            var countLikes = _reactionService.Where(x => x.PostId == id && x.ReactionType == 1 && x.PostType == postType).Count();
            var countDislikes = _reactionService.Where(x => x.PostId == id && x.ReactionType == 2 && x.PostType == postType).Count();
            var countFavorites = _reactionService.Where(x => x.PostId == id && x.ReactionType == 3 && x.PostType == postType).Count();
            SaveReactionResponseDTO result = new SaveReactionResponseDTO()
            {
                TotalLikes = countLikes,
                TotalDislikes = countDislikes,
                TotalFavorites = countFavorites
            };
            return result;
        }
    }
}

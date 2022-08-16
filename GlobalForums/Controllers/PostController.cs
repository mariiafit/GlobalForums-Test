﻿using GlobalForums.Data.Domains.Models;
using GlobalForums.Data.Domains.Services;
using GlobalForums.Domains.Models.Post;
using GlobalForums.Domains.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _post;
        private readonly IForum _forumService;

        private static UserManager<ApplicationUser> _userManager;

        public PostController(IPost post, IForum forumService, UserManager<ApplicationUser> userManager)
        {
            _post = post;
            _forumService = forumService;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post = _post.GetById(id);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                DateCreated = post.Created,
                PostContent = post.Content,
                Replies = replies
            };

            return View(model);
        }

        public IActionResult Create(int id)
        {
            //Note id is Forum.Id

            var forum = _forumService.GetById(id);

            var model = new NewPostViewModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var post = BuildPost(model, user);

            await _post.Add(post);
            //TODO: Implement User Rating Management

            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        private Post BuildPost(NewPostViewModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);

            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };
        }

        private IEnumerable<PostReplyViewModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyViewModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                DateCreated = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}

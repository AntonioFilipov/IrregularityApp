namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using MvcTemplate.Web.ViewModels.Comments;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data.Contracts;

    public class CommentsController : Controller
    {
        private readonly ICommentService comments;

        public CommentsController(ICommentService comments)
        {
            this.comments = comments;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int irregularityId, CommentAddViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                this.comments.Add(model.Content, irregularityId, userId);
                return this.Redirect(this.Request.UrlReferrer.ToString());
            }

            return this.Redirect(this.Request.UrlReferrer.ToString());
        }
    }
}
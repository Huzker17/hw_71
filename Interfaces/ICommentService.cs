using hh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hh.ViewModels;


namespace hh.Interfaces
{
    public interface ICommentService : IBaseService<Vacancy>
    {
        CommentPageViewModel GetCommentsForPage(int curPage, int itemsPerPage);
    }
}

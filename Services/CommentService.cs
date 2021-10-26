using hh.Interfaces;
using hh.Models;
using hh.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Vacancy Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacancy> GetAll()
        {
            return _context.Vacancies;
        }

        public void Update(Vacancy o)
        {
            throw new NotImplementedException();
        }



        public CommentPageViewModel GetCommentsForPage(int curPage, int itemsPerPage)
        {
            var comments = _context.Vacancies.ToList();

            var maxPage = (int)Math.Ceiling((double)comments.Count / itemsPerPage);

            List<Vacancy> page = new List<Vacancy>();

            if (curPage == 1)
            {
                page = comments.Take(itemsPerPage).ToList();
            }
            else if (curPage > 1 && curPage < maxPage)
            {
                page = comments.Skip((curPage - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            }
            else
            {
                page = comments.Skip((maxPage - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            }

            CommentPageViewModel model = new CommentPageViewModel
            {
                Vacs = page,
                CurPage = curPage,
                MaxPage = maxPage
            };

            return model;
        }
    }
}


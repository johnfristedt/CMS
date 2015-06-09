using CMS.Models.EntityModels;
using CMS.Models.ViewModels.CreateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.Repositories
{
    public interface ISiteRepository
    {
        Board[] GetBoards();
        Thread[] GetThreadsForBoard(int boardId);
        Post[] GetPostsForThread(int threadId);

        void CreateBoard(CreateBoardViewModel model);
        void CreateThread(CreateThreadViewModel model);

        User GetUser(string username);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.interfaces
{
   public interface IStoryRepository
    {
        Story InsertStory(Story story);
       IEnumerable GetStories();

        void Save();

    }
}

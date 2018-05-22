using DataLayer.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.repositories
{
    public class StoryRepository : IStoryRepository
    {


        private ScrumManagerEntities context;

        public StoryRepository()
        {
            context = new ScrumManagerEntities();
        }

        public IEnumerable GetStories()
        {
            return context.Stories
                          .ToList()
                          .Select(s => new { s.StoryId, s.Name,s.Description });
        }

        public Story InsertStory(Story story)
        {
            return context.Stories.Add(story);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

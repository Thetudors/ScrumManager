using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.interfaces;
using DataLayer.repositories;

namespace BusinessLayer
{
    public class StoryManager : Manager
    {
        public Story currentStory;

        public Status AddStory(Story story)
        {
            try
            {
                IStoryRepository storyRepository = new StoryRepository();

                currentStory = storyRepository.InsertStory(story);

                storyRepository.Save();

                SetCurrentStory(currentStory);


                return Status.Success;
            }
            catch (Exception)
            {
                return Status.Fail;
            }
        }

        private void SetCurrentStory(Story currentStory)
        {
            this.currentStory = new Story
            {
                StoryId = currentStory.StoryId,
                Name = currentStory.Name,
                Description = currentStory.Description
            };
        }

        public IEnumerable GetStories()
        {
            IStoryRepository storyRepository = new StoryRepository();


            return storyRepository.GetStories();
        }

    }

   
}

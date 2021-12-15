﻿namespace QuizSystemWeb.Services.Answers
{
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using QuizSystemWeb.Services.Answers.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext data;

        public AnswerService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool Create(int questionId, string content, bool IsCorrect)
        {
            if (IsCorrect == true)
            {
                var questionAnswers = data.Answers.Where(x => x.QuestionId == questionId).Any(x => x.IsCorrect == true);
                if (questionAnswers)
                {
                    return false;
                }
            }

            var answer = new Answer
            {
                QuestionId = questionId,
                Content = content,
                IsCorrect = IsCorrect
            };

            data.Answers.Add(answer);

            data.SaveChanges();

            return true;
        }

        public bool Delete(int questionId)
        {
            var answers = data.Answers.Where(x => x.QuestionId == questionId);

            data.Answers.RemoveRange(answers);

            data.SaveChanges();

            return true;
        }

        public bool Edit(int answerId, string content, bool IsCorrect)
        {
            var answer = data.Answers.Where(x => x.Id == answerId).FirstOrDefault();
            if(IsCorrect == true)
            {
                var questionAnswers = data.Answers.Where(x => x.QuestionId == answer.QuestionId && x.Id != answerId).Any(x => x.IsCorrect == true);
                if (questionAnswers)
                {
                    return false;
                }
            }
            answer.Content = content;
            answer.IsCorrect = IsCorrect;



            data.Update(answer);
            data.SaveChanges();
            return true;
        }

        public AnswerDetailsServiceModel GetById(int id)
        {
            var answer = data.Answers.Where(x => x.Id == id).Select(x => new AnswerDetailsServiceModel
            {
                Id = x.Id,
                Content = x.Content,
                IsCorrect = x.IsCorrect,
                QuestionId = x.QuestionId
            })
                .FirstOrDefault();
            
            return answer;
        }
    }
}


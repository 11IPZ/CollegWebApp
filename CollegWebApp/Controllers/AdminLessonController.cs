﻿using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels;
using CollegWebApp.Domain.ViewModels.Lesson;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegWebApp.Controllers
{
    public class AdminLessonController : Controller
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IGroupRepository _groupRepository;
        UserManager<User> _userManager;
        public AdminLessonController(ILessonRepository lessonRepository, IGroupRepository groupRepository, UserManager<User> userManager)
        {
            _lessonRepository = lessonRepository;
            _groupRepository = groupRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(List<int>? groupsId, string name)
        {
            List<Lesson> lessons = new List<Lesson>();

            bool all = false;
            if(groupsId != null)
            {
                foreach (int num in groupsId)
                {
                    if(num == 0)
                        all = true;
                }
            }
            // groupsId and name == null
            if(((groupsId == null || groupsId.Count == 0) && String.IsNullOrEmpty(name)) || all)
            {
                lessons = await _lessonRepository.GetAll();   
            }
            // groupsId and name == not empty or null
            else if ((groupsId != null && groupsId.Count != 0) && !String.IsNullOrEmpty(name))
            {
                lessons = await _lessonRepository.GetByIndexParmtr(groupsId, name);
            }
            // name is empty, groupsId not null
            else if (groupsId != null || groupsId.Count != 0)
            {
                lessons = await _lessonRepository.GetByIndexParmtr(groupsId, null);
            }
            // groupsId is null, name not empty
            else if (!String.IsNullOrEmpty(name))
            {
                lessons = await _lessonRepository.GetByIndexParmtr(null, name);
            }

            List<Group> groups = await _groupRepository.GetAll();
            groups.Insert(0, new Group { Id = 0, Name = "Всі" });
            ViewBag.Groups = new MultiSelectList(groups, "Id", "Name");

            LessonListViewModel viewModel = new LessonListViewModel
            {
                Lessons = lessons,
                Name = name,

            };

            return View(lessons);
        }

        public async Task<IActionResult> Lesson(int LessonId)
        {
            Lesson lesson = await _lessonRepository.GetById(LessonId);
            return View(lesson);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Groups = new MultiSelectList(await _groupRepository.GetAll(), "Id", "Name");

            return View();
        }
        
        public async Task<IActionResult> Create(LessonCreateViewModel model)
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            Lesson lessonModel = new Lesson()
            {
                Name = model.Name,
                Description = model.Description,
                HtmlContext = model.HtmlContext,
                DateTimeCreate = DateTime.Today,
                CreatorId = user.Id
            };

            Tuple<int,bool> result = await _lessonRepository.Add(lessonModel);
            if(result.Item2)
            {
                await _lessonRepository.AddGroup(result.Item1, model.GroupsId);
            }

            return RedirectToAction("Index" ,"Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Lesson lesson = await _lessonRepository.GetById(id);
            List<int> GroupsId =  await _lessonRepository.GetGroupsByLessonId(lesson.Id);
            ViewBag.Groups = new MultiSelectList(await _groupRepository.GetAll(), "Id", "Name");

            LessonEditViewModel model = new LessonEditViewModel()
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                HtmlContext = lesson.HtmlContext,
                GroupsId = GroupsId,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LessonEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);

                Lesson lesson = new Lesson()
                {
                    Id=model.Id,
                    Name=model.Name,
                    Description=model.Description,
                    HtmlContext=model.HtmlContext,
                    DateTimeCreate=DateTime.Today,
                    CreatorId=user.Id
                };
                List<int> lastGroupsId = await _lessonRepository.GetGroupsByLessonId(model.Id);
                await _lessonRepository.EditGroup(lesson.Id,lastGroupsId,model.GroupsId);

                bool result = await _lessonRepository.Update(lesson);
                if(result)
                {
                    await _lessonRepository.EditGroup(model.Id, lastGroupsId, model.GroupsId);
                }    
            }

            return RedirectToAction("Index", "Home");
        }

    }
}

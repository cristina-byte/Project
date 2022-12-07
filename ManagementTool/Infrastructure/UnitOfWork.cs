﻿using Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context,IEventRepository eventRepository, 
            IMeetingRepository meetingRepository, IMemberRepository memberRepository,IOportunityRepository oportunityRepository,
            ITaskRepository taskRepository,ITeamRepository teamRepository,IToDoRepository toDoRepository)
        {
            _context = context;
            EventRepository = eventRepository;
            MeetingRepository = meetingRepository;
            MemberRepository = memberRepository;
            OportunityRepository = oportunityRepository;
            TaskRepository = taskRepository;
            TeamRepository = teamRepository;
            ToDoRepository = toDoRepository;
        }

        public IEventRepository EventRepository { get; private set; }

        public IMeetingRepository MeetingRepository { get; private set; }

        public IMemberRepository MemberRepository { get; private set; }

        public IOportunityRepository OportunityRepository { get; private set; }

        public ITaskRepository TaskRepository { get; private set; }

        public ITeamRepository TeamRepository { get; private set; }

        public IToDoRepository ToDoRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

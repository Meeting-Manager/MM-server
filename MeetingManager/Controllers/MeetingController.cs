using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        IMeetingBL meetingBL;
        IMapper mapper;
        public MeetingController(IMeetingBL _meetingBL, IMapper _mapper)
        {
            mapper = _mapper;
            meetingBL = _meetingBL;
        }
        // GET: api/<MeetingController>
        [HttpGet]
        public async Task<List<MeetingDTO>> Get()
        {
            List<Meeting> meetings= await meetingBL.GetAllMeetings();
            List<MeetingDTO> meetingDTO = mapper.Map<List<Meeting>, List<MeetingDTO>>(meetings);
            return meetingDTO;
        }

       

        // POST api/<MeetingController>
        [HttpPost]
        public async Task Post([FromBody] Meeting meeting)
        {
            await meetingBL.PostMeeting(meeting);
        }

        // PUT api/<MeetingController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Meeting value)
        {
            await meetingBL.PutMeeting(id, value);
        }

        // DELETE api/<MeetingController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await meetingBL.DeleteMeeting(id);
        }


    }
}

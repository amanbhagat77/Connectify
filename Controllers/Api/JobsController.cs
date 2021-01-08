using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Connectify.Models;
using Connectify.Dto;
using Connectify.Controllers;
using AutoMapper;
using System.Data.Entity;

namespace Connectify.Controllers.Api
{
    public class JobsController : ApiController
    {
                
        private ApplicationDbContext _context;

        public JobsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get: /api/Jobs
        public IHttpActionResult GetJobList()
        {
            var jobsdto = _context.Jobs
                .Include(j => j.Engineer)
                .ToList()
                .Select(Mapper.Map<Job, JobDto>);

            return Ok(jobsdto);
        }


        //Get /api/Jobs/id
        public IHttpActionResult GetJob(int id)
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job == null)
                return NotFound();

            return Ok(Mapper.Map<Job, JobDto>(job));
        }

        //Get: /api/Jobs/engineerId
        public IHttpActionResult GetJobsByEngineerId(string engineerId)
        {
            var jobs = _context.Jobs
                .Where(j => j.EngineerId == engineerId)
                .ToList()
                .Select(Mapper.Map<Job, JobDto>);

            if (jobs == null)
                return NotFound();

            return Ok(jobs);
        }


        // Post: /api/CreateJob
        [HttpPost]
        public IHttpActionResult CreateJob(JobDto Jobdto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var job = Mapper.Map<JobDto, Job>(Jobdto);
            var currentDateTime = DateTime.Now;
            job.DateCreated = currentDateTime;
            job.EngineerId = "4e3b9487-b43e-4460-bcec-4eb724ebb713"; //By default each job will be assigned to admin
            job.Status = JobStatus.Created;
            job.Description = "Job has been created";

            _context.Jobs.Add(job);
            _context.SaveChanges();

            Jobdto.Id = job.Id;
            Jobdto.DateCreated = job.DateCreated;
            return Created(new Uri(Request.RequestUri + "/" + job.Id.ToString()), Jobdto);

        }

        //Accept or Update Job
        [HttpPut]
        public IHttpActionResult AcceptJob(AcceptJobDto acceptjobdto)
        {
            var job = _context.Jobs
                .Include(j => j.Engineer)
                .SingleOrDefault(j => j.Id == acceptjobdto.JobId);

            if(job == null)
            {
                return NotFound();
            }
            var EngineerName = job.Engineer.UserName;

            if (acceptjobdto.IsAccepted)
            {
                job.Status = JobStatus.Accepted;
                job.Description = EngineerName + " has accepted the job";
            }
            else
            {
                job.Status = JobStatus.Rejected;
                job.Engineer = null;
                job.EngineerId = null;
                job.Description = acceptjobdto.Description;
            }
            _context.SaveChanges();
            return Ok();
        }

        //Update Job Status
        [HttpPut]
        public IHttpActionResult UpdateStatus(int jobId, string status)
        {
            var job = _context.Jobs
                .Include(j => j.Engineer)
                .SingleOrDefault(j => j.Id == jobId);
            var EngineerName = job.Engineer.UserName;

            if (job == null)
                return NotFound();

            job.Status = status;
            if(status == JobStatus.OnSite)
            {
                job.Description = EngineerName + " is on site";
            }
            else if(status == JobStatus.Onhold)
            {
                job.Description = EngineerName + " has put the job Onhold on " + DateTime.Now.Date.ToString("dd/MM/yyyy");
            }
            else
            {
                job.Description = EngineerName + " has completed the job on " + DateTime.Now.Date.ToString("dd/MM/yyyy");
            }

            _context.SaveChanges();
            return Ok();
        }
        
        //Cancel Job --> Removing the job from the database
        [HttpDelete]
        public IHttpActionResult DeleteJob(int id)
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);
            if(job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return Ok();
        }

    }
}

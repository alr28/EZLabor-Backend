using AutoMapper;
using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Commons.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {

            CreateMap<Employer, EmployerResource>();
            CreateMap<Freelancer, FreelancerResource>();
            CreateMap<Skill, SkillResource>();
            CreateMap<Proposal, ProposalResource>();

            /*
            CreateMap<Meeting, SaveMeetingResource>();
            CreateMap<Offer, SaveOfferResource>();
            CreateMap<Postulation, SavePostulationResource>();
            CreateMap<Requirement, SaveRequirementResource>();
            CreateMap<Solution, SaveSolutionResource>();

            CreateMap<Comment, SaveCommentResource>();
            CreateMap<Notification, SaveNotificationResource>();
            CreateMap<Publication, SavePublicationResource>();
            CreateMap<Qualification, SaveQualificationResource>();

            CreateMap<SubscriptionPlan, SaveSubscriptionPlanResource>();

            CreateMap<Message, SaveMessageResource>();
            */
        }
    }
}

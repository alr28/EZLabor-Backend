using AutoMapper;
using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Commons.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {

            CreateMap<SaveEmployerResource, Employer>();
            CreateMap<SaveFreelancerResource, Freelancer>();
            CreateMap<SaveSkillResource, Skill>();
            CreateMap<SaveProposalResource, Proposal>();
            /*

            CreateMap<SaveMeetingResource, Meeting>();
            CreateMap<SaveOfferResource, Offer>();
            CreateMap<SavePostulationResource, Postulation>();
            CreateMap<SaveRequirementResource, Requirement>();
            CreateMap<SaveSolutionResource, Solution>();

            CreateMap<SaveCommentResource, Comment>();
            CreateMap<SaveNotificationResource, Notification>();
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SaveQualificationResource, Qualification>();

            CreateMap<SaveSubscriptionPlanResource, SubscriptionPlan>();

            CreateMap<SaveMessageResource, Message>();
            */
        }

    }
}

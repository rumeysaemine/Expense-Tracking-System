using AutoMapper;
using ExpenseTracking.Application.Features;
using ExpenseTracking.Application.Features.Expenses.DTOs;
using ExpenseTracking.Domain;

namespace ExpenseTracking.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.RequestDate, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.RejectionReason, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Documents, opt => opt.Ignore());
        
        CreateMap<UpdateExpenseCommand, Expense>();
        
        CreateMap<Expense, ExpenseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
    }
}
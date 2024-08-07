using AutoMapper;
using WebApplication5.Data.Entities;
using WebApplication5.Dtos.GroupDtos;
using WebApplication5.Dtos.StudentDtos;

namespace WebApplication5.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        #region Group Mappers
        CreateMap<Group, GroupReturnDto>();
        CreateMap<GroupCreateDto, Group>();
        CreateMap<Group, GroupInStudentReturnDto>();
        #endregion

        #region Student Mappers
        CreateMap<Student, StudentInGroupReturnDto>();
        CreateMap<Student, StudentReturnDto>();
        CreateMap<StudentCreateDto, Student>();
        #endregion
    }
}

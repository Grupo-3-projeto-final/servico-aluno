using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;
using servico_aluno.Infrastructure.Repositories.Interfaces;
using servico_aluno.Infrastructure.Services.Interfaces;

namespace servico_aluno.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<bool> Save(CourseRequestDto courseDto)
        {
            var course = new Course
            {
                CourseId = courseDto.CourseId,
                Name = courseDto.Name
            };

            if (await _courseRepository.GetById(course.CourseId) == null)
            {
                _courseRepository.Save(course);
            }

            return true;
            
        }
    }
}

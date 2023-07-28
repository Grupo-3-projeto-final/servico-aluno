using servico_aluno.Domain.Entities;
using servico_aluno.Infrastructure.Repositories.Interfaces;

namespace servico_aluno.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        public CourseRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<Course> Save(Course course)
        {
            try
            {
                var courseReturn = await _databaseConnection.ExecuteScalarAsync<int>(
                            @"
                        INSERT INTO Course
                            (CourseId, Name) 
                        VALUES 
                            (@courseId, @name);
                        SELECT @@IDENTITY;
                        "
                            ,
                        new
                        {
                            name = course.Name,
                            courseId = course.CourseId
                            ,
                        });

                return course;
            }
            catch (Exception ex)
            {
                throw new Exception("erro ao tentar salvar o curso", ex);
            }
        }

        public async Task<Course> GetById(int id)
        {
            try
            {
                var courseReturn = await _databaseConnection.QueryAsync<Course>(
                        @"
                            SELECT * FROM Course WHERE CourseId = @courseId;
                        "
                            ,
                        new
                        {
                            courseId = id

                        });

                return courseReturn.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("erro ao tentar salvar o aluno", ex);
            }
        }

    }
}

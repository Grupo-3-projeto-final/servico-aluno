using servico_aluno.Domain.Entities;

namespace servico_aluno.Infrastructure.Repositories
{
    public class StudentAverageRepository
    {

        private readonly DatabaseConnection _databaseConnection;
        public StudentAverageRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public Task<List<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentAverage> GetById(int id)
        {
            try
            {
                var student = await _databaseConnection.QueryAsync<StudentAverage>(
                        @"
                            SELECT * FROM StudentAverage WHERE StudentId=@studentId;
                        "
                        ,
                        new
                        {
                            studentId = id
                        });
                
                return student.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar buscar o aluno", ex);
            }
        }

        public async Task<StudentAverage> Save(StudentAverage student)
        {
            try
            {
                var studentId = await _databaseConnection.ExecuteScalarAsync<int>(
                            @"
                        INSERT INTO StudentAverage
                            (StudentId, CourseId, Average, Approved)
                        VALUES 
                            (@studentId, @courseId, @average, @approved)
                        "
                            ,
                        new
                        {
                            studentId = student.StudentId,
                            courseId = student.CourseId,
                            average = student.Average,
                            approved = student.Approved
                            ,
                        });

                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("erro ao tentar salvar o aluno", ex);
            }
        }
    }
}


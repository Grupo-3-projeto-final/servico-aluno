using servico_aluno.Domain.Entities;
using servico_aluno.Infrastructure.Repositories.Interfaces;

namespace servico_aluno.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        public StudentRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public Task<List<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetById(int id)
        {
            try
            {
                var student = await _databaseConnection.QueryAsync<Student>(
                        @"
                            SELECT * FROM Student WHERE StudentId=@studentId;
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

        public async Task<Student> Save(Student aluno)
        {
            try
            {
                var studentId = await _databaseConnection.ExecuteScalarAsync<int>(
                            @"
                        INSERT INTO Student
                            (Name, Email, Cpf, CourseId, DateBirth, Enabled) 
                        VALUES 
                            (@name, @email, @cpf, @courseId, @dateBirth, 0);
                        "
                            ,
                        new
                        {
                            name = aluno.Name,
                            email = aluno.Email,
                            cpf = aluno.Cpf,
                            courseId = aluno.CourseId,
                            dateBirth = aluno.DateBirth
                            ,
                        });
                aluno.StudentId = studentId;

                return aluno;
            } catch (Exception ex)
            {
                throw new Exception("erro ao tentar salvar o aluno", ex);
            }
        }

        public async Task UpdateEnabledStudent(int id)
        {
            const int Activate = 1;
            try
            {
                var studentId = await _databaseConnection.ExecuteScalarAsync<int>(
                        @"
                            UPDATE Student SET Enabled=@activate WHERE StudentId=@studentID;
                        "
                            ,
                        new
                        {
                            activate = Activate,
                            studentID = id
                            ,
                        });
            }
            catch (Exception ex)
            {
                throw new Exception("erro ao tentar salvar o aluno", ex);
            }
        }
    }
}

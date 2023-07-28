using servico_aluno.Domain.Entities;

namespace servico_aluno.Infrastructure.Repositories
{
    public class StudentAssessmentRepository
    {

        private readonly DatabaseConnection _databaseConnection;
        public StudentAssessmentRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public Task<List<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentAssessment>> GetById(int id)
        {
            try
            {
                var student = await _databaseConnection.QueryAsync<StudentAssessment>(
                        @"
                            SELECT SA.*, A.AssessmentTypeId AssessmentType, A.CourseId FROM  Student S
                            INNER JOIN StudentAssessment SA ON S.StudentId = SA.StudentId
                            INNER JOIN Assessment A ON A.AssessmentId = SA.AssessmentId
                            WHERE S.StudentId = @studentId;
                        "
                        ,
                        new
                        {
                            studentId = id
                        });
                var StudentGrades = student.Count();
                if(StudentGrades == 3)
                {
                    return student;
                }
                return null;

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
            }
            catch (Exception ex)
            {
                throw new Exception("erro ao tentar salvar o aluno", ex);
            }
        }
    }
}


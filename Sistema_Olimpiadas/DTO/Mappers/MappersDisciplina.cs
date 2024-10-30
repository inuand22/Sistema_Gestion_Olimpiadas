using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;

namespace DTO.Mappers
{
    public class MappersDisciplina
    {
        public static Disciplina FromDTO(AltaDisciplinaDTO dto)
        {
            if (dto != null)
            {
                NombreDisciplina nombreDisciplina = new NombreDisciplina(dto.NombreDisciplina);
                AnioDisciplina anioDisciplina = new AnioDisciplina(dto.AnioDisciplina);
                Disciplina disciplina = new Disciplina
                {
                    Nombre = nombreDisciplina,
                    AnioDisciplina = anioDisciplina
                };
                return disciplina;
            }
            return null;
        }

        public static ListadoDisciplinaDTO FromDisciplina(Disciplina disciplina)
        {
            ListadoDisciplinaDTO dto = new ListadoDisciplinaDTO()
            {
                NombreDisciplina = disciplina.Nombre.Valor,
                AnioDisciplina = disciplina.AnioDisciplina.Valor,
                IdDisciplina = disciplina.Id
            };
            return dto;
        }

        public static IEnumerable<ListadoDisciplinaDTO> FromDisciplinas(IEnumerable<Disciplina> disciplinas)
        {
            List<ListadoDisciplinaDTO> disc = new List<ListadoDisciplinaDTO>();

            foreach (Disciplina item in disciplinas)
            {
                disc.Add(FromDisciplina(item));
            }
            return disc;
        }
    }
}

